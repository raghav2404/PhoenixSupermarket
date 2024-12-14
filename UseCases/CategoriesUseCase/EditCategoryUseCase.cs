using System;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CategoriesUseCase
{
	public class EditCategoryUseCase:IEditCategoryUseCase
	{

		private readonly ICategoryRepository _categoryRepository;
        public EditCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Execute(int categoryId, Category category)
		{
			_categoryRepository.UpdateCategory(categoryId,  category);
		}
	}

    public interface IEditCategoryUseCase
    {
        void Execute(int categoryId, Category category);
    }
}

