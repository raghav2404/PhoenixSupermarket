using demoMvcCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace demoMvcCore.ViewComponents
{

	public class TransactionViewComponent:ViewComponent
	{


		public IViewComponentResult Invoke(string userName)
		{
		    var transactions =  TransactionsRepository.GetByDayAndCashier(userName, DateTime.Now);
			
			return View(transactions);
		}

	}
}

