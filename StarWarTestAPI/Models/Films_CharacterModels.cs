using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarWarTestAPI.Models
{

    [Serializable]
    public class Films_CharacterModels
    {
        
        public int film_id { get; set; }
       
        public int people_id { get; set; }
        
        
    }
}
