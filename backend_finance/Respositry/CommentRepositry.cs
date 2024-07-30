using apl_project.Data;
using apl_project.Models;
using backend_finance.Dtos.Comment;
using backend_finance.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend_finance.Respositry
{
    public class CommentRepositry : ICommentRepositry
    {
        private readonly AppDbContext _context;
        public CommentRepositry(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return null;
            }
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comment?> UpdateAsync(int id, UpdateCommentDto comment)
        {
            
                var Com = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
                if (comment == null)
                {
                    return null;
                }
                Com.Title = comment.Title;
                Com.Content = comment.Content;
                await _context.SaveChangesAsync();
                return Com;
           
        }
    }
}
