
using Microsoft.AspNetCore.Mvc;
using UseCases.TransactionsUseCase;

namespace demoMvcCore.ViewComponents
{
    [ViewComponent]
	public class TransactionViewComponent:ViewComponent
	{

        private readonly IGetTodayTransactionsUseCase getTodayTransactionsUseCase;

        public TransactionViewComponent(IGetTodayTransactionsUseCase getTodayTransactionsUseCase)
        {
            this.getTodayTransactionsUseCase = getTodayTransactionsUseCase;
        }

        public IViewComponentResult Invoke(string userName)
        {
            var transactions = getTodayTransactionsUseCase.Execute(userName);

            return View(transactions);
        }
    }
}

