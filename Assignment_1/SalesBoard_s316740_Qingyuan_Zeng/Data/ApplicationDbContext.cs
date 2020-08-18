using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SalesBoard_s316740_Qingyuan_Zeng.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SalesBoard_s316740_Qingyuan_Zeng.Models.Items> Items { get; set; }
        public DbSet<SalesBoard_s316740_Qingyuan_Zeng.Models.Sales> Sales { get; set; }
        
    }
}
