using Microsoft.EntityFrameworkCore;
using MyFirstAppCSharp.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstAppCSharp.Data.Data
{
    public class RestaurantsContext : DbContext
    {
        public RestaurantsContext(DbContextOptions<RestaurantsContext> options)
           : base(options)
        {
        }

        public RestaurantsContext()
        {
        }

        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Grade> Grade { get; set; }
        
        private const string ConnexionString = @"server=MSI;database=B3Restaurant7;trusted_connection=true;user=if4na;password=2012420";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                ConnexionString
               );
        }
      

    }
}
