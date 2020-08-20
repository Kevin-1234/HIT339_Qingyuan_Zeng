using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Movies._000Data
{
    public class MovieCategoryViewModel
    {
        public int MovieCategoryViewModelId { get; set; }

        public string CategoryName { get; set; }

        public int Code { get; set; }

        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public string Director { get; set; }

        public string Email { get; set; }

     


    }
}
