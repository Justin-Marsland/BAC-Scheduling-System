using Microsoft.EntityFrameworkCore;
using BACSchedulingSystem.Models;

namespace BACSchedulingSystem.Data
{
    public class BACContext : DbContext
    {
        public BACContext(DbContextOptions<BACContext> options)
            : base(options)
        {
        }

        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
    }
}
