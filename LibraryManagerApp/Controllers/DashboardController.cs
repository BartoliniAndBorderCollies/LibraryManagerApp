using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
