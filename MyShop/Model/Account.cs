using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop
{
    class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public Customer Customer { get; set; }
    }
}
