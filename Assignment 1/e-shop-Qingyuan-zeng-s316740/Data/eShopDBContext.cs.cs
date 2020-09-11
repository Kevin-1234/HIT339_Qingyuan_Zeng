using e_shop_Qingyuan_zeng_s316740.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace e_shop_Qingyuan_zeng_s316740.Data
{
    public class eShopDBContext : DbContext
    {
        public eShopDBContext(DbContextOptions<eShopDBContext> options)
           : base(options)
        {
        }
        public DbSet<item> items { get; set; }
        public DbSet<shoppingCart> shoppingCarts { get; set; }

    }

}
