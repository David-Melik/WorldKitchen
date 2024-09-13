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
            var dishies = from m in _context.Dishies
                          select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                dishies = dishies.Where(n => n.Country.ToLower().Contains(searchString) || n.Name.ToLower().Contains(searchString));
            }
            return View(await dishies.ToListAsync());
        }
    }
}

