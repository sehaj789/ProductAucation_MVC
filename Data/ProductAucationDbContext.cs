using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductAucation_MVC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductAucation_MVC.Data
{
    public class ProductAucationDbContext : DbContext
    {

             public DbSet<Brand> Brand { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Place_Bid> Place_Bid { get; set; }
        public DbSet<Player> Player { get; set; }

        public ProductAucationDbContext(DbContextOptions<ProductAucationDbContext> options)
            : base(options)
        {
            
        }
        public ProductAucationDbContext()
        {
        }
    }
}
