using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Abstracts;


namespace DataAccess.Entities
{
    public class Movie : Record
    {
        [StringLength(150)]
        public string Name { get; set; }
        public short? Year { get; set; }
        public double Revenue { get; set; }
        public int? DirectorId { get; set; }
        public Director Director { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }

        public Movie()
        {
            MovieGenres = new HashSet<MovieGenre>();
        }
    }
}