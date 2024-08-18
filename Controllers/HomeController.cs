using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WorldKitchen.Models;

namespace WorldKitchen.Controllers;

public class HomeController : Controller
{
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

        var country = ("france");
        var path = Request.Path.ToString().ToLower();

        if (path.EndsWith(country) || path.EndsWith(country + "/"))
        {

            return View(new CountryViewModel { Country = "HEY" });
        }

        var dishies = "hachisparmentier,pomme,poire"; //Put the dishies you have
        var dishArray = dishies.Split(',');
        for (int i = 0; i < dishArray.Length; i++)
        {
            var currentDish = dishArray[i];
            var urlDishies = $"{country}/{currentDish}".ToLower();

            if (path.Contains(currentDish.ToLower()) && path.EndsWith(urlDishies))
            {
                return View($"{country}/{currentDish}");
            }
        }
        return View("Errors");
    }


    public IActionResult Armenia()
    {
        var country = ("armenia");
        var path = Request.Path.ToString().ToLower();

        if (path.EndsWith(country) || path.EndsWith(country + "/"))
        {
            return View(new CountryViewModel { Country = "Armenie" });

        }

        var dishies = "hachisparmentier,pomme,cactus"; //Put the dishies you have
        var dishArray = dishies.Split(',');
        for (int i = 0; i < dishArray.Length; i++)
        {
            var currentDish = dishArray[i];
            var urlDishies = $"{country}/{currentDish}".ToLower();

            if (path.Contains(currentDish.ToLower()) && path.EndsWith(urlDishies))
            {
                return View($"{country}/{currentDish}");
            }
        }
        return View("Errors");
    }

    public IActionResult Egypt()
    {
        var country = ("egypt");
        var path = Request.Path.ToString().ToLower();

        if (path.EndsWith(country) || path.EndsWith(country + "/"))
        {
            return View();
        }

        var dishies = "hachisparmentier,pomme,poire";  //Put the dishies you have
        var dishArray = dishies.Split(',');
        for (int i = 0; i < dishArray.Length; i++)
        {
            var currentDish = dishArray[i];
            var urlDishies = $"{country}/{currentDish}".ToLower();

            if (path.Contains(currentDish.ToLower()) && path.EndsWith(urlDishies))
            {
                return View($"{country}/{currentDish}");
            }
        }
        return View("Errors");
    }

    [Route("error/404")]  // To remove /Home/Privacy
    public IActionResult Errors()
    {
        return View();
    }
}
