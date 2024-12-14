using System;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.ProductsUseCase
{
	public class DeleteProductUseCase:IDeleteProductUseCase
    {
        private readonly IProductRepository productRepository;

        public DeleteProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Execute(int productId)
        {
            productRepository.DeleteProduct(productId);
        }
    }

    public interface IDeleteProductUseCase
    {
        void Execute(int productId);
    }
}

