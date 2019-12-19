using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarWarTestAPI.Models
{
    public class StarshipModel
    {
        [Key]
        public int id { get; set; }
        public string MGLT { get; set; }
        public string hyperdrive_rating { get; set; }
        public string starship_class { get; set; }
    
    }
}
