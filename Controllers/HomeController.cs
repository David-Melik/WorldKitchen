using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorldKitchen.Data;
using WorldKitchen.Models;
using System.Data;
using System.Net;
using WorldKitchen.Models;

namespace WorldKitchen.Controllers;

public class HomeController : Controller
{


    private readonly ApplicationDbContext _context;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }




    // Function
    public IActionResult checkUrl(string dishies, string country, string path)
    {
        if (path.EndsWith(country) || path.EndsWith(country + "/"))
        {
            var tables = new BigViewModel
            {
                // Filter CountryTable by the 'Country' field (which contains country names like 'France')
                CountryTable = _context.Country
                .Where(c => c.Country.Equals("France"))
                .ToList(),

                // Filter DishiesTable by the 'Country' field (assuming 'Country' is the field in Dishies as well)
                DishiesTable = _context.Dishies
                .Where(d => d.Country.Equals("France"))
                .ToList()
            };
            return View(tables);
        }

        // The rest of your logic...
        var dishArray = dishies.Split(',');

        for (int i = 0; i < dishArray.Length; i++)
        {
            var currentDish = dishArray[i];
            var urlDishies = $"{country}/{currentDish}".ToLower();

            if (path.Contains(currentDish.ToLower()) && path.EndsWith(urlDishies))
            {
                return View("Dishes", urlDishies); // Update to your dishes view if needed
            }
        }

        return View("Errors");
    }

    public IActionResult Index()
    {
        var frenchDishes = _context.Dishies
                                    .Where(d => d.Country == "France") // Filter for France
                                    .ToList(); // Convert to list for use in the view

        // Pass the list of French dishes to the view
        return View(frenchDishes);
    }
    public IActionResult Country()
    {
        return RedirectToAction("Index", "Country");
    }
    public IActionResult Dishies()
    {
        return RedirectToAction("Index", "Dishies");
    }
    public IActionResult Search()
    {
        return RedirectToAction("Index", "Search");
    }

    // Constructor to initialize DbContext


    // Action to display dishes related to France
    public IActionResult France()
    {

        string country = ("france");
        string dishies = "hachisparmentier,pomme,poire"; //Put the dishies you have
        string path = Request.Path.ToString().ToLower();

        return checkUrl(dishies, country, path);
        //var countries = _context.Country.ToList(); // Or whatever logic you use to get the list
        //return View(countries); // Ensure the view receives an IEnumerable<DatabaseWorldKitchenCountry>

    }


    public IActionResult Armenia()
    {
        var country = ("armenia");
        var path = Request.Path.ToString().ToLower();
        var dishies = "hachisparmentier,pomme,poire";  //Put the dishies you have
        return checkUrl(dishies, country, path);

    }

    public IActionResult Egypt()
    {
        var country = ("egypt");
        var path = Request.Path.ToString().ToLower();
        var dishies = "hachisparmentier,pomme,poire";  //Put the dishies you have
        return checkUrl(dishies, country, path);

    }

    [Route("error/404")]  // To remove /Home/Privacy
    public IActionResult Errors()
    {
        return View();
    }
}
