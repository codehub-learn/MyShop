using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyShop
{
    class Account
    {
        public int Id { get; set; }
   // [ConcurrencyCheck]
        public decimal Balance { get; set; }
        public int Tag { get; set; }
        public Customer Customer { get; set; }
        public List<AccountTransaction> Transactions { get; set; }
    }
}
