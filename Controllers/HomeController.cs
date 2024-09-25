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
    public string CapitalizeFirstLetter(string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        return char.ToUpper(str[0]) + str.Substring(1).ToLower();
    }

    public IActionResult checkUrl(string dishies, string country, string path, bool state)
    {
        if ((path.EndsWith(country) || path.EndsWith(country + "/")) || state)
        {
            if (state)
            {
                var tablesAll = new BigViewModel
                {
                    CountryTable = _context.Country,
                    DishiesTable = _context.Dishies

                };
                return View(tablesAll);
            }

            string capatalizeCountry = CapitalizeFirstLetter(country); //to be ready to use for combine the two model

            var tables = new BigViewModel
            {

                // Filter CountryTable by the 'Country' field (which contains country names like 'France')
                CountryTable = _context.Country
                .Where(c => c.Country.Equals(capatalizeCountry))
                .ToList(),

                // Filter DishiesTable by the 'Country' field (assuming 'Country' is the field in Dishies as well)
                DishiesTable = _context.Dishies
                .Where(d => d.Country.Equals(capatalizeCountry))
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
        string country = ("");
        string dishies = ""; //Put the dishies you have
        string path = Request.Path.ToString().ToLower();
        bool state = true;
        return checkUrl(dishies, country, path, state);
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
    [Route("error/404")]  // To remove /Home/Privacy
    public IActionResult Errors()
    {
        string country = ("");
        string dishies = ""; //Put the dishies you have
        string path = Request.Path.ToString().ToLower();
        bool state = true;
        return checkUrl(dishies, country, path, state);
    }

    // Constructor to initialize DbContext


    // Action to display dishes related to France
    public IActionResult France()
    {

        string country = ("france");
        string dishies = "hachisparmentier,pomme,poire"; //Put the dishies you have
        string path = Request.Path.ToString().ToLower();
        bool state = false;
        return checkUrl(dishies, country, path, state);
        //var countries = _context.Country.ToList(); // Or whatever logic you use to get the list
        //return View(countries); // Ensure the view receives an IEnumerable<DatabaseWorldKitchenCountry>

    }


    public IActionResult Armenia()
    {
        var country = ("armenia");
        var path = Request.Path.ToString().ToLower();
        var dishies = "hachisparmentier,pomme,poire";  //Put the dishies you have
        bool state = false;
        return checkUrl(dishies, country, path, state);

    }

    public IActionResult Egypt()
    {
        var country = ("egypt");
        var path = Request.Path.ToString().ToLower();
        var dishies = "hachisparmentier,pomme,poire";  //Put the dishies you have
        bool state = false;
        return checkUrl(dishies, country, path, state);

    }


}
