using System;
using System.Collections.Generic;
using AngularTest.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AngularTest.Data
{
    public class eShopDBContext : DbContext
    {
        public eShopDBContext(DbContextOptions<eShopDBContext> options)
           : base(options)
        {
        }

        public DbSet<item> items { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
        public DbSet<shoppingCart> shoppingCarts { get; set; }

        public DbSet<shoppingCartItem> shoppingCartItems { get; set; }
=======
>>>>>>> parent of 413d449... backup before adding shopping cart
=======
>>>>>>> parent of 413d449... backup before adding shopping cart
    }
}
