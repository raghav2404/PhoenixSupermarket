using System.ComponentModel.DataAnnotations;
using CoreBusiness;

namespace demoMvcCore.ViewModels
{
	public class TransactionsViewModel
	{
		[Display(Name = "Cashier Name")]
		public string? CashierName { get; set; }

		[Display(Name ="Start Date")]
		public DateTime StartDate { get; set; } = DateTime.Now;

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } = DateTime.Now;


		public IEnumerable<Transaction> Transactions = new List<Transaction>();






	}
}

