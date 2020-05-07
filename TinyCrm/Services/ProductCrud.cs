using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.CrmDbContext;
using TinyCrm.Models;
using TinyCrm.Options;

namespace TinyCrm.Services
{
      public class ProductCrud
      {
            /*public Product CreateProduct(ProductOptions productOptions)
            {
                  var product = new Product
                  {
                        Name = productOptions.Name,
                        Description = productOptions.Description,
                        Price = productOptions.Price
                  };

                  using var dbContext = new TinyCrmDbContext();
                  dbContext.Products.Add(product);
                  dbContext.SaveChanges();
                  return product;
            }

            public Product GetProductById(int id)
            {
                  using var dbContext = new TinyCrmDbContext();

                  return dbContext.Products.Find(id);
            }*/
      }
}
