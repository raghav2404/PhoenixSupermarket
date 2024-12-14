
using CoreBusiness;
using demoMvcCore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UseCases.CategoriesUseCase;
using UseCases.ProductsUseCase;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demoMvcCore.Controllers
{
    [Authorize(Policy = "Inventory")]
    public class ProductsController : Controller
    {
        // GET: /<controller>/

        private readonly IAddProductUseCase addProductUseCase;
        private readonly IEditProductUseCase editProductUseCase;
        private readonly IDeleteProductUseCase deleteProductUseCase;
        private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;
        private readonly IViewProductsUseCase viewProductsUseCase;
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IViewProductsInCategoryUseCase viewProductsInCategoryUseCase;


        public ProductsController(
            IAddProductUseCase addProductUseCase,
            IEditProductUseCase editProductUseCase,
            IDeleteProductUseCase deleteProductUseCase,
            IViewSelectedProductUseCase viewSelectedProductUseCase,
            IViewProductsUseCase viewProductsUseCase,
            IViewCategoriesUseCase viewCategoriesUseCase,
            IViewProductsInCategoryUseCase viewProductsInCategoryUseCase)
        {


            this.addProductUseCase = addProductUseCase;
            this.editProductUseCase = editProductUseCase;
            this.deleteProductUseCase = deleteProductUseCase;
            this.viewSelectedProductUseCase = viewSelectedProductUseCase;
            this.viewProductsUseCase = viewProductsUseCase;
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.viewProductsInCategoryUseCase = viewProductsInCategoryUseCase;

        }
        public IActionResult Index()
        {
            var products = viewProductsUseCase.Execute(loadCategory: true);
            return View(products);

        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";
            var productViewModels = new ProductsViewModel
            {
                Categories = viewCategoriesUseCase.Execute()
               
            };
            return View(productViewModels);
           

        }

        [HttpPost]
        public IActionResult Add(ProductsViewModel productsViewModel)
        { 
            if (ModelState.IsValid)
            {
                addProductUseCase.Execute(productsViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "edit";
            productsViewModel.Categories = viewCategoriesUseCase.Execute();
            return View(productsViewModel);
        }

       
       
        
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";
            var productView = new ProductsViewModel
            {
                Product = viewSelectedProductUseCase.Execute(id) ?? new Product(),
                Categories = viewCategoriesUseCase.Execute()
            };
            return View(productView);
        }

        [HttpPost]
        
        public IActionResult Edit(ProductsViewModel productsViewModel)
        {
            if (ModelState.IsValid)
            {
                editProductUseCase.Execute(productsViewModel.Product.ProductId, productsViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "edit";
            productsViewModel.Categories = viewCategoriesUseCase.Execute();
            return View(productsViewModel);
        }

        
        public IActionResult Delete(int id)
        {
            deleteProductUseCase.Execute(id);
            return RedirectToAction(nameof(Index));
        }

        

    }
}

