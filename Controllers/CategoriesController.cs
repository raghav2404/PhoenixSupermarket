using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoMvcCore.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demoMvcCore.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = CategoryRepository.GetCategories();
            return View(categories);

        }

        [HttpGet]
        public IActionResult Edit([FromRoute]int? id)
        {

            ViewBag.OnClick = "edit";
            var category = CategoryRepository.GetCategoryById(id ?? 0);
            return View(category);


        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoryRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }


        public IActionResult Add()
        {
            //ViewData["OnClick"] = "add";
            ViewBag.OnClick = "add";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if(ModelState.IsValid)
            {
                CategoryRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));

            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int categoryId)
        {
            CategoryRepository.DeleteCategory(categoryId);
            return RedirectToAction(nameof(Index));
        }

    }
}

