﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class DirectorModel
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        
        [DisplayName("Birth Date")]
        public DateTime? BirthDate { get; set; }
        
        [DisplayName("Retired")]
        public bool IsRetired { get; set; }
        public int Id { get; set; }
    }
}
