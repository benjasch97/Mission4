using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// This contains the proper column headings with the correct requirements. For some reason, when I enter data, it is not displaying a warning properly...

namespace Mission4.Models
{
    public class MovieResponse
    {
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string Borrower { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }

    }
}
