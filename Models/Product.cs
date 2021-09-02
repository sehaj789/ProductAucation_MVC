using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAucation_MVC.Models
{
    public class Product
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Brand Brand { get; set; } // brand class 
        public int Brandid { get; set; }
        public Player Player { get; set; } // brand class 
        public int Playerid { get; set; }

    }
}
