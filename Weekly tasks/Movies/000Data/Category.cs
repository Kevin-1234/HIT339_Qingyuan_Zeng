using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies._000Data
{
    public class Category
    {
        public int CategoryId { get; set; }


        public string CategoryName { get; set; }


        public int Code { get; set; }

        

        public ICollection<Movie> Movies { get; set; }
    }
}
