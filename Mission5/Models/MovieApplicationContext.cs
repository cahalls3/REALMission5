using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Mission5.Models
{
    public class MovieApplicationContext : DbContext
    {
        //Constructor
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) : base(options)
        {
            //Leave blank for now
        }

        public DbSet<MovieResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure"},
                new Category { CategoryId = 2, CategoryName = "Comedy"},
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" },
                new Category { CategoryId = 9, CategoryName = "Unknown/None"}
            );

            mb.Entity<MovieResponse>().HasData(

                new MovieResponse
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieResponse
                {
                    MovieId = 2,
                    CategoryId = 1,
                    Title = "Captain America: Winter Soldier",
                    Year = 2014,
                    Director = "Anthony & Joe Russo",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieResponse
                {
                    MovieId = 3,
                    CategoryId = 1,
                    Title = "Inception",
                    Year = 2010,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
            );
        }
    }
}
