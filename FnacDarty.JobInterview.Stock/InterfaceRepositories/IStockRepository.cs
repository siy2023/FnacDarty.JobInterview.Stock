using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace FnacDarty.JobInterview.Stock.InterfaceRepositories
{
    public interface IStockRepository
    {
        //To add quantities of products (for example when purchasing from suppliers-
        //Increase the product in stock (+)) 
        Task AddProductQuantityToStockAsync(int productId, int newStock);

        //to delete quantities of products (for example when ordering customers (-))
        Task DeleteProductQuantityAsync(int productId, int newStock);

        //to add several stock movements on several products on a date (but with a single caption)
        Task AddStockMovementAsync(Stock entity);

        //to know the stock of a product at any date in the past
        Task<int> GetStockByDateAsync(int productId, DateTime dStockDate);

        //to know the stock variations of a product during any period (interval of dates)
        Task<int> GetStockVariationsBetweenDatesAsync(int productId, DateTime startDate, DateTime endDate);

        //to know the current stock of a product
        Task<int> GetCurrentStockByProductAsync(int productId);

        //to know the products currently in stock (negative stocks are considered null)
        Task<IEnumerable<Stock>> GetProductCurrentlyInStockAsync();

        //to know the total number of products in the stock (negative stocks are considered as zero)
        Task<int> GetTotalNberOfProductsInStockAsync();
    }
}
