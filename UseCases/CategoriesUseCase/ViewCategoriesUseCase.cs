using System;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CategoriesUseCase
{
	public class ViewCategoriesUseCase:IViewCategoriesUseCase


	{
		private readonly ICategoryRepository categoryRepository;

		public ViewCategoriesUseCase(ICategoryRepository _categoryRepository)
		{
			categoryRepository = _categoryRepository;
		}

		public IEnumerable<Category> Execute()
		{

			return categoryRepository.GetCategories();

		}


	}
}

