using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopcornTime_alpha3_.Models
{
    public class MovieSingle
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
    }
}