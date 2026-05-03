using Microsoft.AspNetCore.Mvc;

namespace CollectifyWebApp.Controllers
{
    public class ItemsController : Controller
    {
        // Read acts as Index
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        // Edit acts as Update
        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete ()
        {
            return View();
        }
    }
}
