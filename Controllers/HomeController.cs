using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();

    }

    public IActionResult France()
    {
        string country = ("france");
        string dishies = "hachisparmentier,pomme,poire"; //Put the dishies you have
        string path = Request.Path.ToString().ToLower();

        return checkUrl(dishies, country, path);
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
