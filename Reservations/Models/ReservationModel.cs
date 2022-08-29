using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations.Models
{
    public class ReservationModel
    {
        public int Reserv_ID { get; set; } //this will be a primary key, identity spec

        public String Reserv_PartyName { get; set; } // basic description - 255 char

        public double Reserv_People { get; set; } // more descriptive, will be text field

        public String Reserv_Email { get; set; } //email of person making reservation

        public DateTime Reserv_Date { get; set; } //date for reserv

        public DateTime Reserv_Time { get; set; } //time for reserv

        public String Reserv_Notes { get; set; } // notes from the person making the reserv

        public bool Active { get; set; } // is this active or closed (false) - binary field

    }
}