using Microsoft.EntityFrameworkCore;
using Mission7_lah263.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7_lah263.Models
{
    public class MovieApplicationContext : DbContext
    {
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base(options)
        {
            //leave blank
        }
        public DbSet<NewMovie> Responses { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Categories>().HasData(
                new Categories { CategoryId=1, CategoryName="Action/Adventure"},
                new Categories { CategoryId = 2, CategoryName = "Comedy" },
                new Categories { CategoryId = 3, CategoryName = "Drama" },
                new Categories { CategoryId = 4, CategoryName = "Family" },
                new Categories { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Categories { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Categories { CategoryId = 7, CategoryName = "Television" },
                new Categories { CategoryId = 8, CategoryName = "VHS" }
                );
            mb.Entity<NewMovie>().HasData(

                new NewMovie
                {
                    MovieID = 1,
                    CategoryId = 1,
                    Title = "The Accountant",
                    Year = 2016,
                    Director = "Rod",
                    Rating = "R",
                    Edited = true
                },
                new NewMovie
                {
                    MovieID = 2,
                    CategoryId = 2,
                    Title = "Nacho Libre",
                    Year = 2006,
                    Director = "Jared Hess",
                    Rating = "PG",
                    Edited = false
                },
                new NewMovie
                {
                    MovieID = 3,
                    CategoryId = 3,
                    Title = "Ever After",
                    Year = 1998,
                    Director = "Andy Tennant",
                    Rating = "PG",
                    Edited = false
                }
            );
        }
    }
}

