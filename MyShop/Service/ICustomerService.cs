using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Service
{
    interface ICustomerService
    {
        void AddCustomer(Customer customer);
        void ChangeAddress(int customerId, string newAddress);

        Customer getCustomerByEmail(string email);
    }
}
