
using demoMvcCore.Models;

namespace demoMvcCore.ViewModels
{
	public class ProductsViewModel
	{
		public ProductsViewModel()
		{
	

		}

		public IEnumerable<Category> Categories { get; set; } = new List<Category>();
		public Product Product { get; set; } = new();
	}
}

