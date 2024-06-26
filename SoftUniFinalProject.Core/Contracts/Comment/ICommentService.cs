﻿using SoftUniFinalProject.Core.Models.Comment;

namespace SoftUniFinalProject.Core.Contracts.Comment
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentViewModel>> GetAllCommentsForEventAsync(int eventId);
        Task CreateCommentAsync(CommentToCreateViewModel commentModel,string userId, int eventId);
        Task<Infrastructure.Data.Models.Comment> CommentByIdAsync(int id);
        Task<Infrastructure.Data.Models.Comment> CommentByIdWithUserAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> SameUserAsync(int commentId, string currentUserId);
        Task<int> EditAsync(int commentId, CommentToCreateViewModel model);
        Task DeleteAsync(int commentId);
    }
}
