﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFirstAppCSharp.Data.Data;
using MyFirstAppCSharp.Data.Model;
using MyFirstAppCSharp.Web.Models;
using Newtonsoft.Json;
using MyFirstAppCSharp.Service;

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
            // _context.Database.EnsureCreated();
            //_context.Restaurant.Include(x => x.address);
            RestaurantService restaurantService = new RestaurantService(_context);

            var result = restaurantService.Get();
            return View(result);
        }
        
        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _context.Restaurant.Include(x => x.address);
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
        public async Task<IActionResult> Create([Bind("Name,NumeroTel, Description, EmailProprio,address,  address.street")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Restaurant.Include(x => x.address);
                RestaurantService restaurantService = new RestaurantService(_context);
                restaurantService.Add(restaurant);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        
        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           

            if (id == null)
            {
                return NotFound();
            }
            return View();
        }
        
        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID, Name,NumeroTel, Description, EmailProprio, address.street")] Restaurant restaurant)
        {
            if (id != restaurant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    RestaurantService restaurantService = new RestaurantService(_context);
                    restaurantService.Edit(restaurant);
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
            RestaurantService restaurantService = new RestaurantService(_context);
            restaurantService.Delete(restaurant);
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
            
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurant.Any(e => e.ID == id);
        }
    }
}
