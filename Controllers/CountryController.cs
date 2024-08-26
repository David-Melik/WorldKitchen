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
    public class CountryController : Controller
    {


        private readonly ApplicationDbContext _context;

        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }
        //--------
        public async Task<IActionResult> Index(string searchString)
        {
            var countries = from m in _context.Country
                            select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                countries = countries.Where(n => n.Country.Contains(searchString) || n.Description.Contains(searchString));
            }

            return View(await countries.ToListAsync());
        }

        //--------

        // GET: Country/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var databaseWorldKitchenCountry = await _context.Country
                .FirstOrDefaultAsync(m => m.Id == id);
            if (databaseWorldKitchenCountry == null)
            {
                return NotFound();
            }

            return View(databaseWorldKitchenCountry);
        }

        // GET: Country/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Country/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Country,Flag,Map,Description")] DatabaseWorldKitchenCountry databaseWorldKitchenCountry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(databaseWorldKitchenCountry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(databaseWorldKitchenCountry);
        }

        // GET: Country/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var databaseWorldKitchenCountry = await _context.Country.FindAsync(id);
            if (databaseWorldKitchenCountry == null)
            {
                return NotFound();
            }
            return View(databaseWorldKitchenCountry);
        }

        // POST: Country/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Country,Flag,Map,Description")] DatabaseWorldKitchenCountry databaseWorldKitchenCountry)
        {
            if (id != databaseWorldKitchenCountry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(databaseWorldKitchenCountry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatabaseWorldKitchenCountryExists(databaseWorldKitchenCountry.Id))
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
            return View(databaseWorldKitchenCountry);
        }

        // GET: Country/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var databaseWorldKitchenCountry = await _context.Country
                .FirstOrDefaultAsync(m => m.Id == id);
            if (databaseWorldKitchenCountry == null)
            {
                return NotFound();
            }

            return View(databaseWorldKitchenCountry);
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var databaseWorldKitchenCountry = await _context.Country.FindAsync(id);
            if (databaseWorldKitchenCountry != null)
            {
                _context.Country.Remove(databaseWorldKitchenCountry);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatabaseWorldKitchenCountryExists(int id)
        {
            return _context.Country.Any(e => e.Id == id);
        }






    }
}
