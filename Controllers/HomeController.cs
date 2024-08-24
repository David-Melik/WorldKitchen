using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorldKitchen.Data;
using WorldKitchen.Models;

namespace WorldKitchen.Controllers;

public class HomeController : Controller
{


    // Function
    public IActionResult checkUrl(string dishies, string country, string path)
    {
        if (path.EndsWith(country) || path.EndsWith(country + "/"))
        {
            return View(country);
        }
        var dishArray = dishies.Split(',');

        for (int i = 0; i < dishArray.Length; i++)
        {
            var currentDish = dishArray[i];
            var urlDishies = $"{country}/{currentDish}".ToLower();

            if (path.Contains(currentDish.ToLower()) && path.EndsWith(urlDishies))
            {
                return View(urlDishies);
            }
        }

        return View("Errors");
    }

    // EndFunction
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Country()
    {
        return RedirectToAction("Index", "Country");
    }
    public IActionResult Dishies()
    {
        return RedirectToAction("Index", "Dishies");
    }
    private readonly ApplicationDbContext _context;

    // Constructor to initialize DbContext


    // Action to display dishes related to France
    public IActionResult France()
    {
        // Fetch dishes related to France
        var frenchDishes = _context.Dishies
                                   .Where(d => d.Country == "France") // Filter for France
                                   .ToList(); // Convert to list for use in the view

        // Pass the list of French dishes to the view
        return View(frenchDishes);
    }
    //public IActionResult France()
    //{
    //    // try to put the sql data


    //    // try to put the sql data
    //    string country = ("france");
    //    string dishies = "hachisparmentier,pomme,poire"; //Put the dishies you have
    //    string path = Request.Path.ToString().ToLower();

    //    return checkUrl(dishies, country, path);
    //}


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
