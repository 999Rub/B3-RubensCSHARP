using System;
using System.Collections.Generic;
using System.Text;
using MyFirstAppCSharp;
using MyFirstAppCSharp.Data.Model;
using MyFirstAppCSharp;
using System.Linq;
using MyFirstAppCSharp.Data.Data;

namespace MyFirstAppCSharp.Service
{
    public class RestaurantService
    {
        public IQueryable<Restaurant> Get()
        {
            var db = new RestaurantsContext();
            var result = db.Restaurant.Where(p => p.ID == 1);
            return result;
        }
    }
}
