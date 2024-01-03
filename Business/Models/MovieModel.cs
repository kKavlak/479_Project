using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class MovieModel
    {
        [StringLength(150)]
        public string Name { get; set; }
        public short? Year { get; set; }
        public double Revenue { get; set; }
        
        [DisplayName("Director")]
        public int? DirectorId { get; set; }
        public int MovieId { get; set; }
    }
}
