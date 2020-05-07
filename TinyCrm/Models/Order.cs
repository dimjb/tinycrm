using System.Collections.Generic;
using TinyCrm.Models;

namespace TinyCrm.CrmDbContext
{
      public class Order
      {
            public int Id { get; set; }
            public string DeliveryAddress { get; set; }
            public decimal TotalAmount { get; set; }
            //public Customer Customer { get; set; }
            //public List<OrderProduct> OrderProducts { get; set; }
      }
}
