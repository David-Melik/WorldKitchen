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

    public IActionResult checkUrl(string country, string path, bool state)
    {
        if ((path.EndsWith(country) || path.EndsWith(country + "/")) || state)
        {   //for home,search,error Pages
            if (state)
            {
                var tablesAll = new BigViewModel
                {
                    CountryTable = _context.Country,
                    DishiesTable = _context.Dishies
                };
                return View(tablesAll);
            }

            //for Country Pages
            string capatalizeCountry = CapitalizeFirstLetter(country);
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
        else
        // for Dish
        {
            var DishiesTableElement = new BigViewModel
            {
                DishiesTable = _context.Dishies.ToList()  // Populate the DishiesTable with data from the database
            };

            // Now, loop through the DishiesTable property, not the view model itself
            foreach (var itemD in DishiesTableElement.DishiesTable)
            {
                string dishRenamed = itemD.Name.Replace(" ", "").ToLower();
                var urlDish = $"{country}/{dishRenamed}".ToLower();

                if (path.Contains(dishRenamed.ToLower()) && path.EndsWith(urlDish))
                {
                    var tables = new BigViewModel
                    {
                        DishiesTable = _context.Dishies
                                       .Where(d => d.Name.Equals(itemD.Name))
                                       .ToList()
                    };
                    return View(urlDish, tables);
                }

            }


        }
        return View("Errors");
    }

    public IActionResult Index()
    {
        string country = ("");
        string path = "";
        bool state = true;
        return checkUrl(country, path, state);
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
        string path = Request.Path.ToString().ToLower();
        bool state = true;
        return checkUrl(country, path, state);
    }

    // Constructor to initialize DbContext


    // Action to display dishes related to France
    public IActionResult France()
    {

        string country = ("france");
        string path = Request.Path.ToString().ToLower();
        bool state = false;
        return checkUrl(country, path, state);
        //var countries = _context.Country.ToList(); // Or whatever logic you use to get the list
        //return View(countries); // Ensure the view receives an IEnumerable<DatabaseWorldKitchenCountry>

    }


    public IActionResult Armenia()
    {
        var country = ("armenia");
        var path = Request.Path.ToString().ToLower();
        bool state = false;
        return checkUrl(country, path, state);

    }

    public IActionResult Algeria()
    {
        var country = ("algeria");
        var path = Request.Path.ToString().ToLower();
        bool state = false;
        return checkUrl(country, path, state);

    }


}
