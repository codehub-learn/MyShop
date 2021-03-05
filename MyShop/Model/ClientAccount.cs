using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Model
{
    class ClientAccount
    {

        public int Id { get; set; }
        public decimal Balance { get; set; }
        public List<Client> Clients { get; set; }
    }
}
