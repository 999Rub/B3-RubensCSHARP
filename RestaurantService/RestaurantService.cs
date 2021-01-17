using System;
using System.Collections.Generic;
using System.Text;
using MyFirstAppCSharp;
using MyFirstAppCSharp.Data.Model;
using MyFirstAppCSharp;
using System.Linq;
using MyFirstAppCSharp.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace MyFirstAppCSharp.Service
{
    public class RestaurantService
    {
        private readonly RestaurantsContext _context;
        
        public RestaurantService(RestaurantsContext context)
        {
            _context = context;
        }
        public IQueryable<Restaurant> Get()
        {
            var result = _context.Restaurant.Include(x=>x.address);
            return result;
        }

        public void Add(Restaurant restaurant)
        {
            _context.Add(restaurant);
                
            _context.SaveChanges();

        }

        public void Delete(Restaurant restaurant)
        {
            _context.Restaurant.Include(x => x.address);

            _context.Restaurant.Remove(restaurant);
            _context.SaveChanges();
        }

        public void Edit(Restaurant restaurant)
        {
            _context.Restaurant.Include(x => x.address);
            _context.Restaurant.Update(restaurant);
            _context.SaveChanges();
        }
    }
}
