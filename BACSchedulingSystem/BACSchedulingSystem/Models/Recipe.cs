using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACSchedulingSystem.Models
{

    public class Recipe
    {
        [Key]
        public string name { get; set; }

        public List<Ingredient> ingredientList { get; set; }

        public string cookingInstructions { get; set; }

        public bool glutenFree { get; set; }

        public bool vegetarian { get; set; }

        public bool vegan { get; set; }
    }
}
