using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TinyCrm
{
      class Program
      {
            static void Main(string[] args)
            {
                  try
                  {
                        var products = GetProductsFromCsv("C:\\data.csv");
                        var orderProducts = products.OrderBy(n => new Random().Next()).Take(10).ToList();

                        var orderList = new List<Order>();

                        var order1 = new Order
                        {
                              OrderId = Guid.NewGuid().ToString(),
                              DeliveryAddress = "Test Addr 1",
                              TotalAmount = orderProducts.Sum(p => p.Price),
                              Products = orderProducts
                        };
                        orderList.Add(order1);

                        var customer1 = new Customer("123456789")
                        {
                              Orders = orderList
                        };
                        customer1.CalculateTotalGross();

                        orderList.Clear();

                        orderProducts = products.OrderBy(n => new Random().Next()).Take(10).ToList();

                        var order2 = new Order
                        {
                              OrderId = Guid.NewGuid().ToString(),
                              DeliveryAddress = "Test Addr 2",
                              TotalAmount = orderProducts.Sum(p => p.Price),
                              Products = orderProducts
                        };
                        orderList.Add(order2);

                        var customer2 = new Customer("987654321")
                        {
                              Orders = orderList
                        };
                        customer2.CalculateTotalGross();

                        var customers = new List<Customer>
                        {
                              customer1,
                              customer2
                        };

                        var orders = new List<Order>
                        {
                              order1,
                              order2
                        };

                        var mostValuableCustomer = customers.OrderByDescending(c => c.TotalGross).FirstOrDefault();

                        Console.WriteLine
                              ($"Most valuable customer VAT number: {mostValuableCustomer.VatNumber} | Total Gross: {mostValuableCustomer.TotalGross}");

                        var soldProducts = new List<Product>();
                        foreach (Order o in orders)
                        {
                              foreach (Product p in o.Products) soldProducts.Add(p);
                        }

                        var mostSoldProducts = soldProducts.GroupBy(p => new { p.ProductId, p.Name })
                              .Select(p => new { p.Key.ProductId, p.Key.Name, Sold = p.Count() })
                              .OrderByDescending(o => o.Sold)
                              .Take(5)
                              .ToList();

                        Console.WriteLine("5 Most Sold Products:");
                        foreach (var p in mostSoldProducts)
                        {
                              Console.WriteLine($"ProductID: {p.ProductId} | Name: {p.Name} | Sold: {p.Sold}");
                        }
                  }
                  catch (Exception ex)
                  {
                        Console.WriteLine(ex.Message);
                  }
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
