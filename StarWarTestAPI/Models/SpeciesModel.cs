using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarWarTestAPI.Models
{
    public class SpeciesModel
    {
        [Key]
        public int id { get; set; }
        public string average_height { get; set; }
        public string average_lifespan { get; set; }
        public string classification { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string designation { get; set; }
        public Nullable<System.DateTime> edited { get; set; }
        public string eye_colors { get; set; }
        public string hair_colors { get; set; }
        public Nullable<int> homeworld { get; set; }
        public string language { get; set; }
        public string name { get; set; }
        public string skin_colors { get; set; }
       
    }
}
