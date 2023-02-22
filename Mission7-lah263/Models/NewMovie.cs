using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//creating a movie database model for the benefit of the users

namespace Mission7_lah263.Models
{
    public class NewMovie
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }
        //build a foreign key relationship
        [Required]
        public int CategoryId { get; set; }
        public Categories Category { get; set; }
    }
}

