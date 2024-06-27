using Esercizio_S2_L4_Riepilogo.Entities;

namespace Esercizio_S2_L4_Riepilogo.Services
{
    public class ProductService : IProductService
    {   
        protected static readonly List<Product> products = new List<Product>();
        private static int lastId = 0;

        public void Create(Product product)
        {
           product.Id = ++lastId;
            products.Add(product);
        }

        public void Delete(int productId)
        {
            var product = products.Single(p => p.Id == productId);
            products.Remove(product);
        }

        public IEnumerable<Product> GetAllProducts() => products;

        public Product GetById(int productId)
        {
            var product = products.Single(p => p.Id == productId);
            return product;
        }
    }
}
