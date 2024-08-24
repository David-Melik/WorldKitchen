using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorldKitchen.Data;
using WorldKitchen.Models;

namespace WorldKitchen.Controllers
{
    public class DishiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DishiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var dishies = from m in _context.Dishies
                          select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                dishies = dishies.Where(n => n.Country.Contains(searchString) || n.Name.Contains(searchString));
            }

            return View(await dishies.ToListAsync());
        }


        // GET: Dishies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var databaseWorldKitchenDishies = await _context.Dishies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (databaseWorldKitchenDishies == null)
            {
                return NotFound();
            }

            return View(databaseWorldKitchenDishies);
        }

        // GET: Dishies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dishies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Country,Traduction,VoiceName,ImagePreview,Time,Video,Svg1,Svg2,Svg3,Allergen,AllergnList,IngredientList,StepList,Nutrition")] DatabaseWorldKitchenDishies databaseWorldKitchenDishies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(databaseWorldKitchenDishies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(databaseWorldKitchenDishies);
        }

        // GET: Dishies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var databaseWorldKitchenDishies = await _context.Dishies.FindAsync(id);
            if (databaseWorldKitchenDishies == null)
            {
                return NotFound();
            }
            return View(databaseWorldKitchenDishies);
        }

        // POST: Dishies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Country,Traduction,VoiceName,ImagePreview,Time,Video,Svg1,Svg2,Svg3,Allergen,AllergnList,IngredientList,StepList,Nutrition")] DatabaseWorldKitchenDishies databaseWorldKitchenDishies)
        {
            if (id != databaseWorldKitchenDishies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(databaseWorldKitchenDishies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatabaseWorldKitchenDishiesExists(databaseWorldKitchenDishies.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(databaseWorldKitchenDishies);
        }

        // GET: Dishies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var databaseWorldKitchenDishies = await _context.Dishies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (databaseWorldKitchenDishies == null)
            {
                return NotFound();
            }

            return View(databaseWorldKitchenDishies);
        }

        // POST: Dishies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var databaseWorldKitchenDishies = await _context.Dishies.FindAsync(id);
            if (databaseWorldKitchenDishies != null)
            {
                _context.Dishies.Remove(databaseWorldKitchenDishies);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatabaseWorldKitchenDishiesExists(int id)
        {
            return _context.Dishies.Any(e => e.Id == id);
        }
    }
}
