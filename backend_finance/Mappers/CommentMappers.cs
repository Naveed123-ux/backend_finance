using apl_project.Models;
using backend_finance.Dtos.Comment;

namespace backend_finance.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto (this Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                CreatedOn= comment.CreatedOn,
                Title = comment.Title,
                Content = comment.Content,
                StockId = comment.StockId,
            };
        }
        public static Comment CreateComment(this CreateCommentDto comment,int id) {
            return new Comment {
           Title = comment.Title,
           Content = comment.Content,
           StockId = id,
            };
        }
    }
}
