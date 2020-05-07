using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Options
{
      public class ProductOptions
      {
            public int? ProductId { get; set; } = null; //used nullable just to be verbose about the absence of value
            public decimal? PriceFrom { get; set; } = null;
            public decimal? PriceTo { get; set; } = null;
            public IEnumerable<string> Categories { get; set; }
      }
}
