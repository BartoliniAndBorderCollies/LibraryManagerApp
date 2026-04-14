using LibraryManagerApp.Exceptions;
using LibraryManagerApp.Models.ViewModels;
using LibraryManagerApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerApp.Controllers
{
    public class BookController : Controller
    {

        private readonly BookService _bookService;
        private readonly CategoryService _categoryService;

        public BookController(BookService bookService, CategoryService categoryService)
        {
            this._bookService = bookService;
            this._categoryService = categoryService;
        }


        public async Task<IActionResult> Index()
        {

            var books = await _bookService.GetAllAsync();

            var viewModel = new BookIndexViewModel
            {
                Books = books.ToList()
            };


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _bookService.DeleteAsync(id);
                return RedirectToAction("Index");

            }
            catch (NotFoundInDatabaseException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Error");
            }

        }

        //metoda do określenia, który book id bedziemy edytować

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var books = await _bookService.GetAllAsync();
            var categories = await _categoryService.GetAllAsync();


            var viewModel = new BookIndexViewModel
            {
                Books = books.ToList(),
                EditingBookId = id,
                Categories = categories.ToList()

            };

            return View("Index", viewModel);
        }
    }
}
