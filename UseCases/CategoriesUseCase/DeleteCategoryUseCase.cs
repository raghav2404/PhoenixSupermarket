using System;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CategoriesUseCase
{
	public class DeleteCategoryUseCase:IDeleteCategoryUseCase
	{

		private readonly ICategoryRepository _categoryRepository;
		public DeleteCategoryUseCase(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public void Execute(int categoryId)
		{
			_categoryRepository.DeleteCategory(categoryId);
		}
	}

    public interface IDeleteCategoryUseCase
    {
		void Execute(int categoryId);
    }
}

