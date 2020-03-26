using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BACSchedulingSystem.Models
{
    public class IngredientTypeViewModel
    {
        public List<Ingredient> Ingredients { get; set; }
        public SelectList types { get; set; }
        public IngredientType ingredientType { get; set; }
        public string SearchString { get; set; }
    }
}