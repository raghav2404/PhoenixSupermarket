using System;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CategoriesUseCase
{
	public class ViewSelectedCategoryUseCase: IViewSelectedCategoryUseCase
    {

		private readonly ICategoryRepository categoryRepository;
		public ViewSelectedCategoryUseCase(ICategoryRepository _categoryRepository)
		{
			categoryRepository = _categoryRepository;
		}


		public Category? Execute(int categoryId)
		{
			return categoryRepository.GetCategoryById(categoryId);
		}
	}

    public interface IViewSelectedCategoryUseCase
    {
		Category? Execute(int categoryId);
    }
}

