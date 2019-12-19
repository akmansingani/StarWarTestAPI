using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarWarTestAPI.Models
{
    public class VehicleModel
    {
    
        [Key]
        public int id { get; set; }
        public string vehicle_class { get; set; }
    
    }
}
