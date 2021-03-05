using Microsoft.EntityFrameworkCore;
using MyShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyShop
{
     

    class Program
    {
         
        static void Main(string[] args)
        {
            ICustomerService customerService = new CustomerService();
            Customer customer = new Customer
            {
                 FirstName = "George",
                 LastName = "Georgiou",
                 Email = "georgiou@mail.com"
            };
            customerService.AddCustomer(customer);

        }
           
        
        
        
        
       
    }
}
