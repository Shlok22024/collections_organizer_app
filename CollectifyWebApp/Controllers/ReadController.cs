using Microsoft.AspNetCore.Mvc;

namespace CollectifyWebApp.Controllers
{
    public class ReadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
