using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieContext: DbContext
    {
        // Constructor
        public MovieContext(DbContextOptions<MovieContext> options) : base (options)
        {
            // Leave blank for now, this is just the constructor
        }

        public DbSet<MovieResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryID = 2, CategoryName = "Comedy" },
                new Category { CategoryID = 3, CategoryName = "Drama" },
                new Category { CategoryID = 4, CategoryName = "Family" },
                new Category { CategoryID = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryID = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryID = 7, CategoryName = "Television" },
                new Category { CategoryID = 8, CategoryName = "VHS" }
            );
            
            mb.Entity<MovieResponse>().HasData(

                new MovieResponse
                {
                    Movie_ID = 1,
                    CategoryID = 1,
                    Title = "Avengers, The",
                    Year = 2012,
                    Director = "Joss Whedon",
                    Rating = "PG-13",
                    Edited = false,
                    Borrower = "",
                    Notes = ""
                }, 
                new MovieResponse
                {
                    Movie_ID = 2,
                    CategoryID = 2,
                    Title = "Ace Ventura: Pet Detective",
                    Year = 1994,
                    Director = "Tom Shadyac",
                    Rating = "PG-13",
                    Edited = false,
                    Borrower = "",
                    Notes = ""
                },
                
                new MovieResponse
                {
                    Movie_ID = 3,
                    CategoryID = 3,
                    Title = "127 Hours",
                    Year = 2010,
                    Director = "Danny Boyle",
                    Rating = "R",
                    Edited = true,
                    Borrower = "",
                    Notes = ""
                }
             );
        }
    }
}
