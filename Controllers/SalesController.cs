using demoMvcCore.Models;
using demoMvcCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demoMvcCore.Controllers
{
    public class SalesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var salesVm = new SalesViewModel
            {
                Categories = CategoryRepository.GetCategories()
            };
            return View(salesVm);
        }


        public IActionResult SellProductPartial(int productId)
        {
            var product = ProductsRepository.GetProductById(productId);

            return PartialView("_SellProduct", product);


        }
      
        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            if(ModelState.IsValid)
            {
                var prod = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);
                if(prod !=null)
                {
                    TransactionsRepository.Add("Cashier1"
                        , salesViewModel.SelectedProductId,
                        prod.Name,
                        prod.Price.HasValue ? prod.Price.Value : 0,
                        prod.Quantity.HasValue ? prod.Quantity.Value : 0,
                        salesViewModel.QuantityToSell);

                    prod.Quantity -= salesViewModel.QuantityToSell;
                    ProductsRepository.UpdateProduct(salesViewModel.SelectedProductId, prod);


                }
            }
            var product = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);
            salesViewModel.SelectedCategoryId = (product?.CategoryId is null) ? 0 : product.CategoryId.Value;
            salesViewModel.Categories = CategoryRepository.GetCategories();
            return View("Index", salesViewModel);
        }
    }
}

