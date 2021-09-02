using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAucation_MVC.Models
{
    public class Brand // brand clas 
    {
        public int Id { get; set; } // brand id
        [Required]
        public string Brand_Name { get; set; } // brand name 

        public string Description { get; set; } // brand description 

    }
}
