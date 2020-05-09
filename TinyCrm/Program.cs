using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TinyCrm.CrmDbContext;
using TinyCrm.Models;
using TinyCrm.Options;
using TinyCrm.Services;

namespace TinyCrm
{
      class Program
      {
            static void Main(string[] args)
            {
                  var dbContext = new TinyCrmDbContext();

                  /*var productsSeed = GetProductsFromCsv("C:\\data.csv");
                  foreach (Product p in productsSeed)
                  {
                        dbContext.Add(p);
                  }
                  dbContext.SaveChanges();*/

                  var customerOpts = new CustomerOptions
                  {
                        CreatedFrom = new DateTime(2020, 5, 1),
                        CreatedTo = new DateTime(2020, 5, 3)
                  };

                  // var customer = SearchCustomers(customerOpts, dbContext).SingleOrDefault();

                  var customers = SearchCustomers(customerOpts, dbContext).ToList();

                  if (customers.Any())
                  {
                        Console.WriteLine("===Customers===");
                        foreach (Customer c in customers)
                        {
                              Console.WriteLine($"| {c.CustomerId} | {c.VatNumber} | {c.FirstName} | {c.LastName} | {c.Created} |");
                        }
                  }
                  else
                  {
                        Console.WriteLine("Nothing Found!");
                  }
                  /*var productOpts = new ProductOptions
                  {
                        Categories = new List<ProductCategory>()
                        {
                              ProductCategory.Headphones
                        }
                  };

                  var products = SearchProducts(productOpts, dbContext).ToList();

                  var order = new Order()
                  {
                        DeliveryAddress = "Unknown 123, 00000"
                  };

                  if (products.Any())
                  {
                        foreach (Product p in products)
                        {
                              order.OrderProducts.Add(
                                    new OrderProduct()
                                    {
                                          Product = p
                                    });
                        }
                  }
                  else
                  {
                        Console.WriteLine("Nothing Found!");
                  }

                  if (customer != null)
                  {
                        customer.Orders.Add(order);
                        dbContext.SaveChanges();
                  }*/

                  dbContext.Dispose();
            }

            public static IQueryable<Customer> SearchCustomers(CustomerOptions customerOptions, TinyCrmDbContext dbContext)
            {
                  if (customerOptions.CreatedFrom != null &&
                        customerOptions.CreatedTo != null &&
                        customerOptions.CreatedFrom > customerOptions.CreatedTo)
                  {
                        return null;
                  }

                  var query = dbContext.Set<Customer>().AsQueryable();

                  if (customerOptions.CustomerId != null)
                  {
                        query = query.Where(c => c.CustomerId == customerOptions.CustomerId);
                  }

                  if (customerOptions.VatNumber != null)
                  {
                        query = query.Where(c => c.VatNumber == customerOptions.VatNumber);
                  }

                  if (customerOptions.CreatedFrom != null)
                  {
                        query = query.Where(c => c.Created >= customerOptions.CreatedFrom);
                  }

                  if (customerOptions.CreatedTo != null)
                  {
                        query = query.Where(c => c.Created <= customerOptions.CreatedTo);
                  }

                  if (!String.IsNullOrWhiteSpace(customerOptions.FirstName))
                  {
                        query = query.Where(c => c.FirstName.Contains(customerOptions.FirstName));
                  }

                  if (!String.IsNullOrWhiteSpace(customerOptions.LastName))
                  {
                        query = query.Where(c => c.LastName.Contains(customerOptions.LastName));
                  }

                  query = query.Take(500);
                  return query;
            }
            public static IQueryable<Product> SearchProducts(ProductOptions productOptions, TinyCrmDbContext dbContext)
            {
                  if (productOptions.PriceFrom != null &&
                        productOptions.PriceTo != null &&
                        productOptions.PriceFrom > productOptions.PriceTo)
                  {
                        return null;
                  }

                  var query = dbContext.Set<Product>().AsQueryable();

                  if (productOptions.ProductId != null)
                  {
                        query = query.Where(p => p.ProductId == productOptions.ProductId);
                  }

                  if (productOptions.Categories != null && productOptions.Categories.Any())
                  {
                        query = query.Where(p => productOptions.Categories.Contains(p.Category));
                  }

                  if (productOptions.PriceFrom != null)
                  {
                        query = query.Where(p => p.Price >= productOptions.PriceFrom);
                  }

                  if (productOptions.PriceTo != null)
                  {
                        query = query.Where(p => p.Price <= productOptions.PriceTo);
                  }

                  query = query.Take(500);
                  return query;
            }
            public static List<Product> GetProductsFromCsv(string filePath)
            {
                  return File.ReadAllLines(filePath)
                   .Skip(1) //delete if csv headers removed
                   .Select(x => x.Split(';'))
                   .Select(x => new Product
                   {
                         ProductId = x[0],
                         Name = x[1],
                         Category = (ProductCategory)int.Parse(x[2]),
                         Description = x[3],
                         Price = GetRandomPrice()
                   })
                   .GroupBy(p => p.ProductId)
                   .Select(p => p.FirstOrDefault())
                   .ToList();
            }

            public static decimal GetRandomPrice()
            {
                  return (decimal)(Math.Round(new Random().NextDouble() * 100, 2));
            }
      }
}
