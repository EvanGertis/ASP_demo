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
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }

        //sets format for price property
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        

        //Field for recording movie rating.
        public string Rating { get; set; }
    }
}
