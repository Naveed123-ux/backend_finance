using backend_finance.Dtos.Comment;
using backend_finance.Interface;
using backend_finance.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace backend_finance.Controllers
{
    [Route("backend_finance/comment")]
    [ApiController]
    public class CommentControllers : ControllerBase

    {
        private readonly ICommentRepositry _repo;
        private readonly IStockRepsitory _stockRepo;
        public CommentControllers(ICommentRepositry repo, IStockRepsitory stockrepo)
        {
            _repo = repo;
            _stockRepo = stockrepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var stock = await _repo.GetAllAsync();
            var stockModel = stock.Select(x => x.ToCommentDto());
            return Ok(stockModel);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var commentModel = await _repo.GetByIdAsync(id);
            if (commentModel != null)
            {
                return Ok(commentModel.ToCommentDto());
            };
            return NotFound();
        }
        [HttpPost("{id:int}")]
        public async Task<IActionResult> CreateAsync([FromRoute] int id, [FromBody] CreateCommentDto comment)
        {
            if (!await _stockRepo.CheckAsync(id))
            {

                return BadRequest("stock does not exists");
            }
            var com = comment.CreateComment(id);
            await _repo.CreateAsync(com);
            return Ok(com.ToCommentDto());
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var comment = await _repo.DeleteAsync(id);
            if (comment != null)
            {
                return Ok(comment.ToCommentDto());
            }
            return NotFound();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateCommentDto comment)
        {
            var updatedComment = await _repo.UpdateAsync(id, comment);
            if (updatedComment != null)
            {
               return Ok(updatedComment.ToCommentDto());
            }
            return NotFound();
        }
    }
}