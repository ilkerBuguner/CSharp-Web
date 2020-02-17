using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SharedTrip.Models
{
    public class UserTrip
    {
        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }

        [ForeignKey("Trip")]
        public string TripId { get; set; }

        public Trip Trip { get; set; }
    }
}
