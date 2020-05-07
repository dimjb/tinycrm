using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.Models;

namespace TinyCrm.CrmDbContext
{
      public class TinyCrmDbContext : DbContext
      {
            private readonly string connectionString = @"Server=localhost\SQLEXPRESS;Database=tinycrm;Trusted_Connection=True;";

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                  base.OnConfiguring(optionsBuilder);
                  optionsBuilder.UseSqlServer(connectionString);
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                  base.OnModelCreating(modelBuilder);

                  modelBuilder
                        .Entity<Customer>()
                        .ToTable("Customer");

                  modelBuilder
                       .Entity<Product>()
                       .ToTable("Product");

                  modelBuilder
                        .Entity<Customer>()
                        .HasData(
                        new Customer
                        {
                              CustomerId = 1,
                              FirstName = "TestCust1Name",
                              LastName = "TestCust1LastName",
                              VatNumber = "123456789",
                              Created = new DateTime(2020, 5, 1)
                        },
                        new Customer
                        {
                              CustomerId = 2,
                              FirstName = "TestCust2Name",
                              LastName = "TestCust2LastName",
                              VatNumber = "987654321",
                              Created = new DateTime(2020, 5, 3)
                        },
                        new Customer
                        {
                              CustomerId = 3,
                              FirstName = "TestCust3Name",
                              LastName = "TestCust3LastName",
                              VatNumber = "123654789",
                              Created = DateTime.Now
                        }
                   );

                  modelBuilder
                        .Entity<Product>()
                        .HasData(
                        new Product { ProductId = 1, ProductCategory = "games", Name = "TestProd1", Price = 20.0m },
                        new Product { ProductId = 2, ProductCategory = "games", Name = "TestProd2", Price = 40.0m },
                        new Product { ProductId = 3, ProductCategory = "technology", Name = "TestProd3", Price = 150.0m },
                        new Product { ProductId = 4, ProductCategory = "software", Name = "TestProd4", Price = 60.0m },
                        new Product { ProductId = 5, ProductCategory = "gadgets", Name = "TestProd5", Price = 45.0m },
                        new Product { ProductId = 6, ProductCategory = "hardware", Name = "TestProd6", Price = 100.0m }
                        );
            }
      }
}
