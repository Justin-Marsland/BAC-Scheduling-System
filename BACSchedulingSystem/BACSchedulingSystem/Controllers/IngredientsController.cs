using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BACSchedulingSystem.Data;
using BACSchedulingSystem.Models;

namespace BACSchedulingSystem.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly BACSchedulingSystemContext _context;

        public IngredientsController(BACSchedulingSystemContext context)
        {
            _context = context;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index(string ingredientTypeSearch, string searchString)
        {
            // Use LINQ to get list of types.
            IQueryable<IngredientType> ingredientQuery = from m in _context.Ingredient
                                            orderby m.type
                                            select m.type;

            var ingredients = from m in _context.Ingredient
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                ingredients = ingredients.Where(s => s.name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(ingredientTypeSearch))
            {
                IngredientType ingredientType = strToIngredientType(ingredientTypeSearch);
                Debug.WriteLine("ingredientType = ", ingredientType);
                ingredients = ingredients.Where(x => x.type == ingredientType);
            }

            var ingredientTypeVM = new IngredientTypeViewModel
            {
                types = new SelectList(await ingredientQuery.Distinct().ToListAsync()),
                Ingredients = await ingredients.ToListAsync()
            };

            return View(ingredientTypeVM);
        }

        // GET: Ingredients/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient
                .FirstOrDefaultAsync(m => m.name == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // GET: Ingredients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,type,expDate,vendor,amount,cost")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingredient);
        }

        // GET: Ingredients/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("name,type,expDate,vendor,amount,cost")] Ingredient ingredient)
        {
            if (id != ingredient.name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientExists(ingredient.name))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient
                .FirstOrDefaultAsync(m => m.name == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ingredient = await _context.Ingredient.FindAsync(id);
            _context.Ingredient.Remove(ingredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientExists(string id)
        {
            return _context.Ingredient.Any(e => e.name == id);
        }

        public IngredientType strToIngredientType(string typeString)
        {
            IngredientType type;
            if (typeString == "Fruit")
                type = IngredientType.Fruit;
            else if (typeString == "Grain")
                type = IngredientType.Grain;
            else if (typeString == "Meat")
                type = IngredientType.Meat;
            else if (typeString == "Spice")
                type = IngredientType.Spice;
            else
                type = IngredientType.Vegetable;
            return type;
        }
    }
}
