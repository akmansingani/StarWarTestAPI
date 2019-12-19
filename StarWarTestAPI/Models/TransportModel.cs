using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StarWarTestAPI.Models
{
    public class TransportModel
    {
        [Key]
        public int id { get; set; }
        public string cargo_capacity { get; set; }
        public string consumables { get; set; }
        public string cost_in_credits { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string crew { get; set; }
        public Nullable<System.DateTime> edited { get; set; }
        public string length { get; set; }
        public string manufacturer { get; set; }
        public string max_atmosphering_speed { get; set; }
        public string model { get; set; }
        public string name { get; set; }
        public string passengers { get; set; }

    }
}
