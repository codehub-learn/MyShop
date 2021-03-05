using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop 
{
    class AccountTransaction
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime TimeStamp { get; set; }
        public Account Account { get; set; }
        public int? AccountId { get; set; }
    }
}
