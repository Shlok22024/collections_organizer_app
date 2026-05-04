using CollectifyWebApp.Models;
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

        public async Task<IActionResult> ApiSearch(string cardName)
        {
            if (string.IsNullOrEmpty(cardName)) return View(new List<PokemonResult>());

            using var client = new HttpClient();
            // 1. Ask the API for cards with that name
            var response = await client.GetFromJsonAsync<List<PokemonResult>>($"https://api.tcgdex.net/v2/en/cards?name={cardName}");

            // 2. Send that list to a search results page
            return View(response);
        }
    }
}
