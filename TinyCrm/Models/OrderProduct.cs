using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.CrmDbContext;

namespace TinyCrm.Models
{
      public class OrderProduct
      {
            public int OrderId { get; set; }
            public string ProductId { get; set; }
            public Order Order { get; set; }
            public Product Product { get; set; }
      }
}
