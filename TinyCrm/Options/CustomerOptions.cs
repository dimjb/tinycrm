using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Options
{
      public class CustomerOptions
      {
            public int? CustomerId { get; set; } = null; //used nullable just to be verbose about the absence of value
            //public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string VatNumber { get; set; }
            //public string Phone { get; set; }
            //public string Address { get; set; }
            public DateTime? CreatedFrom { get; set; } = null;
            public DateTime? CreatedTo { get; set; } = null;
            //public DateTime Dob { get; set; }
      }
}
