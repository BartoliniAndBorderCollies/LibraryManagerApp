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


        public async Task<IActionResult> Index()
        {
            var readers = await _readerService.GetAllAsync();

            ReaderIndexViewModel viewModel = new ReaderIndexViewModel
            {
                Readers = readers.ToList()
            };

            return View(viewModel);
        }
    }
}
