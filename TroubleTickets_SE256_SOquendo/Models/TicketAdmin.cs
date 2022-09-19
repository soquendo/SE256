using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using TroubleTickets_SE256_SOquendo.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace TroubleTickets_SE256_SOquendo.Models
{
    public class TicketAdmin
    {
        [Required]
        public int TicketAdmin_ID { get; set; } //primary key, identity spec
        [EmailAddress]
        [Display(Name = "Username")]
        public String TicketAdmin_Email { get; set; } //email of admin/responder

        [Required, StringLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String TicketAdmin_PW { get; set; } //basic pw - 20 chars
        public String Feedback { get; set; } //feedback to share to user

    }
}
