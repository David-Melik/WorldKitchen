using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorldKitchen.Models
{
    public class DatabaseWorldKitchenDish
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
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

        // Changed to List<string>? and initialized to an empty list in the constructor
        public List<string> AllergnList { get; set; }
        public List<string> IngredientList { get; set; }
        public List<string> StepList { get; set; }
        public List<string> NutritionList { get; set; }

        // Constructor to initialize lists
        public DatabaseWorldKitchenDish()
        {
            AllergnList = new List<string>();
            IngredientList = new List<string>();
            StepList = new List<string>();
            NutritionList = new List<string>();
        }
    }
}

