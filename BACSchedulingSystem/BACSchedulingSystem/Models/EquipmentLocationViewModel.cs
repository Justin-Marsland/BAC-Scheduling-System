using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BACSchedulingSystem.Models
{
    public class EquipmentLocationViewModel
    {
        public List<Equipment> Equipment { get; set; }
        public SelectList Location { get; set; }
        public string EquipmentLocation { get; set; }
        public string SearchString { get; set; }
    }
}