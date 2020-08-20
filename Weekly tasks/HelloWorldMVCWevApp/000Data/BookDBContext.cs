using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

//Database manager
namespace HelloWorldMVCWevApp._000Data
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {
           
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Car> CarsDB{ get; set; }

    }
    /*
   dotnet tool install --global dotnet-ef 

  dotnet ef migrations add InitialCreate   -- creates script 



  dotnet ef database update  -- creates db and runs the migration 



  dotnet ef migrations remove 

  dotnet ef database drop 
   */
    
}

  
