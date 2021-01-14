using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFirstAppCSharp.Web.Data;
using MyFirstAppCSharp.Web.Models;
using Newtonsoft.Json;

namespace MyFirstAppCSharp.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly RestaurantsContext _context;

        public RestaurantsController(RestaurantsContext context)
        {
            _context = context;
        }


        // GET: Restaurants
        public async Task<IActionResult> Index()
        {
            var result = _context.Restaurant.FromSqlRaw("SELECT JSON_VALUE(BulkColumn, '$.borough') as borough, JSON_VALUE(BulkColumn, '$.cuisine') as cuisine,JSON_VALUE(BulkColumn, '$.name') as name,  ID, JSON_VALUE(BulkColumn, '$.name') as restaurant_id FROM RestaurantTest").ToList();

            return View(result);
        }
        
        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.ID == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Restaurants/Create
     
        public IActionResult Create()
        {
            return View();
        }
        

        public void JsonToSQL(string JSONresult)
        {

        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("borough,cuisine,name,restaurant_id")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(restaurant);
                Restaurant restoJSON = new Restaurant() { borough = restaurant.borough, cuisine = restaurant.cuisine, name = restaurant.name, restaurant_id = restaurant.restaurant_id };
                string JSONresult = JsonConvert.SerializeObject(restoJSON);
                Console.WriteLine(JSONresult);
                var req = _context.Database.ExecuteSqlRaw("INSERT INTO [dbo].[RestaurantTest] ([BulkColumn]) VALUES ("+JSONresult+")");
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        /*
        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant =_context.Restaurant.FromSqlRaw("SET BulkColumn =JSON_MODIFY");
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }*/
        
        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,borough,cuisine,name,restaurant_id")] Restaurant restaurant)
        {
            if (id != restaurant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(restaurant.ID))
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
            return View(restaurant);
        }
        
        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurant
                .FirstOrDefaultAsync(m => m.ID == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }
        
        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurant = await _context.Restaurant.FindAsync(id);
            _context.Restaurant.Remove(restaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurant.Any(e => e.ID == id);
        }
    }
}
