using LibraryManagerApp.Exceptions;
using LibraryManagerApp.Models;
using LibraryManagerApp.Models.ViewModels;
using LibraryManagerApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            this._authorService = authorService;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAllAsync();

            var viewModel = new AuthorIndexViewModel
            {
                Authors = authors.ToList(),
                NewAuthor = new Author()
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Author entity)
        {
            await _authorService.AddAsync(entity);
            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAll()
        {
            await _authorService.DeleteAllAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _authorService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (NotFoundInDatabaseException ex)
            {

                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");

            }

        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, bool editMode = false)
        {

            ViewBag.EditMode = editMode;

            try
            {
                Author author = await _authorService.GetByIdAsync(id);
                return View("Details", author);

            }
            catch (NotFoundInDatabaseException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, Author entity)
        {

            try
            {
                Author updatedAuthor = await _authorService.UpdateAsync(id, entity);
                return View("Details", updatedAuthor);

            }
            catch (NotFoundInDatabaseException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
