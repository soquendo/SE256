using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TroubleTickets_SE256_SOquendo.Models; //included this to create a temporary Ticket object
using Microsoft.Extensions.Configuration;

namespace TroubleTickets_SE256_SOquendo.Pages.Admin
{
    public class EditTicketModel : PageModel
    {

        private readonly IConfiguration _configuration;

        [BindProperty]
        public TroubleTicketModel tTicket { get; set; }

        public TroubleTicketDataAccessLayer factory;
        public EditTicketModel(IConfiguration configuration)
        {
            _configuration = configuration;
            factory = new TroubleTicketDataAccessLayer(_configuration);
        }

        //when this page is loaded, this function will run if the int form of ID is passed

        public ActionResult OnGet(int? id)
        {
            if (id == null) //if the ID is null, we will just return a built in not found error
            {
                return NotFound();
            }
            else
            {
                //if an ID is passed,pas the ID to the method which will fill tTicket
                tTicket = factory.GetOneRecord(id);

            }

            if (tTicket == null) //if the ticket is null, display the not found error
            {
                return NotFound();
            }
            return Page(); //return the page with either the daata or error message       
        }

        public ActionResult OnPost() //when the Submit (update) button is pressed. this runs
        {
            if (!ModelState.IsValid) //if not valid form info, stay here to display errors
            {
                return Page();
            }
            factory.UpdateTicket(tTicket); //else we run our update function in the data factory

            return RedirectToPage("/Admin/ControlPanel"); // Redirect to the list of tickets
        }
    }
}
