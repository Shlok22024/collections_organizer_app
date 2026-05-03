using Microsoft.AspNetCore.Mvc;

namespace CollectifyWebApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
