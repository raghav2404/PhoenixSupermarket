using System;
using CoreBusiness;
using static UseCases.ProductsUseCase.ViewSelectedProductUseCase;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.ProductsUseCase
{
	
        public class ViewSelectedProductUseCase : IViewSelectedProductUseCase
        {
            private readonly IProductRepository productRepository;

            public ViewSelectedProductUseCase(IProductRepository productRepository)
            {
                this.productRepository = productRepository;
            }

            public Product? Execute(int productId)
            {
                return productRepository.GetProductById(productId);
            }
        }

    public interface IViewSelectedProductUseCase
    {
        Product? Execute(int productId);
    }
}

