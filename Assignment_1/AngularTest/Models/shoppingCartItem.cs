using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularTest.Models
{
    public class shoppingCartItem
    {   

        public int shoppingCartItemId { get; set; }
        public int itemId { get; set; }
        public int shoppingCartId { get; set; }

        public item item { get; set; }

        public shoppingCart shoppingCart { get; set; }


    }
}
