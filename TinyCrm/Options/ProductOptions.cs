using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.Models;

namespace TinyCrm.Options
{
      public class ProductOptions
      {
            public string ProductId { get; set; }
            public decimal? PriceFrom { get; set; } = null;
            public decimal? PriceTo { get; set; } = null;
            public IEnumerable<ProductCategory> Categories { get; set; }
      }
}
