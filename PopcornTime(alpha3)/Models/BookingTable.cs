using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PopcornTime_alpha3_.Models
{
    public class BookingTable
    {
        [Key]
        public int BookingID { get; set; }

        [DisplayName("No. of Seats")]
        public int Seatno { get; set; }
    }
}