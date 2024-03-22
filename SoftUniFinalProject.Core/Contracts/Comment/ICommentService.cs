using SoftUniFinalProject.Core.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Contracts.Comment
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentViewModel>> GetAllCommentsForEventAsync(int eventId);
    }
}
