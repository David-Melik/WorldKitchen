using Microsoft.AspNetCore.Mvc;

namespace WorldKitchen.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/");
        }

        // Handles requests to /country/france
        public IActionResult France()
        {
            // Check if the current URL contains "HachisParmentier"
            if (Request.Path.ToString().ToLower().Contains("hachisparmentier"))
            {
                // Render the HachisParmentier.cshtml view
                return View("France/HachisParmentier");
            }

            // Return the default France.cshtml view
            return View();
        }

        // Handles requests to /country/armenia
        public IActionResult Armenia()
        {
            return View();
        }

        // Handles requests to /country/egypt
        public IActionResult Egypt()
        {
            return View();
        }
    }
}

