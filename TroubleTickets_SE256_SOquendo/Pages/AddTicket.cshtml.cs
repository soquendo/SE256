using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TroubleTickets_SE256_SOquendo.Models; //included this in order to create a temporary Ticket object

namespace TroubleTickets_SE256_SOquendo.Pages
{
    public class AddTicketModel : PageModel
    {
        [BindProperty]      //requires object to come via a form
        public TroubleTicketModel tTicket { get; set; } //instance of ticket model

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            IActionResult temp; //temportary result var

            if (ModelState.IsValid == false)        //if there are any errors, point to this page
            {
                temp = Page();
            }
            else
            {
                temp = Page();
            }

            return temp;            //return the resulting IActionResult
        }

    }
}
