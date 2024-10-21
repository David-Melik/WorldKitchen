// Models/DatabaseWorldKitchenCountry.cs
using System.ComponentModel.DataAnnotations;

namespace WorldKitchen.Models
{
    public class DatabaseWorldKitchenCountry
    {
        [Key]
        public int Id { get; set; }
        public string Country { get; set; }
        public string? Background { get; set; }
        public string? Flag { get; set; }
        public string? Map { get; set; }
        public string? Description { get; set; }
    }
}

