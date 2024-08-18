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
    [Route("Privacy")]  // To remove /Home/Privacy
    public IActionResult Privacy()
    {
        return View();
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // [Route("Errors")]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
    [Route("error/404")]  // To remove /Home/Privacy
    public IActionResult Errors()
    {
        return View();
    }
}
