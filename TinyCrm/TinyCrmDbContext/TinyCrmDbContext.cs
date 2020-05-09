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
                       .Entity<Order>()
                       .ToTable("Order");

                  modelBuilder
                       .Entity<OrderProduct>()
                       .ToTable("OrderProduct");

                  modelBuilder
                       .Entity<OrderProduct>()
                       .HasKey(op => new { op.ProductId, op.OrderId });

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
            }
      }
}
