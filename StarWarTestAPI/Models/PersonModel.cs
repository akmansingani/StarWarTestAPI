using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarWarTestAPI.Models
{

    [Serializable]
    public class PersonModel
    {
        [Key]
        public int id { get; set; }
        public string birth_year { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public Nullable<System.DateTime> edited { get; set; }
        public string eye_color { get; set; }
        public string gender { get; set; }
        public string hair_color { get; set; }
        public string height { get; set; }
        public Nullable<int> homeworld { get; set; }
        public string mass { get; set; }
        public string name { get; set; }
        public string skin_color { get; set; }
      
    }
}
