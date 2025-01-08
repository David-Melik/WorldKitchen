using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WorldKitchen.Data;
using WorldKitchen.Models;
using System.Net;

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
        // Initialize the list of countries
        List<string> countrylist = new List<string> { "france", "algeria", "armenia" };

        // Iterate over the country list and check if the path contains any of the countries
        foreach (var c in countrylist)
        {
            if (path.Contains(c.ToLower()))
            {
                country = c;  // Set the country if a match is found
                break; // Exit the loop once a match is found
            }
        }
        if ((path.EndsWith(country) || path.EndsWith(country + "/")) || state)
        {   //for home,search,error Pages
            if (state)
            {
                var tablesAll = new BigViewModel
                {
                    CountryTable = _context.Country,
                    DishTable = _context.Dish
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

                // Filter DishTable by the 'Country' field (assuming 'Country' is the field in Dish as well)
                DishTable = _context.Dish
                .Where(d => d.Country.Equals(capatalizeCountry))
                .ToList()
            };
            return View(tables);
        }
        else
        // for Dish

        {
            var DishTableElement = new BigViewModel
            {
                DishTable = _context.Dish.ToList()  // Populate the DishTable with data from the database
            };

            // Now, loop through the DishTable property, not the view model itself
            foreach (var itemD in DishTableElement.DishTable)
            {
                string dishRenamed = itemD.Name.Replace(" ", "").ToLower();
                var urlDish = $"{country}/{dishRenamed}".ToLower();

                if (path.Contains(dishRenamed.ToLower()) && path.EndsWith(urlDish))
                {
                    var tables = new BigViewModel
                    {
                        DishTable = _context.Dish
                                       .Where(d => d.Name.Equals(itemD.Name))
                                       .ToList()

                    };
                    var tablesAll = new BigViewModel
                    {
                        DishTable = _context.Dish
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
        string country = "";
        string path = "";
        bool state = true;
        return checkUrl(country, path, state);
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
