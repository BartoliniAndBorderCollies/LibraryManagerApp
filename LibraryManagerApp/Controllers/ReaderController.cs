using LibraryManagerApp.Exceptions;
using LibraryManagerApp.Models;
using LibraryManagerApp.Models.ViewModels;
using LibraryManagerApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerApp.Controllers
{
    public class ReaderController : Controller
    {

        private readonly ReaderService _readerService;

        public ReaderController(ReaderService readerService)
        {
            _readerService = readerService;
        }


        public async Task<IActionResult> Index(int? editingReaderId)
        {
            var readers = await _readerService.GetAllAsync();

            ReaderIndexViewModel viewModel = new ReaderIndexViewModel
            {
                Readers = readers.ToList(),
                EditingReaderId = editingReaderId

            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Reader reader)
        {

            await _readerService.AddAsync(reader);

            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _readerService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (NotFoundInDatabaseException ex)
            {

                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");

            }
        }
    }
}
