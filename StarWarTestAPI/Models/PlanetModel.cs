using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarWarTestAPI.Models
{
    public partial class PlanetModel
    {
    
        [Key]
        public int id { get; set; }
        public string climate { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string diameter { get; set; }
        public Nullable<System.DateTime> edited { get; set; }
        public string gravity { get; set; }
        public string name { get; set; }
        public string orbital_period { get; set; }
        public string population { get; set; }
        public string rotation_period { get; set; }
        public string surface_water { get; set; }
        public string terrain { get; set; }
      
    }
}
