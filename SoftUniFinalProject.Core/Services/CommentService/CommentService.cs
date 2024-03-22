using Microsoft.EntityFrameworkCore;
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

        public CommentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<CommentViewModel>> GetAllCommentsForEventAsync(int eventId)
        {
            return await repository.AllReadOnly<Comment>()
                .Where(c => c.EventId == eventId)
                .Select(c => new CommentViewModel()
                {
                    Id = c.Id,
                    PublicationTime = DateTime.Now.ToString(DataConstants.DateTimeFormat, CultureInfo.InvariantCulture),
                    Text = c.Text,
                    UserId = c.UserId,
                    EventId = eventId,
                    UserName = c.User.UserName
                })
                .ToListAsync();
        }
    }
}
