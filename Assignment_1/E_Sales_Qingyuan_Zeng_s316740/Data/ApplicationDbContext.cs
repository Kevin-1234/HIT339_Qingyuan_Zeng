using E_Sales_Qingyuan_Zeng_s316740.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Sales_Qingyuan_Zeng_s316740.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<E_Sales_Qingyuan_Zeng_s316740.Models.Items> Items { get; set; }
        public DbSet<E_Sales_Qingyuan_Zeng_s316740.Models.Sales> Sales { get; set; }
    }
}
