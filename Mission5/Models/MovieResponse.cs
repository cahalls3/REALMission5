using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Mission5.Models
{
    public class MovieResponse
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        //Build Foreign Key Relationship
        [Required(ErrorMessage = "Please choose a valid Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Please enter the name of the Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a valid Year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please enter the name of the Director")]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [Range(0, 25)]
        public string Notes { get; set; }

    }

}
