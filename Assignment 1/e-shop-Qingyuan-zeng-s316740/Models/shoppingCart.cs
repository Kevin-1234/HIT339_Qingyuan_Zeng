using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_shop_Qingyuan_zeng_s316740.Models
{
    public class shoppingCart
    {
        public int shoppingCartId { get; set; }

        public string userEmail { get; set; }

        public ICollection<item> items { get; set; }

    }
}
