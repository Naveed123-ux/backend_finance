using apl_project.Models;
using backend_finance.Dtos.Stock;

namespace backend_finance.Interface
{
    public interface IStockRepsitory
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stock);
        Task<Stock?> UpdateAsync(int id,UpdateStockRequestDto update);
        Task<Stock?> DeleteAsync(int id);
        Task<bool> CheckAsync(int id);
    }
}