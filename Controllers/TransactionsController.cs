using demoMvcCore.Models;
using demoMvcCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demoMvcCore.Controllers
{
    public class TransactionsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            TransactionsViewModel transactionsVM = new();

            return View(transactionsVM);
        }



        public IActionResult Search(TransactionsViewModel transactionsViewModel)
        {

            //search

            var transactions = TransactionsRepository.Search(transactionsViewModel.CashierName ?? string.Empty, transactionsViewModel.StartDate, transactionsViewModel.EndDate);
            transactionsViewModel.Transactions = transactions;

            return View("Index", transactionsViewModel);


        }
    }
}

        