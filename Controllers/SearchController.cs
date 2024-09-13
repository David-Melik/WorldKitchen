using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldKitchen.Data;
using WorldKitchen.Models;

namespace WorldKitchen.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            // Start with the LINQ query to select from the Dishies table
            var dishies = from d in _context.Dishies
                          select d;

            // Apply the search filter to both Country and Name fields in the Dishies table
            if (!string.IsNullOrEmpty(searchString))
            {
                dishies = dishies.Where(d => d.Country.Contains(searchString) || d.Name.Contains(searchString));
            }

            // Pass the current filter to the ViewData dictionary
            ViewData["CurrentFilter"] = searchString;

            // Return the view with the list of filtered results
            return View(await dishies.ToListAsync());
        }
    }
}

