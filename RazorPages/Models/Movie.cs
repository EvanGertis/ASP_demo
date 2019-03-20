using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPages.Models
{
    public class Movie
    {
        public int ID { get; set; }
        
        //Validate the string length.
        [StringLength(60, MinimumLength = 3)]
        //Require the property to be filled.
        [Required]
        public string Title { get; set; }

        //Annoted descrition.
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        //Limit price range.
        [Range(1, 100)]
        //Specify data type.
        [DataType(DataType.Currency)]
        //sets format for price property
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        
        //Validate the format of the input.
        [RegularExpression(@"^[A-Z]+[a-zA-Z]""'\s-]*$")]
        //Make sure it was entered into the form.
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9]""`\s-]*$")]
        [StringLength(5)]
        [Required]
        //Field for recording movie rating.
        public string Rating { get; set; }
    }
}
