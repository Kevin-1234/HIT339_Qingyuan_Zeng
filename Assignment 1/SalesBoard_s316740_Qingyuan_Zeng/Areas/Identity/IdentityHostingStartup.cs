using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesBoard_s316740_Qingyuan_Zeng.Data;

[assembly: HostingStartup(typeof(SalesBoard_s316740_Qingyuan_Zeng.Areas.Identity.IdentityHostingStartup))]
namespace SalesBoard_s316740_Qingyuan_Zeng.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}