using Models;

namespace EcoPower_Logistics.Repository
{
    public interface IProductsRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetAllProduct();
        Product GetProductById(int Id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        bool ProductExists(int id);
    }
}
