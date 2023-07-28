using Kombox.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Kombox.DataAccess.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Action", DisplayOrder = 10 },
                new Category { CategoryId = 2, Name = "Action", DisplayOrder = 10 },
                new Category { CategoryId = 3, Name = "Action", DisplayOrder = 10 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Title = "Fortune of Time",
                    Author = "Billy Spark",
                    Description = "Present vitae sodales. Praesent molesting agousting disgunting Auhting",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 80,
                    Price100 = 100,
                    CategoryId = 1,
                    ImageUrl = "",
                },
                new Product
                {
                    ProductId = 2,
                    Title = "Diary of Chavo",
                    Author = "Roberto Gomez Bolaños",
                    Description = "Present the short life from a litle child who lives in a small hometown",
                    ISBN = "SWD9999002",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 80,
                    Price100 = 100,
                    CategoryId = 1,
                    ImageUrl = "",
                });

        }

    }
}
