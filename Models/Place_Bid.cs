using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAucation_MVC.Models
{
    public class Place_Bid
    {

        public int Id { get; set; } // id 
        public string Your_Name { get; set; } // customer name 
        public string Email { get; set; } // customer email
        public Product Product { get; set; } // brand class 
        public int Productid { get; set; }


        public decimal Place_a_Bid { get; set; } // bid price 



    }
}
