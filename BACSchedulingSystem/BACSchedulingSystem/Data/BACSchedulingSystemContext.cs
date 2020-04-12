using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BACSchedulingSystem.Models;

namespace BACSchedulingSystem.Data
{
    public class BACSchedulingSystemContext : DbContext
    {
        public BACSchedulingSystemContext (DbContextOptions<BACSchedulingSystemContext> options)
            : base(options)
        {
        }

        public DbSet<BACSchedulingSystem.Models.Ingredient> Ingredient { get; set; }
        public DbSet<BACSchedulingSystem.Models.Recipe> Recipe { get; set; }
    }
}
