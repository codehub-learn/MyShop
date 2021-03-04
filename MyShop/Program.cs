using System;

namespace MyShop
{
     

    class Program
    {
        static int x;
        static void Main(string[] args)
        {

            using (var context = new SqlDb())
            {


            }

            }


        static void crud()
        {
            Customer customer = new Customer
            {
                FirstName = "Dimitra",
                LastName = "Geogiou",
                Email = "georgiou@gmail.com",
                IsActive = true,
                RegistrationDate = DateTime.Now,
            };

            Console.WriteLine(customer.Id);

            //new record creation
            using (var context = new SqlDb())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }

            Console.WriteLine(customer.Id);

            // reads customer 1
            using (var context = new SqlDb())
            {
                Customer c = context.Customers.Find(1);
                Console.WriteLine(c.FirstName + "  " + c.Id);
            }

            // update  changing the email of customer 1
            //checking concurrency
            //transactional
            using (var context = new SqlDb())
            {
                Customer c = context.Customers.Find(1);
                c.Email = "other@gmail.com";
                context.SaveChanges();
                Console.WriteLine(c.Email);
            }

            //Delete
            using (var context = new SqlDb())
            {
                Customer c = context.Customers.Find(2);
                if (c != null) context.Customers.Remove(c);
                else { Console.WriteLine("The client was not found"); }
                context.SaveChanges();

            }
        }



        static void OldCode()
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
                SellingPrice = 6
            };
            retailShop.Buy(product);
            retailShop.Sell(product);

            Console.WriteLine(retailShop.Balance);
            ////////////////////////////////////////////////////
            IShop inventoryShop = new ShopWithInventory
            {
                Name = "Other Shop",
                Balance = 2000
            };
            inventoryShop.Buy(product);
            inventoryShop.Sell(product);

            Console.WriteLine(inventoryShop.Balance);



        }
    }
}
