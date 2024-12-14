using System;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
	public class CategoriesInMemoryRepository : ICategoryRepository
	{

             private  List<Category> _categories = new List<Category>()
            { new Category {CategoryId = 1,Name="Beverage",Description="Beverage"},
             new Category {CategoryId = 2,Name="Snacks",Description="Snacks" } };

        public CategoriesInMemoryRepository()
        {
        }

        public IEnumerable<Category> GetCategories() => _categories;

        public  void AddCategory(Category category)
        {
            if (_categories is not null && _categories.Count > 0)
            {
                var maxId = _categories.Max(x => x.CategoryId);
                category.CategoryId = maxId + 1;

            }
            else
            {
                var maxId = 1;
                category.CategoryId = maxId;
            }
            _categories ??= new List<Category>();
            _categories.Add(category);
        }
        public  Category? GetCategoryById(int categoryId) =>
            _categories.FirstOrDefault(x => x.CategoryId == categoryId);



        public void UpdateCategory(int id, Category category)
        {
            var Category = _categories.FirstOrDefault(x => x.CategoryId == id);
            if (Category is not null)
            {
                Category.Name = category.Name;
                Category.Description = category.Description;
            }
        }

        public  void DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category is not null)
                _categories.Remove(category);

        }

    }
}

