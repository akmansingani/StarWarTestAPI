using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarWarTestAPI.Models
{

    [Serializable]
    public class Films_Species
    {
        
        public int film_id { get; set; }
       
        public int species_id { get; set; }
        
        
    }
}
