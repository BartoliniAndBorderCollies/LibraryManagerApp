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
    }
}
