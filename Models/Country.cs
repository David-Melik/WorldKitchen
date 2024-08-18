using System.ComponentModel.DataAnnotations;

namespace RazorPagesCountry.Models;

public class Country
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? BackgroundImage { get; set; } //we give the location
    public string? Flag { get; set; }
    public string? Map { get; set; }
    public string? Description { get; set; }

}

// dotnet aspnet-codegenerator razorpage -m Country -dc RazorPagesCountry.Data.RazorPagesCountryContext -udl -outDir Pages/Country --referenceScriptLibraries --databaseProvider sqlite
