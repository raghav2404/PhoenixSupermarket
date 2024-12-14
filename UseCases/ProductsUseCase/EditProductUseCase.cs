using System;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.ProductsUseCase
{
	public class EditProductUseCase:IEditProductUseCase
    {
        private readonly IProductRepository productRepository;

        public EditProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Execute(int productId, Product product)
        {
            productRepository.UpdateProduct(productId, product);
        }
    }


    public interface IEditProductUseCase
    {
        void Execute(int productId, Product product);
    }
}

