using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Reservations.Models
{
    public class ReservationModel
    {
        [Required]
        public int Reserv_ID { get; set; } //this will be a primary key, identity spec

        [Required, StringLength(30)]
        public String Reserv_PartyName { get; set; } // basic description - 255 char

        [Required]
        public int Reserv_People { get; set; } // more descriptive, will be text field

        //[Required, EmailAddress]
        //public String Reserv_Email { get; set; } //email of person making reservation

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\+?[1-9][0-9]{7,14}$", ErrorMessage = "Not a valid Phone number")]
        public string Reserv_Phone { get; set; }


        [Required(ErrorMessage = "Email ID is Required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public String Reserv_Email { get; set; }

        [Required(ErrorMessage = "Confirm Email is Required")]
        [DataType(DataType.EmailAddress)]
        [System.ComponentModel.DataAnnotations.Compare("Reserv_Email", ErrorMessage = "Email Not Matched")]
        public String ConfirmEmail { get; set; }

        /*[Required(ErrorMessage = "Email ID is Required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public String Reserv_Email { get; set; }*/


        [Required]
        [Display(Name = "Date of reservation")]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        [MyDate(ErrorMessage = "Past date entry not allowed")]
        public DateTime Reserv_Date { get; set; }

        [Required]
        [Display(Name = "Time of reservation")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        [MyDate(ErrorMessage = "Please select a time during our business hours")]
        public DateTime Reserv_Time { get; set; }



        //public DateTime Reserv_Date { get; set; } //date for reserv

        //public DateTime Reserv_Time { get; set; } //time for reserv

        public String Reserv_Notes { get; set; } // notes from the person making the reserv

        [Display(Name = "Would you like to receive emails and be added to your mailing list?")]
        public bool mailList { get; set; }

        [Required]
        public bool Active { get; set; } // is this active or closed (false) - binary field

        //add datetimes, ints, doubles, booleans as form data

    }
}