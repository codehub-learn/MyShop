using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop
{
    class ShopWithoutInventory : IShop
    {
        public string Name { get; set; }
        public decimal Balance  { get; set; }

        public void Buy(Product product)
        {
            Balance -= product.BuyingPrice;
        }

        public void Sell(Product product)
        {
            Balance += product.SellingPrice;
        }
    }
}
