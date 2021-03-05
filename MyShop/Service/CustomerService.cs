using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyShop.Service
{
    class CustomerService : ICustomerService
    {
        public void AddCustomer(Customer customer)
        {
            using var db = new SqlDb();
            if (customer == null)
            {
                Console.WriteLine("Empty customer");
                return;
            }
            if (customer.FirstName== null || customer.Email==null)
            {
                Console.WriteLine("No name or email");
                return;
            }
            if (customer.Email.Contains("@gmail.com") ||  customer.Email.Contains("@yahoo.com") ) {
                Console.WriteLine("Not acceptable email");
                return;
            }

            db.Customers.Add(customer);
            db.SaveChanges();
            Console.WriteLine("Customer has been inserted successfully");
        }

        public void ChangeAddress(int customerId, string newAddress)
        {
            throw new NotImplementedException();
        }

        public Customer getCustomerByEmail(string email)
        {
            using var db = new SqlDb();
            var customer = db.Customers
                .Where(c => c.Email.Equals(email))
                .Where(c => c.IsActive )
                .FirstOrDefault();

            return customer;
        }
    }
}
