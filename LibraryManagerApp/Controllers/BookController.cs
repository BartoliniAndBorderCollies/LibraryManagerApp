using LibraryManagerApp.Exceptions;
using LibraryManagerApp.Models.ViewModels;
using LibraryManagerApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerApp.Controllers
{
    public class BookController : Controller
    {

        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            this._bookService = bookService;
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

            var viewModel = new BookIndexViewModel
            {
                Books = books.ToList(),
                EditingBookId = id
            };

            return View("Index", viewModel);
        }
    }
}
