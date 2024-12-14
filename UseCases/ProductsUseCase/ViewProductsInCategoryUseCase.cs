using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.ProductsUseCase
{
	
        public class ViewProductsInCategoryUseCase : IViewProductsInCategoryUseCase
        {
            private readonly IProductRepository productRepository;

            public ViewProductsInCategoryUseCase(IProductRepository productRepository)
            {
                this.productRepository = productRepository;
            }

            public IEnumerable<Product> Execute(int categoryId)
            {
                return productRepository.GetProductsByCategoryId(categoryId);
            }
        }

      public interface IViewProductsInCategoryUseCase
      {
        IEnumerable<Product> Execute(int categoryId);
       }


}

