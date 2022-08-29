using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroubleTickets_SE256_SOquendo.Models
{
    public class TroubleTicketModel
    {
        public int Ticket_ID { get; set; } //this will be a primary key, identity spec

        public String Ticket_Title { get; set; } // basic description - 255 char

        public String Ticket_Desc {get; set;} // more descriptive, will be text field

        public String Category { get; set; } //short string to categorize problems

        public String Reporting_Email { get; set; } //email of person reporting the ticket

        public DateTime Orig_Date { get; set; } //date and time the ticket was posted

        public DateTime Close_Date { get; set; } //date and time the ticket was posted

        public String Responder_Notes { get; set; } // notes from the tech support responder

        public String Responder_Email { get; set; } //email address of the responder

        public bool Active { get; set; } // is this active or closed (false) - binary field

    }
}
