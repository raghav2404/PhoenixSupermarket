using System;
using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
        public interface IProductRepository
        {
            IEnumerable<Product> GetProducts(bool loadCategory = false);
            void AddProduct(Product product);
            void UpdateProduct(int productId, Product product);
            Product? GetProductById(int productId, bool loadCategory = false);
            void DeleteProduct(int productId);
            IEnumerable<Product> GetProductsByCategoryId(int categoryId);
        } 
}

