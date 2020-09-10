using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularTest.Models
{
    public class item
    {
        public int itemId { get; set; }

        public int sellOrBuy { get; set; }
        public string itemName { get; set; }

        public int itemPrice { get; set; }

        public int itemType { get; set; }

        public string itemImage { get; set; }


    }
}
