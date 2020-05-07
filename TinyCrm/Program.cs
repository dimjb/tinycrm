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
                  var customerOpts = new CustomerOptions
                  {
                        CreatedFrom = new DateTime(2020, 5, 1),
                        CreatedTo = new DateTime(2020, 5, 3)
                  };

                  var productOpts = new ProductOptions
                  {
                        PriceFrom = 20,
                        PriceTo = 60,
                        Categories = new List<string>()
                        {
                              "games"
                        }
                  };

                  try
                  {
                        var customers = SearchCustomers(customerOpts);

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
                  }
                  catch (Exception ex)
                  {
                        Console.WriteLine(ex.Message);
                  }

                  try
                  {
                        var products = SearchProducts(productOpts);

                        if (products.Any())
                        {
                              Console.WriteLine("===Products===");
                              foreach (Product p in products)
                              {
                                    Console.WriteLine($"| {p.ProductId} | {p.Name} | {p.ProductCategory} | {p.Price} |");
                              }
                        }
                        else
                        {
                              Console.WriteLine("Nothing Found!");
                        }
                  }
                  catch (Exception ex)
                  {
                        Console.WriteLine(ex.Message);
                  }
            }

            public static IEnumerable<Customer> SearchCustomers(CustomerOptions customerOptions)
            {
                  if (customerOptions.CreatedFrom != null &&
                        customerOptions.CreatedTo != null &&
                        customerOptions.CreatedFrom > customerOptions.CreatedTo)
                  {
                        throw new Exception("CreatedFrom cannot be later than CreatedTo");
                  }

                  using (var dbContext = new TinyCrmDbContext())
                  {
                        var query = dbContext.Set<Customer>();

                        if (customerOptions.CustomerId != null)
                        {
                              return query.Where(c => c.CustomerId == customerOptions.CustomerId).ToList();
                        }

                        if (customerOptions.VatNumber != null)
                        {
                              return query.Where(c => c.VatNumber == customerOptions.VatNumber).ToList();
                        }

                        if (customerOptions.CreatedFrom != null && customerOptions.CreatedTo != null)
                        {
                              return query.Where(
                                    c => c.Created >= customerOptions.CreatedFrom && c.Created <= customerOptions.CreatedTo ||
                                    c.FirstName.Contains(customerOptions.FirstName) || c.LastName.Contains(customerOptions.LastName))
                                    .Take(500)
                                    .ToList();
                        }

                        return query.Where(c => c.FirstName.Contains(customerOptions.FirstName) || c.LastName.Contains(customerOptions.LastName))
                                                .Take(500)
                                                .ToList();
                  }
            }
            public static IEnumerable<Product> SearchProducts(ProductOptions productOptions)
            {
                  if (productOptions.PriceFrom != null &&
                        productOptions.PriceTo != null &&
                        productOptions.PriceFrom > productOptions.PriceTo)
                  {
                        throw new Exception("PriceFrom cannot be greater than PriceTo");
                  }

                  using (var dbContext = new TinyCrmDbContext())
                  {
                        var query = dbContext.Set<Product>();

                        if (productOptions.ProductId != null)
                        {
                              return query.Where(p => p.ProductId == productOptions.ProductId).ToList();
                        }

                        if (productOptions.Categories != null &&
                        productOptions.Categories.Any() &&
                        productOptions.PriceFrom != null &&
                        productOptions.PriceTo != null)
                        {
                              return query.Where(p => p.Price >= productOptions.PriceFrom && p.Price <= productOptions.PriceTo &&
                                                                       productOptions.Categories.Contains(p.ProductCategory))
                                                       .Take(500)
                                                       .ToList();
                        }

                        if (productOptions.Categories != null && productOptions.Categories.Any())
                        {
                              return query.Where(p => productOptions.Categories.Contains(p.ProductCategory))
                                                      .Take(500)
                                                      .ToList();
                        }

                        return query.Where(p => p.Price >= productOptions.PriceFrom && p.Price <= productOptions.PriceTo)
                                                .Take(500)
                                                .ToList();
                  }
            }
            public static List<Product> GetProductsFromCsv(string filePath)
            {
                  return File.ReadAllLines(filePath)
                   .Skip(1) //delete if csv headers removed
                   .Select(x => x.Split(';'))
                   .Select(x => new Product
                   {
                         Name = x[1],
                         Description = x[2],
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
