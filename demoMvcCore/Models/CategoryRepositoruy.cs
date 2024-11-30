using System;
namespace demoMvcCore.Models
{
	public class CategoryRepository
	{
		public CategoryRepository()
		{ }
		private static List<Category> _categories = new List<Category>()
			{ new Category {CategoryId = 1,Name="Beverage",Description="Beverage"},
			 new Category {CategoryId = 2,Name="Snacks",Description="Snacks" } };

		public static List<Category> GetCategories() => _categories;

		public static void AddCategory(Category category)
		{
			var maxId = _categories.Max(x => x.CategoryId);
			category.CategoryId = maxId + 1;
			_categories.Add(category);
		}
        public static Category? GetCategoryById(int categoryId) =>
            _categories.FirstOrDefault(x => x.CategoryId == categoryId);



		public static void UpdateCategory(int id ,Category category)
		{
			var Category = _categories.FirstOrDefault(x => x.CategoryId==id);
			if(Category is not null)
			{
				Category.Name = category.Name;
				Category.Description = category.Description;
			}
		}

		public static void DeleteCategory(int id)
		{
			var category = GetCategoryById(id);
			if (category is not null)
				_categories.Remove(category);

		}



    }
	}


