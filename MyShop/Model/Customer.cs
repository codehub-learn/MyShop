using MyShop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop
{
    class Customer: GeneralCustomer
    {
        

        public List<Account> Accounts { get; set; }

      
    }
}
