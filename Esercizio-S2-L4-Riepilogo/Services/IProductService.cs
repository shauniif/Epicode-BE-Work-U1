using Esercizio_S2_L4_Riepilogo.Entities;

namespace Esercizio_S2_L4_Riepilogo.Services
{
    public interface IProductService
    {   
        IEnumerable<Product> GetAllProducts();
        void Create(Product product);

        void Delete(int productId);
        
        Product GetById(int productId);

    }
}
