using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SoftUniFinalProject.Core.Contracts.Comment;
using SoftUniFinalProject.Core.Models.Comment;
using SoftUniFinalProject.Infrastructure.Constants;
using SoftUniFinalProject.Infrastructure.Data.Common;
using SoftUniFinalProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Services.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repository;
        private readonly ILogger<CommentService> logger;

        public CommentService(IRepository _repository, ILogger<CommentService> _logger)
        {
            repository = _repository;
            logger = _logger;
        }

        public async Task<int> CreateCommentAsync(CommentToCreateViewModel commentModel,string userId, int eventId)
        {
            Comment comment = new Comment()
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
                logger.LogError(nameof(CreateCommentAsync), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }


            return comment.Id;
        }

        public async Task<IEnumerable<CommentViewModel>> GetAllCommentsForEventAsync(int eventId)
        {
            return await repository.AllReadOnly<Comment>()
                .Where(c => c.EventId == eventId)
                .Select(c => new CommentViewModel()
                {
                    Id = c.Id,
                    PublicationTime = c.PublicationTime.ToString(DataConstants.DateTimeFormat, CultureInfo.InvariantCulture),
                    Text = c.Text,
                    UserId = c.UserId,
                    EventId = eventId,
                    UserName = c.User.UserName
                })
                .ToListAsync();
        }
    }
}
