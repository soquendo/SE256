using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TroubleTickets_SE256_SOquendo.Models
{
    public class TroubleTicketModel
    {
        [Required]
        public int Ticket_ID { get; set; } //this will be a primary key, identity spec

        [Required, StringLength(255)]
        public String Ticket_Title { get; set; } // basic description - 255 char

        [Required]
        public String Ticket_Desc {get; set;} // more descriptive, will be text field

        [Required]
        [StringOptionsValidate(Allowed = new String[] {"Monitor", "Computer", "Printer", "Software Install", "Software Upgrade", "Configuration", "Internet"},
            ErrorMessage ="Sorry.. category is invalid. Categories: Monitor, Computer, Printer, Software Install, Software Upgrade, Configuration, Internet")]
        public String Category { get; set; } //short string to categorize problems

        [Required(ErrorMessage = "Email ID is Required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public String Reporting_Email { get; set; } //email of person reporting the ticket

        [Required]
        [Display(Name = "Original date of the problem.")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        [MyDate(ErrorMessage ="Future date entry not allowed")]
        public DateTime Orig_Date { get; set; } //date and time ticket was posted

        [Required]
        [Display(Name = "Date of solutions/closure.")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "0:MM/dd/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        [MyDate(ErrorMessage ="Future date entry not allowed")]
        public DateTime Close_Date { get; set; } // date and time the ticket is considered closed

        public String Responder_Notes { get; set; } // notes from tech support

        [Required(ErrorMessage = "Email ID is Required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public String Responder_Email { get; set; } //email of responder

        [Required]
        public bool Active { get; set; } // active = true, closed = false
        
        public String Feedback { get; set; } // new


    }
}
