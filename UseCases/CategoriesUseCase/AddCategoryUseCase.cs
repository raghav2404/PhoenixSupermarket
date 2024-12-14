using System;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CategoriesUseCase
{
	public class AddCategoryUseCase:IAddCategoryUseCase
	{

        private readonly ICategoryRepository categoryRepository;
        public AddCategoryUseCase(ICategoryRepository _categoryRepository)
		{

			categoryRepository = _categoryRepository;
		}


		public void Execute(Category category)
		{

			categoryRepository.AddCategory(category);
		}
	
	}

    public interface IAddCategoryUseCase
    {

		void Execute(Category category);
    }
}

