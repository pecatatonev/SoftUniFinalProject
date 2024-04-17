using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework.Internal;
using SoftUniFinalProject.Core.Contracts.Comment;
using SoftUniFinalProject.Core.Models.Comment;
using SoftUniFinalProject.Core.Services.CommentService;
using SoftUniFinalProject.Infrastructure.Data;
using SoftUniFinalProject.Infrastructure.Data.Common;
using System.Linq.Expressions;
using Comment = SoftUniFinalProject.Infrastructure.Data.Models.Comment;

namespace SoftUniFinalProject.UnitTests
{
    [TestFixture]
    public class CommentServiceTests
    {
        private IRepository repository;
        private ICommentService commentService;
        private FootballEventDbContext context;
        private Infrastructure.Data.IdentityModels.ApplicationUser userAdmin;
        private Infrastructure.Data.Models.Event eventToUse;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<FootballEventDbContext>()
                .UseInMemoryDatabase("FootballEventsTestDB")
                .Options;

            context = new FootballEventDbContext(options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


            userAdmin = new Infrastructure.Data.IdentityModels.ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395022",
                UserName = "host3663",
                NormalizedUserName = "HOST3663",
                Email = "host@football.com",
                NormalizedEmail = "host@football.com",
                FirstName = "Host",
                LastName = "User"
            };

            context.Users.Add(userAdmin);

            eventToUse = new Infrastructure.Data.Models.Event()
            {
                 Id = 100,
                Name = "Test",
                Description = "Test",
                FootballGameId = 1,
                Location = "TestLocation",
                OrganiserId = userAdmin.Id,
                Organiser = userAdmin,
                StartOn = DateTime.Now,
            };

            context.Comments.AddRange(new List<Comment>
            {
                new Comment()
                {
                    Event = eventToUse,
                    EventId = eventToUse.Id,
                    PublicationTime = DateTime.Now.AddMinutes(50),
                    Text = "Test comment",
                    User = userAdmin,
                    UserId = userAdmin.Id,
                    Id = 3
                },
                new Comment()
                {
                    Event = eventToUse,
                    EventId = eventToUse.Id,
                    PublicationTime = DateTime.Now.AddMinutes(30),
                    Text = "Test comment 2",
                    User = userAdmin,
                    UserId = userAdmin.Id,
                    Id = 4
                }
            });

            context.SaveChanges();
            repository = new Repository(context);
            commentService = new CommentService(repository);
        }

        [Test]
        public async Task CreateCommentAsync_SuccessfullyCreatesEvent()
        {
            //Arrange
            await commentService.CreateCommentAsync(new CommentToCreateViewModel()
            {
                EventId= eventToUse.Id,
                Id = 5,
                Text = "Welcome Test"
            },userId: userAdmin.Id,eventId: eventToUse.Id);

            var dbComment = await repository.GetByIdAsync<Comment>(5);

            // Act & Assert
            Assert.That(dbComment, Is.Not.Null);
            Assert.That(dbComment.Text, Is.EqualTo("Welcome Test"));
            Assert.That(dbComment.EventId, Is.EqualTo(eventToUse.Id));
        }

        [Test]
        public async Task CreateAsync_ThrowsExceptionWhenCommentIsAlreadyCreated()
        {   // Act & Assert
            Assert.ThrowsAsync<ApplicationException>(() => commentService.CreateCommentAsync(new CommentToCreateViewModel()
            {
                EventId = eventToUse.Id,
                Id = 3,
                Text = "Test comment"
            }, userId: userAdmin.Id, eventId: eventToUse.Id));
        }


        [Test]
        public void CreateAsync_DatabaseException_ThrowsApplicationException()
        {
            // Arrange
            var model = new CommentToCreateViewModel
            {

                EventId = eventToUse.Id,
                Id = 5,
                Text = "Welcome Test"
            };

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.AlreadyExistAsync(It.IsAny<Expression<Func<Comment, bool>>>()))
              .ReturnsAsync(false);
            mockRepository.Setup(r => r.AddAsync(It.IsAny<Comment>())).ThrowsAsync(new Exception());

            var service = new CommentService(mockRepository.Object);

            // Act & Assert
            Assert.ThrowsAsync<ApplicationException>(() => service.CreateCommentAsync(model, userAdmin.Id, eventToUse.Id));
        }

        [Test]
        public async Task GetAllCommentsForEventAsync_ReturnsMappedViewModels()
        {
            //Arrange & Act
            var result = await commentService.GetAllCommentsForEventAsync(eventToUse.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(eventToUse.Comments.Count()));

            foreach (var comment in eventToUse.Comments)
            {
                var commentViewModel = result.FirstOrDefault(c => c.Id == comment.Id
                                                            && c.EventId == comment.EventId
                                                            && c.Text == comment.Text
                                                            && c.UserId == comment.UserId
                                                            && c.UserName == comment.User.UserName);
                Assert.IsNotNull(commentViewModel);
            }
        }

        [Test]
        public async Task ExistsAsync_CommentExists_ReturnsTrue()
        {
            // Arrange
            int commentId = 4;

            // Act
            var result = await commentService.ExistsAsync(commentId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsAsync_CommentDoesNotExist_ReturnsFalse()
        {
            // Arrange
            int commentId = 10;

            // Act 
            var result = await commentService.ExistsAsync(commentId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task SameUserAsync_CommentBelongsToCurrentUser_ReturnsTrue()
        {
            // Arrange
            int commentId = 4;
            // Act
            var result = await commentService.SameUserAsync(commentId, userAdmin.Id);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task SameUserAsync_CommentDoesNotBelongToCurrentUser_ReturnsFalse()
        {
            //Arrange
            string currentUserId = "user123";
            int commentId = 4;
            // Act
            var result = await commentService.SameUserAsync(commentId, currentUserId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task CommentByIdWithUserAsync_ReturnsCommentWithUser()
        {
            //Arrange
            int commentId = 4;

            //Act
            var result = await commentService.CommentByIdWithUserAsync(commentId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(commentId));
            Assert.That(result.User.UserName, Is.EqualTo(userAdmin.UserName));
        }


        [Test]
        public async Task CommentByIdAsync_ReturnsCommentWithUser()
        {
            //Arrange
            int commentId = 4;

            //Act
            var result = await commentService.CommentByIdWithUserAsync(commentId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(commentId));
        }

        [Test]
        public async Task EditAsync_CommentExists_EditsAndSavesComment()
        {
            // Arrange
            int commentId = 4; // Example comment ID
            var model = new CommentToCreateViewModel { Text = "Updated text" };
            var commentBeforeUpdate =await commentService.CommentByIdAsync(commentId);

            // Act
            var eventId = await commentService.EditAsync(commentId, model);

            var commentAfterUpdate = await commentService.CommentByIdAsync(commentId);
            // Assert
            Assert.That(commentAfterUpdate.Text, Is.EqualTo(model.Text));
            Assert.That(commentBeforeUpdate.PublicationTime, Is.Not.EqualTo(DateTime.Now));
            Assert.That(eventId, Is.EqualTo(commentBeforeUpdate.EventId));
        }

        [Test]
        public async Task DeleteAsync_CommentExists_DeletesAndSavesComment()
        {
            // Arrange
            int commentId = 1; // Example comment ID
            var comment = new Comment { Id = commentId };

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetByIdAsync<Infrastructure.Data.Models.Comment>(commentId))
                          .ReturnsAsync(comment);

            var service = new CommentService(mockRepository.Object);

            // Act
            await service.DeleteAsync(commentId);

            // Assert
            mockRepository.Verify(r => r.Delete(comment), Times.Once);
            mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once); 
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
