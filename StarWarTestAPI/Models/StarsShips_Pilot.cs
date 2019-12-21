using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarWarTestAPI.Models
{

    [Serializable]
    public class StarsShips_Pilot
    {
        
        public int people_id { get; set; }
       
        public int starship_id { get; set; }
        
        
    }
}
