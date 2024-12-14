using System.ComponentModel.DataAnnotations;
using CoreBusiness;
using demoMvcCore.ViewModels.Validations;

namespace demoMvcCore.ViewModels
{
	public class SalesViewModel
	{
        public int SelectedCategoryId { get; set; }
		public IEnumerable<Category> Categories { get; set; } = new List<Category>();
		public int SelectedProductId { get; set; }


        [Display(Name = "Quantity")]	
        [Range(1,int.MaxValue)]
        [EnsureProperQuantity]
        public int QuantityToSell { get; set; }

	}
}

