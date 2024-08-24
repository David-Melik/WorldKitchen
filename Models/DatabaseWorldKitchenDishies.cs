// Models/DatabaseWorldKitchenDishies.cs
using System.ComponentModel.DataAnnotations;

namespace WorldKitchen.Models
{
    public class DatabaseWorldKitchenDishies
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string? Traduction { get; set; }
        public string? VoiceName { get; set; }
        public string? ImagePreview { get; set; }
        public int? Time { get; set; }
        public string? Video { get; set; }
        public string? Svg1 { get; set; }
        public string? Svg2 { get; set; }
        public string? Svg3 { get; set; }
        public bool Allergen { get; set; }
        public string? AllergnList { get; set; }
        public string? IngredientList { get; set; }
        public string? StepList { get; set; }
        public string? Nutrition { get; set; }
    }
}

