using System.Collections.Generic;
using TinyCrm.Models;

namespace TinyCrm.Models
{
      public class Product
      {
            public string ProductId { get; set; }
            public ProductCategory Category { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
      }
}
