using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TroubleTickets_SE256_SOquendo.Models; //included this in order to create a temporary Ticket object

using Microsoft.Extensions.Configuration; //added to use IConfiguration so we can get our DB conn string from the appsettings.json file

namespace TroubleTickets_SE256_SOquendo.Pages
{
    public class AddTicketModel : PageModel
    {
        [BindProperty]      //requires object to come via a form
        public TroubleTicketModel tTicket { get; set; } //instance of ticket model
        private readonly IConfiguration _configuration; //instance of IConfiguration class - allows us to read in from config file like appsettings

        public AddTicketModel(IConfiguration configuration)
        {
            //constructor code below
            _configuration = configuration;
        }

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
                if (tTicket is null == false)
                {
                    TroubleTicketDataAccessLayer factory = new TroubleTicketDataAccessLayer(_configuration);
                    factory.Create(tTicket); //runs the create function to add record, results in feedback
                }

                temp = Page();
            }

            return temp;            //return the resulting IActionResult
        }

    }
}
