using FnacDarty.JobInterview.Stock.Data;
using FnacDarty.JobInterview.Stock.InterfaceRepositories;
using System.Threading.Tasks;

namespace FnacDarty.JobInterview.Stock.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SolidContext _context;

        public ProductRepository(SolidContext context)
        {
            _context = context;    
        }

        public async Task AddProductAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
