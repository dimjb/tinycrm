using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TinyCrm
{
      public class Customer
      {
            public string CustomerId { get; set; }
            public DateTime Created { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public  string LastName { get; set; }
            public string VatNumber { get; private set; }
            public string Phone { get; set; }
            public bool IsActive { get; set; }
            public int Age { get; set; }
            public decimal TotalGross { get; private set; }
            public IEnumerable<Order> Orders { get; set; }

            public Customer(string vatNumber)
            {
                  if (!IsValidVatNumber(vatNumber)) throw new Exception("Invalid VAT number");

                  VatNumber = vatNumber;
                  Created = DateTime.Now;
            }

            public void CalculateTotalGross()
            {
                  TotalGross = Orders.Sum(o => o.TotalAmount);
            }

            public bool IsValidVatNumber(string vatNum)
            {
                  if (string.IsNullOrWhiteSpace(vatNum)) return false;
                  vatNum = vatNum.Trim();

                  foreach (char ch in vatNum)
                  {
                        if (!char.IsDigit(ch)) return false;
                  }

                  return vatNum.Length == 9;
            }

            public bool IsValidEmail(string email)
            {
                  if (string.IsNullOrWhiteSpace(email)) return false;
                  email = email.Trim();

                  int count = 0;
                  foreach (char ch in email)
                  {
                        if (ch == '@') count++;
                  }

                  return count == 1 && (email.EndsWith(".com") || email.EndsWith(".gr"));
            }

            public bool IsHighValuedCustomer()
            {
                  return TotalGross > 10000;
            }

            public void SetPhone(string phone)
            {
                  Phone = phone;
            }

            public bool IsAdult()
            {
                  return Age >= 18 && Age <= 110;
            }
      }
}

