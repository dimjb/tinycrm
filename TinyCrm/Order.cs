using System.Collections.Generic;

namespace TinyCrm
{
      public class Order
      {
            public string OrderId { get; set; }
            public string DeliveryAddress { get; set; }
            public decimal TotalAmount { get; set; }
            public IEnumerable<Product> Products { get; set; }
      }
}
