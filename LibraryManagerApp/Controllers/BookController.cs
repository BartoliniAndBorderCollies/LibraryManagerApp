using LibraryManagerApp.Exceptions;
using LibraryManagerApp.Models;
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
            var categories = await _categoryService.GetAllAsync();

            var viewModel = new BookIndexViewModel
            {
                Books = books.ToList(),
                Categories = categories.ToList()
            };


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Book book)
        {

            await _bookService.AddAsync(book);
            return RedirectToAction("Index");

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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Book book)
        {

            try
            {
                // BookId przychodzi z formularza z ukrytego inputa w Index.cshtml
                await _bookService.UpdateAsync(book.BookId, book);
                return RedirectToAction("Index"); 
                //bo model w Book/Index.cshtml oczekuje BookIndexViewModel, który ma w sobie listę ksiazek,
                //dlatego wracam do tej listy odswiezajac ją - robię kolejnego GET poprzez RedirectToAction,
                //a nie np zwracam widok tej edytowanej Ksiazki (jak w AuthorController)

            }
            catch (NotFoundInDatabaseException ex)
            {

                TempData["Error"] = ex.Message;
                return RedirectToAction("Index"); //robię RedirectToAction żeby pobrac świeze dane i wracam do Index

            }
        }
    }
}
