using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must specify the date when the rental begins.")]
        public DateTime DateRented { get; set; }
        
        public DateTime? DateReturned { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Movie Movie { get; set; }

    }
}