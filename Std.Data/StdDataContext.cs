using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Std.Data;
using Std.Data.Domain;

namespace Std.Data
{
    public class StdDataContext : DbContext
    {
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<User> Users { get; set; }



        public StdDataContext(DbContextOptions<StdDataContext> options) : base(options)
        {

        }

    }
}
