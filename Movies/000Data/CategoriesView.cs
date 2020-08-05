using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies._000Data
{
    public class CategoriesView
    {
        public List<Categories> Categories { get; set; }
        public SelectList Names { get; set; }
        public string CategoryName { get; set; }
    }
}
