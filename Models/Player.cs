using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAucation_MVC.Models
{
    public class Player // player class 
    { 
        public int Id { get; set; } // player id 
     
      
        [Required]
        public string Name { get; set; } // player name 
        public string Country { get; set; } // country from wher player belongs 
        public string Field { get; set; } // which game player played for thier country 


    }
}
