using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarWarTestAPI.Models
{

    [Serializable]
    public class Films_Planet
    {
        
        public int film_id { get; set; }
       
        public int planet_id { get; set; }
        
        
    }
}
