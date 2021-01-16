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


        public DbSet<Restaurant> Restaurant { get; set; }
        private const string ConnexionString = @"server=MSI;database=B3Restaurant;trusted_connection=true;user=if4na;password=2012420";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // c'est une mauvaise pratique que nous corrigerons ultérieurement
            optionsBuilder.UseSqlServer(
                ConnexionString
               );
        }

    }
}
