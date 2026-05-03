using Microsoft.AspNetCore.Mvc;

namespace CollectifyWebApp.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
