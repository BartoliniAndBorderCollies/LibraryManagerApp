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
        private readonly AuthorService AuthorService;

        public AuthorController(AuthorService authorService)
        {
            this.AuthorService = authorService;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await AuthorService.GetAllAsync();

            var viewModel = new AuthorIndexViewModel
            {
                Authors = authors.ToList(),
                NewAuthor = new Author()
            };

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Add(Author entity)
        {
            await AuthorService.AddAsync(entity);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> DeleteAll()
        {
            await AuthorService.DeleteAllAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await AuthorService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch(NotFoundInDatabaseException ex)
            {

                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");

            }

        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {

            try
            {
                Author author = await AuthorService.GetByIdAsync(id);
                return View("Details", author);

            }
            catch (NotFoundInDatabaseException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, Author entity)
        {

            try
            {
                Author updatedAuthor = await AuthorService.UpdateAsync(id, entity);
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
