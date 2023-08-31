using System.Threading.Tasks;

namespace FnacDarty.JobInterview.Stock.InterfaceRepositories
{
    public interface IProductRepository
    {
        //L'ajout dans le stock d'un produit non existant crée le produit.
        Task AddProductAsync(Product entity);
    }
}
