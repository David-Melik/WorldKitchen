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

        public async Task<IActionResult> Index(string searchString)
        {

            // Step 1: Filter and populate the DishTable within the BigViewModel
            var tables = new BigViewModel
            {
                DishTable = await _context.Dish
                    .Where(d => string.IsNullOrEmpty(searchString) ||
                                 d.Country.ToLower().Contains(searchString.ToLower()) ||
                                 d.Name.ToLower().Contains(searchString.ToLower()))
                    .ToListAsync() // Step 2: Execute the query asynchronously
            };

            // Step 3: Return the View with the ViewModel
            return View(tables);
        }
    }
}

