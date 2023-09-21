using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        private readonly SuperStoreContext _superStoreContext = new SuperStoreContext();

        public ProductsRepository(SuperStoreContext superStoreContext) : base(superStoreContext) { }
        public IEnumerable<Product> GetAllProduct()
        {
            return _superStoreContext.Products.ToList();
        }

        // TO DO: Add ‘Get By Id’

        public Product GetProductById(int Id)
        {
            return _superStoreContext.Products.FirstOrDefault(x => x.ProductId == Id);
        }

        // TO DO: Add ‘Create’
        public void CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException($"{nameof(product)} could not be created.");
            }

            _superStoreContext.Products.Add(product);
            _superStoreContext.SaveChanges();
        }

        // TO DO: Add ‘Edit’
        public void UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException($"{nameof(product)} could not be updated.");
            }

            _superStoreContext.Products.Update(product);
            _superStoreContext.SaveChanges();

        }
        // TO DO: Add ‘Delete’

        public void DeleteProduct(int Id)
        {
            var productDelete = _superStoreContext.Products.FirstOrDefault(x => x.ProductId == Id);
            if (productDelete != null)
            {
                _superStoreContext.Remove(productDelete);
                _superStoreContext.SaveChanges();
            }
        }
        // TO DO: Add ‘Exists’

        public bool ProductExists(int id)
        {
            return (_superStoreContext.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }

    }
}

