using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarWarTestAPI.Models
{

    [Serializable]
    public class FilmModel
    {
        [Key]
        public int id { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string director { get; set; }
        public Nullable<System.DateTime> edited { get; set; }
        public Nullable<int> episode_id { get; set; }
        public string opening_crawl { get; set; }
        public string producer { get; set; }
        public Nullable<System.DateTime> release_date { get; set; }
        public string title { get; set; }
    
        
    }
}
