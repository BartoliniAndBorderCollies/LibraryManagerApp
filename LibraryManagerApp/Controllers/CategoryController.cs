using LibraryManagerApp.Models;
using LibraryManagerApp.Models.ViewModels;
using LibraryManagerApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerApp.Controllers
{
    public class CategoryController : Controller
    {

        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Category category)
        {

            await _categoryService.AddAsync(category);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var categories = await _categoryService.GetAllAsync();

            CategoryIndexViewModel viewModel = new CategoryIndexViewModel
            {
                Categories = categories.ToList()
            };

            return View(viewModel);
        }
    }
}
