using System.Collections.Generic;
using TinyCrm.Models;

namespace TinyCrm.Models
{
      public class Product
      {
            public int ProductId { get; set; }
            public string ProductCategory { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            //public List<OrderProduct> OrderProducts { get; set; }
      }
}
