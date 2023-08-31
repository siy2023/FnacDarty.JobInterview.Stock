using FnacDarty.JobInterview.Stock.Data;
using FnacDarty.JobInterview.Stock.InterfaceRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace FnacDarty.JobInterview.Stock.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly SolidContext _context;

        public StockRepository(SolidContext context)
        {
            _context = context;
        }

        //ajouter des quantités de produits (par exemple lors d'achat aux fournisseurs) 
        public async Task AddProductQuantityToStockAsync(int productId, int newStock)
        {
            var entity = await _context.Stocks.SingleOrDefaultAsync(s => s.Product.Id == productId);
            var stockData = await _context.Stocks.Where(s => s.Product.Id == productId).FirstOrDefaultAsync();

            if (stockData != null)
            {
                stockData.Quantity += newStock;
                _context.Stocks.Update(entity);
                await _context.SaveChangesAsync();
            }

            await _context.Stocks.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        //ajouter plusieurs mouvements de stock sur plusieurs
        //produits à une date (mais avec un seul libellé)
        public Task AddStockMovementAsync(Stock entity)
        {
            //Verifier si le libellé est deja ajouté
            throw new NotImplementedException();
        }

        //supprimer des quantités de produits (par exemple lors de commande clients) 
        public async Task DeleteProductQuantityAsync(int productId, int newStock)
        {
            var entity = await _context.Stocks.SingleOrDefaultAsync(s => s.Product.Id == productId);
            var stockData = await _context.Stocks.Where(s => s.Product.Id == productId).FirstOrDefaultAsync();

            stockData.Quantity -= newStock;
            _context.Stocks.Update(entity);
            await _context.SaveChangesAsync();
        }

        //connaitre le stock actuel d'un produit
        public async Task<int> GetCurrentStockByProductAsync(int productId)
        {
            var stockData = await _context.Stocks.Where(s => s.Product.Id == productId).ToListAsync();

            int stockCount = stockData.Count;

            return stockCount;
        }

        //connaitre les produits actuellement en stock (les stocks négatifs sont considérés comme nuls)
        public async Task<IEnumerable<Stock>> GetProductCurrentlyInStockAsync()
        {
            //var stockData = await _context.Stocks.Include(x => x.Product).GroupBy(x => x.Product).ToListAsync();
            //var stockData = await _context.Stocks.Include(x => x.Product).GroupBy(x => x.Product).ToListAsync();
            var stockData = await _context.Stocks.ToListAsync();

            var items = stockData
                .GroupBy(x => new { x.Product.ProductName})
                .Select(g => new { g.Key.ProductName, Quantity = g.Count() }).ToList();

            return stockData;
        }

        //connaitre le stock d'un produit à n'importe quelle date dans le passé
        public async Task<int> GetStockByDateAsync(int productId, DateTime dStockDate)
        {
            var stockData = await _context.Stocks.Where(s => s.Product.Id == productId && s.Product.CreateDate == dStockDate).ToListAsync();

            int stockCount = stockData.Count;
            
            return stockCount;
        }

        //connaitre les variations de stock d'un produit pendant n'importe quelle période(intervalle de date)
        //Si un stock est à 10 à une date d1, et à 20 à une date d2, alors la variation entre d1 et d2 est +10
        public async Task<int> GetStockVariationsBetweenDatesAsync(int productId, DateTime startDate, DateTime endDate)
        {
            var stockData = await _context.Stocks.Where(s => s.Product.Id == productId && s.Product.CreateDate >= startDate && s.Product.CreateDate <= endDate).ToListAsync();

            int stockCount = stockData.Count;

            return stockCount;
        }

        //connaitre le nombre total de produit dans le stock (les stocks négatifs sont considérés comme nuls)        
        public async Task<int> GetTotalNberOfProductsInStockAsync()
        {
            var stockData = await _context.Stocks.ToListAsync();

            int stockCount = stockData.Count();

            return stockCount;
        }
    }
}
