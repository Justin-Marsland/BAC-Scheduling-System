using System;
using System.ComponentModel.DataAnnotations;


namespace BACSchedulingSystem.Models
{
    public enum IngredientType
    {
        Meat,
        Fruit,
        Vegetable,
        Grain,
        Spice
    }
    public enum Location
    {
        Freezer,
        Refridgerator,
        Pantry,
        Cabinets
    }
    public class Ingredient
    {
        [Key]
        public string name { get; set; }
        public IngredientType type { get; set; }

        [DataType(DataType.Date)]
        public DateTime expDate { get; set; }
        public string vendor { get; set; }
        public short amount { get; set; }
        public decimal cost { get; set; }
    }
}
