using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SoftUniFinalProject.Core.Contracts.Comment;
using SoftUniFinalProject.Core.Models.Comment;
using SoftUniFinalProject.Core.Models.Event;
using SoftUniFinalProject.Infrastructure.Constants;
using SoftUniFinalProject.Infrastructure.Data.Common;
using SoftUniFinalProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static SoftUniFinalProject.Infrastructure.Constants.DataConstants;

namespace SoftUniFinalProject.Core.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repository;
        private readonly ILogger<CommentService> logger;

        public CommentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task CreateCommentAsync(CommentToCreateViewModel commentModel,string userId, int eventId)
        {
            if (await repository.AlreadyExistAsync<Infrastructure.Data.Models.Comment>(e => e.Text == commentModel.Text && e.UserId == userId && e.EventId == eventId))
            {
                throw new ApplicationException("Comment already exists");
            }

            Infrastructure.Data.Models.Comment comment = new Infrastructure.Data.Models.Comment()
            {
                EventId = eventId,
                PublicationTime = DateTime.Now,
                Text = commentModel.Text,
                UserId = userId,
            };

           
            try
            {
                await repository.AddAsync(comment);
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database failed to save info", ex);
            }
        }

        public async Task<IEnumerable<CommentViewModel>> GetAllCommentsForEventAsync(int eventId)
        {
            if (await repository.GetByIdAsync<Infrastructure.Data.Models.Event>(eventId) == null)
            {
                return null;
            }

            return await repository.AllReadOnly<Infrastructure.Data.Models.Comment>()
                .Where(c => c.EventId == eventId)
                .Select(c => new CommentViewModel()
                {
                    Id = c.Id,
                    PublicationTime = c.PublicationTime.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                    Text = c.Text,
                    UserId = c.UserId,
                    EventId = eventId,
                    UserName = c.User.UserName
                })
                .ToListAsync();
        }

        public async Task<bool> ExistsAsync(int idComment)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Comment>().AnyAsync(e => e.Id == idComment);
        }

        public async Task<bool> SameUserAsync(int commentId, string currentUserId)
        {
            bool result = false;
            var comment = await repository.AllReadOnly<Infrastructure.Data.Models.Comment>()
                .Where(c => c.Id == commentId)
                .FirstOrDefaultAsync();

            if (comment.UserId == currentUserId)
            {
                result = true;
            }

            return result;
        }


        public async Task<Infrastructure.Data.Models.Comment> CommentByIdWithUserAsync(int id)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Comment>()
            .Where(c => c.Id == id)
            .Include(c => c.User)
            .FirstAsync();
        }

        public async Task<Infrastructure.Data.Models.Comment> CommentByIdAsync(int id)
        {
            return await repository.AllReadOnly<Infrastructure.Data.Models.Comment>()
            .Where(c => c.Id == id)
            .FirstAsync();
        }

        public async Task<int> EditAsync(int commentId, CommentToCreateViewModel model)
        {
            var commentToEdit = await repository.GetByIdAsync<Infrastructure.Data.Models.Comment>(commentId);

            commentToEdit.Text = model.Text;
            commentToEdit.PublicationTime = DateTime.Now;

            await repository.SaveChangesAsync();
            return commentToEdit.EventId;
        }

        public async Task DeleteAsync(int commentId)
        {
            var commentToDelete = await repository.GetByIdAsync<Infrastructure.Data.Models.Comment>(commentId);
            repository.Delete(commentToDelete);

            await repository.SaveChangesAsync();
        }
    }
}
