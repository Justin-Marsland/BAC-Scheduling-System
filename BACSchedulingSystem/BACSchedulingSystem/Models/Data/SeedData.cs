using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BACSchedulingSystem.Data;
using System;
using System.Linq;
using System.Collections.Generic;

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

                // Look for any ingredients.
                if (context.Ingredient.Any())
                {
                    // DB has been seeded
                }
                else
                {
                    context.Ingredient.AddRange(
                    new Ingredient
                    {
                        name = "Hamburger",
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
                        name = "Gluten Free Hamburger Bun",
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
                    },

                    new Ingredient
                    {
                        name = "Lettuce",
                        type = IngredientType.Vegetable,
                        expDate = DateTime.Parse("05/20/2025"),
                        vendor = "Erdman's Grocery Store",
                        amount = 40,
                        cost = .75m
                    }
                );
                }
                //look for any recipes
                if (context.Recipe.Any())
                {
                    //database is seeded
                }
                else
                {
                    context.Recipe.AddRange(
                        new Recipe
                        {
                            Name = "Hamburger",
                            IngredientList = new List<Ingredient>(),
                            CookingInstructions = "Grill burger, then put it between the gluten free hamburger buns.",
                            GlutenFree = true,
                            Vegetarian = false,
                            Vegan = false,
                            Active = true
                        },

                        new Recipe
                        {
                            Name = "Salad",
                            IngredientList = null,
                            CookingInstructions = "Mix all ingredients together in large salad bowl",
                            GlutenFree = true,
                            Vegetarian = true,
                            Vegan = true,
                            Active = true
                        }
                        );
                    }
                context.SaveChanges();
            }
        }
    }
}