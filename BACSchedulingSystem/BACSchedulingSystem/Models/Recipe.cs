using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACSchedulingSystem.Models
{

    public class Recipe
    {
        [Key]
        public string Name { get; set; }

        public List<Ingredient> IngredientList { get; set; }

        [Display(Name = "Cooking Instructions")]
        public string CookingInstructions { get; set; }

        [Display(Name = "Gluten Free")]
        public bool GlutenFree { get; set; }

        public bool Vegetarian { get; set; }

        public bool Vegan { get; set; }

        public bool Active { get; set; }
    }
}
