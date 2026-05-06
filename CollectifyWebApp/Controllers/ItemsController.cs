using CollectifyWebApp.Data;
using CollectifyWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollectifyWebApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ - List all items
        public async Task<IActionResult> Index()
        {
            var items = await _context.Items.ToListAsync();
            return View(items);
        }

        // CREATE - Show form
        public IActionResult Create(string? name, string? set, string? rarity, string? image, decimal? price)
        {
            ViewBag.Name = name;
            ViewBag.Set = set;
            ViewBag.Rarity = rarity;
            ViewBag.Image = image;
            ViewBag.Price = price;
            return View();
        }

        // CREATE - Handle form submission
        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            if (ModelState.IsValid)
            {
                item.DateAdded = DateTime.Now;
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // EDIT - Show form
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // EDIT - Handle form submission
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Item item)
        {
            if (id != item.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Items.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // DELETE - Show confirmation
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        // DELETE - Handle confirmation
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // API SEARCH
        public async Task<IActionResult> ApiSearch(string cardName)
        {
            if (string.IsNullOrEmpty(cardName)) return View(new List<PokemonResult>());
            using var client = new HttpClient();
            var response = await client.GetFromJsonAsync<List<PokemonResult>>($"https://api.tcgdex.net/v2/en/cards?name={cardName}");
            return View(response);
        }

        // CARD DETAIL
        public async Task<IActionResult> CardDetail(string cardId)
        {
            using var client = new HttpClient();
            var card = await client.GetFromJsonAsync<PokemonResult>($"https://api.tcgdex.net/v2/en/cards/{cardId}");
            return View(card);
        }
    }
}