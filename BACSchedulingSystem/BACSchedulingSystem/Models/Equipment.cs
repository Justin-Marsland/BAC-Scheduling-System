using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACSchedulingSystem.Models
{
    public class Equipment
    {
        [Key]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int QuantityReserved { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}