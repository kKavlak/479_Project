using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Entities
{
    public class MovieGenre
    {
        public int MovieId { get; set; }
        [Key]
        public int GenreId { get; set; }
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}