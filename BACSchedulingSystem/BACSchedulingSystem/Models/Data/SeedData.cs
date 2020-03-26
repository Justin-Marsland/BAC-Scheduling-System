using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BACSchedulingSystem.Data;
using System;
using System.Linq;

namespace BACSchedulingSystem.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BACSchedulingSystemContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BACSchedulingSystemContext>>()))
            {
                // Look for any movies.
                if (context.Ingredient.Any())
                {
                    return;   // DB has been seeded
                }

                context.Ingredient.AddRange(
                    new Ingredient
                    {
                        name = "Ham",
                        type = IngredientType.Meat,
                        expDate = DateTime.Parse("04/15/2020"),
                        vendor = "Harry's Butcher Shop",
                        amount = 20,
                        cost = 1.50m
                    },

                    new Ingredient
                    {
                        name = "Apple",
                        type = IngredientType.Fruit,
                        expDate = DateTime.Parse("04/08/2020"),
                        vendor = "Sadia's Fruit Market",
                        amount = 50,
                        cost = .86m
                    },

                    new Ingredient
                    {
                        name = "Rice",
                        type = IngredientType.Grain,
                        expDate = DateTime.Parse("08/25/2020"),
                        vendor = "Walmart",
                        amount = 100,
                        cost = .37m
                    },

                    new Ingredient
                    {
                        name = "Carrot",
                        type = IngredientType.Vegetable,
                        expDate = DateTime.Parse("04/16/2020"),
                        vendor = "Erdman's Grocery Store",
                        amount = 22,
                        cost = .99m
                    }
                );
                context.SaveChanges();
            }
        }
    }
}