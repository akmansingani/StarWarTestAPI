using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarWarTestAPI.Models
{

    [Serializable]
    public class Films_StarShips
    {
        
        public int film_id { get; set; }
       
        public int starship_id { get; set; }
        
        
    }
}
