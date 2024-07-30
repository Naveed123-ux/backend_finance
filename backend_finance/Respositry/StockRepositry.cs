using apl_project.Data;
using apl_project.Models;
using backend_finance.Dtos.Stock;
using backend_finance.Interface;
using backend_finance.Mappers;
using Microsoft.EntityFrameworkCore;

namespace backend_finance.Respositry
{
    public class StockRepositry : IStockRepsitory
    {
        private readonly AppDbContext _context;
        public StockRepositry(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckAsync(int id)
        {
           var stock=await _context.Stock.FindAsync(id);
            if (stock == null)
            {  return false; }
            return true;
        }

        public async Task<Stock> CreateAsync(Stock stock)
        {
            await _context.Stock.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stock = await _context.Stock.FindAsync(id);
            if (stock == null) { return null; }
            _context.Stock.Remove(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stock.Include(c=>c.Comments).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            var stock = await _context.Stock.Include(c=>c.Comments).FirstOrDefaultAsync(i=>i.Id==id);
            if (stock == null)
            {
                return null;
            };
            return stock;
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockmod)
        {
            var StockModel = await _context.Stock.FindAsync(id);
            if (StockModel == null)
            {
                return null;
            }
            StockModel.CompanyName = stockmod.CompanyName;
            StockModel.Symbol = stockmod.Symbol;
            StockModel.MarketCap = stockmod.MarketCap;
            StockModel.Purchase = stockmod.Purchase;
            StockModel.LastDiv = stockmod.LastDiv;
            StockModel.Industry = stockmod.Industry;
            await _context.SaveChangesAsync();
            return StockModel;
        }
    }
}
    