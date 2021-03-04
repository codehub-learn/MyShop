using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop
{
    class ShopWithInventory : IShop
    {
        public string Name { get  ; set  ; }
        public decimal Balance { get ; set  ; }
        public List<Product> Products  { get ; set  ; } = new List<Product>();
            
   
        public void Buy(Product product)
        {
            Products.Add(product);
            Balance -= product.BuyingPrice;
        }

        public void Sell(Product product)
        {
            Products.Remove(product);
            Balance += product.SellingPrice;
        }
    }
}
