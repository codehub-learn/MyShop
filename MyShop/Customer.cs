using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop
{
    class Customer 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public decimal TotalBalance { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; } 

        public override string ToString()
        {
            return "FirstName= "+FirstName
                + " LastName= "+ LastName
                +" TotalBalance= " + TotalBalance;
        }

    }
}
