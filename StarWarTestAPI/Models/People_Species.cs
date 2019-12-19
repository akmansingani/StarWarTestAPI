using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarWarTestAPI.Models
{

    [Serializable]
    public class People_Species
    {
        
        public int people_id { get; set; }
       
        public int species_id { get; set; }
        
        
    }
}
