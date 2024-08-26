using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldKitchen.Data;
using WorldKitchen.Models;
using WorldKitchen.Helpers; // Add this line to use the extension method

namespace WorldKitchen.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var dishies = from m in _context.Dishies
                          select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                // Use the extension method to capitalize the first letter
                searchString = searchString.FirstCharToUpper();

                // Use case-insensitive comparison
                dishies = dishies.Where(n =>
                    EF.Functions.Like(n.Country, $"%{searchString}%") ||
                    EF.Functions.Like(n.Name, $"%{searchString}%"));
            }

            return View(await dishies.ToListAsync());
        }
    }
}

