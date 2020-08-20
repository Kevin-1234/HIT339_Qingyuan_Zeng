using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Movies._000Data
{

 
    public class Movie
    {
        public int MovieId {get; set;}

        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate {get; set;}

        public string Director { get; set; }

        public string Email { get; set; }

        public enum Language { English, Japanese, Chinese } 

        public Nullable<int> CategoryId { get; set; }
        

    }

}
    

 
