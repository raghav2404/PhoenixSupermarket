using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using demoMvcCore.Models;
using demoMvcCore.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demoMvcCore.Controllers
{
    public class ProductsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = ProductsRepository.GetProducts(loadCategory:true);
            return View(products);

        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";
            var productViewModels = new ProductsViewModel
            {
                Categories = CategoryRepository.GetCategories(),
                //Product
            };
            return View(productViewModels);
           

        }

        [HttpPost]
        public IActionResult Add(ProductsViewModel productsViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.AddProduct(productsViewModel.Product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "edit";
            productsViewModel.Categories = CategoryRepository.GetCategories();
            return View(productsViewModel);
        }

       
       
        
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";
            var productView = new ProductsViewModel
            {
                Product = ProductsRepository.GetProductById(id) ?? new Product(),
                Categories = CategoryRepository.GetCategories()
            };
            return View(productView);
        }

        [HttpPost]
        
        public IActionResult Edit(ProductsViewModel productsViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductsRepository.UpdateProduct(productsViewModel.Product.ProductId, productsViewModel.Product);

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "edit";
            productsViewModel.Categories = CategoryRepository.GetCategories();
            return View(productsViewModel);
        }

        
        public IActionResult Delete(int id)
        {
            ProductsRepository.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }





    }
}

