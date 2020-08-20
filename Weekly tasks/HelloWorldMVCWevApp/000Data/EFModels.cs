using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HelloWorldMVCWevApp._000Data
{
    public class Book
    {
        public int BookId { get; set; }

        [StringLength(50)]
        [Required]
        public string Title { get; set; }


     
        public string Author { get; set; }

    }

    public class Car
    {
        
        public int CarId { get; set; }

        [StringLength(10)]
        [Required]
        public string Model { get; set; }

        
        public string Owner { get; set; }

    }
}
