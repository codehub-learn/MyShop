using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyShop
{
    class Tests
    {


        static void testConcurrency()
        {
            // Example of concurrency problems during update
            using var database = new SqlDb();
            Account account = database.Accounts
                .Where(acc => acc.Customer.Email.Equals("other@gmail.com"))
                .FirstOrDefault();
            if (account == null)
            {
                Console.WriteLine("Account not found");
                return;
            }
            account.Balance += 100;
            try
            {
                database.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine("The transaction is aborted. Another user has changed the balance.");
                return;
            }
            Console.WriteLine("The transaction has completed successfully!");

        }
        static void Main5(string[] args)
        {

            using (var context = new SqlDb())
            {
                Account acc = context.Accounts.Where(a => a.Id == 1)
                    .Include(a => a.Customer).FirstOrDefault();
                Console.WriteLine("1 " + acc.Customer.Accounts[0].Customer.Accounts[0].Customer.Accounts[0].Customer.Accounts.Count);


            }
        }
        static void Main3(string[] args)
        {
            using (var context = new SqlDb())
            {
                Customer c = context.Customers.Where(cust => cust.Id == 1)
                    .Include(cust => cust.Accounts)
                    .FirstOrDefault();

                Account account = c.Accounts[0];
                Console.WriteLine("1 " + c.Accounts[0].Balance);
                account.Balance += 1;
                account.Tag -= 1;

                try
                {
                    context.SaveChanges();
                    // move on
                }
                catch (DbUpdateException e)
                {
                    Console.WriteLine(e + " took place");
                }


                Console.WriteLine("2 " + c.Accounts[0].Balance);
                Console.WriteLine("3 " + c.Accounts[0].Customer.FirstName);
            }
        }

        static void updateAccount()
        {
            using (var context = new SqlDb())
            {
                Customer c = context.Customers.Find(1);
                Account account = new Account
                {
                    Balance = 1000,
                    //  Customer = c,
                };
                c.Accounts = new List<Account>();
                c.Accounts.Add(account);

                //  context.Accounts.Add(account);
                context.SaveChanges();
                Console.WriteLine("1 " + c.Accounts.Count);
                c = context.Customers.Find(1);
                Console.WriteLine("2 " + c.Accounts.Count);

                c = context.Customers
                    .Where(cust => cust.Id == 1)
                    .Include(cust => cust.Accounts)
                    .FirstOrDefault();
                Console.WriteLine("3 " + c.Accounts.Count);


            }
        }


        static void pessimisticUpdate()
        {
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

        }
        static void optimisticUpdate()
        {

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
