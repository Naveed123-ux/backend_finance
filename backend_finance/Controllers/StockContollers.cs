using apl_project.Data;
using backend_finance.Dtos.Stock;
using backend_finance.Interface;
using backend_finance.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_finance.Controllers
{
    [Route("backend_finance/stock")]
    [ApiController]
    public class StockContollers:ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IStockRepsitory _repo;
        public StockContollers(AppDbContext context,IStockRepsitory repo)
        {
            _context = context;  
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stockmodel = await _repo.GetAllAsync();
            var stock= stockmodel.Select(s => s.ToStockDto());
            return Ok(stock);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var stock =await _repo.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateStockRequestDto st)
        {
            var stock = st.ToStockFromCreateDto();
            var stockmod= await _repo.CreateAsync(stock);   
            return Ok(stockmod);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateStockRequestDto stockmod)
        {
           
            var stock=await _repo.UpdateAsync(id, stockmod);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }
        [HttpDelete("{id}")]
        public async  Task<IActionResult> Delete([FromRoute] int id) {
           
            var stock= await _repo.DeleteAsync(id);
            if(stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }
    }
}
