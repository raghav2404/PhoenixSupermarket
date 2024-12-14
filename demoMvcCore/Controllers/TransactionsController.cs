using demoMvcCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.TransactionsUseCase;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demoMvcCore.Controllers
{

    [Authorize]
    public class TransactionsController : Controller
    {

        private readonly ISearchTransactionsUseCase searchTransactionsUseCase;

        public TransactionsController(ISearchTransactionsUseCase searchTransactionsUseCase)
        {
            this.searchTransactionsUseCase = searchTransactionsUseCase;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            TransactionsViewModel transactionsVM = new();

            return View(transactionsVM);
        }



        public IActionResult Search(TransactionsViewModel transactionsViewModel)
        {

            //search

            var transactions = searchTransactionsUseCase.Execute(
                 transactionsViewModel.CashierName ?? string.Empty,
                 transactionsViewModel.StartDate,
                 transactionsViewModel.EndDate);

            transactionsViewModel.Transactions = transactions;

            return View("Index", transactionsViewModel);


        }
    }
}

        