using System;
using CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace Plugins.DataStore.SQL
{
	public class MarketContext : DbContext
	{
        public MarketContext(DbContextOptions<MarketContext> options):base(options)
		{
            //options.UseSqlServer("Server=localhost,1433;Database=MarketManagement;User Id=sa;Password=ragh2404;TrustServerCertificate=True;");
        }

			public DbSet<Category> Categories { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<Transaction> Transactions { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

           // modelBuilder.HasDefaultSchema("InventoryManagement");
            // define relationships - 1:N
            modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);


            //seeding data
            modelBuilder.Entity<Category>().HasData(
                  new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage" },
                  new Category { CategoryId = 2, Name = "Bakery", Description = "Bakery" },
                  new Category { CategoryId = 3, Name = "Meat", Description = "Meat" }
              );

            modelBuilder.Entity<Product>().HasData(
                    new Product { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99 },
                    new Product { ProductId = 2, CategoryId = 1, Name = "Canada Dry", Quantity = 200, Price = 1.99 },
                    new Product { ProductId = 3, CategoryId = 2, Name = "Whole Wheat Bread", Quantity = 300, Price = 1.50 },
                    new Product { ProductId = 4, CategoryId = 2, Name = "White Bread", Quantity = 300, Price = 1.50 }
                );
        }

    }


	}

