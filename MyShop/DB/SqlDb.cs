using Microsoft.EntityFrameworkCore;
using MyShop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop 
{
    class SqlDb:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Client> Clients  { get; set; }
        public DbSet<ClientAccount> ClientAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=MyShopDB;Trusted_Connection=True;");
        }
    }
}
