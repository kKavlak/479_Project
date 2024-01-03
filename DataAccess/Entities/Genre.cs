using Root.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Genre : Record
    {
        [StringLength(75)]
        [Key]
        public string Name { get; set; } // Assume max length validation is handled elsewhere
        public ICollection<MovieGenre> MovieGenres { get; set; } // Navigation property

        public Genre()
        {
            MovieGenres = new HashSet<MovieGenre>();
        }
    }
}