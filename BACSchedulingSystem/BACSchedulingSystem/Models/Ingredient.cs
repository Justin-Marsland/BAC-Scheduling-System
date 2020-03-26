using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BACSchedulingSystem.Models
{
    public enum IngredientType
    {
        Meat,
        Fruit,
        Vegetable,
        Grain,
        Spice,
        NULL
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
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Type")]
        public IngredientType type { get; set; }

        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime expDate { get; set; }

        [Display(Name = "Vendor")]
        public string vendor { get; set; }

        [Display(Name = "Quantity")]
        public short amount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Cost")]
        public decimal cost { get; set; }
    }
}
