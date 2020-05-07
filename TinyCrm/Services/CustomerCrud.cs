using System;
using System.Collections.Generic;
using System.Text;
using TinyCrm.CrmDbContext;
using TinyCrm.Models;
using TinyCrm.Options;

namespace TinyCrm.Services
{
      public class CustomerCrud
      {
            /* public Customer CreateCustomer(CustomerOptions customerOptions)
             {
                   var customer = new Customer
                   {
                         Address = customerOptions.Address,
                         Created = DateTime.Now,
                         Dob = customerOptions.Dob,
                         Email = customerOptions.Email,
                         FirstName = customerOptions.FirstName,
                         LastName = customerOptions.LastName,
                         Phone = customerOptions.Phone,
                         IsActive = true                   
                   };

                   using var dbContext = new TinyCrmDbContext();
                   dbContext.Customers.Add(customer);
                   dbContext.SaveChanges();

                   return customer;
             }
             public Customer GetCustomerById(int id)
             {
                   using var dbContext = new TinyCrmDbContext();

                   return dbContext.Customers.Find(id);
             }*/

      }
}
