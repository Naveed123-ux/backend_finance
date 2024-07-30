using apl_project.Models;
using backend_finance.Dtos.Comment;

namespace backend_finance.Interface
{
    public interface ICommentRepositry
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment comment); 
        Task<Comment?> DeleteAsync(int id);
        Task<Comment?> UpdateAsync(int id, UpdateCommentDto comment);
    }
}
