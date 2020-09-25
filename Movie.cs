using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        [Display(Name = "Movie ID")]
        public int Id { get; set; }
        
        [Display(Name = "Film Name")]
        [Required(ErrorMessage = "Please enter a movie title.")]
        public string Name { get; set; }
    }
}