using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop
{
    interface IShop
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        void Buy(Product product); 
        void Sell(Product product);
    }
}
