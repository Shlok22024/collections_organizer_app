using Microsoft.AspNetCore.Mvc;

namespace CollectifyWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
