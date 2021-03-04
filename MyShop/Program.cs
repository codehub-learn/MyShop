using System;

namespace MyShop
{
     

    class Program
    {
        static int x;
        static void Main(string[] args)
        {
            IShop retailShop = new ShopWithoutInventory
            {
                Name = "Monastiraki Shop",
                Balance = 1000
            };
            Product product = new Product
            {
                Name = "rouxo",
                BuyingPrice = 5,
                SellingPrice =  6
            };
            retailShop.Buy(product);
            retailShop.Sell(product);

            Console.WriteLine(retailShop.Balance);


        }
    }
}
