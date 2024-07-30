using apl_project.Models;
using backend_finance.Dtos.Stock;

namespace backend_finance.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this  Stock stockModel)
        {
            return new StockDto {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                LastDiv=stockModel.LastDiv,
                CompanyName = stockModel.CompanyName,
                MarketCap=stockModel.MarketCap,
                Industry=stockModel.Industry,
                Purchase=stockModel.Purchase,
                Comments=stockModel.Comments.Select(C=>C.ToCommentDto()).ToList(),
            };
        }
        public static Stock ToStockFromCreateDto(this CreateStockRequestDto st)
        {
            return new Stock
            {
                Symbol = st.Symbol,
                LastDiv = st.LastDiv,
                CompanyName = st.CompanyName,
                MarketCap = st.MarketCap,
                Industry = st.Industry,
                Purchase = st.Purchase,
            };
        }
    }
}
