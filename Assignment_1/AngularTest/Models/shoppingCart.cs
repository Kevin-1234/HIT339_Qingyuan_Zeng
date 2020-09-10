using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularTest.Models
{
    public class shoppingCart
    {
        public int shoppingCartId { get; set; }

        public string userEmail { get; set; }

        public ICollection<item> items { get; set; }




    }
}
