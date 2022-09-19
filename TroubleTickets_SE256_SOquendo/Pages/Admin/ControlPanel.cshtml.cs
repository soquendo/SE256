using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//include these for Session vars
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using TroubleTickets_SE256_SOquendo.Models;

//added to use IConfiguration to get DB Connection string from the appsettings.json file
using Microsoft.Extensions.Configuration;

namespace TroubleTickets_SE256_SOquendo.Pages.Admin
{
    public class ControlPanelModel : PageModel
    {

        //instance of IConfiguration class - allows us to read in from appsettings
        private readonly IConfiguration _configuration;

        TroubleTicketDataAccessLayer factory;
        public List<TroubleTicketModel> tix { get; set; }

        public ControlPanelModel(IConfiguration configuration)
        {
            //constructor
            _configuration = configuration;

            factory = new TroubleTicketDataAccessLayer(_configuration);
        }



        public IActionResult OnGet()
        {

            IActionResult temp;

            //if the admin email is not here, we redirect them to login page
            if (HttpContext.Session.GetString("TicketAdmin_Email") is null)
            {
                temp = RedirectToPage("/Admin/Index");
            }
            else
            {

                tix = factory.GetActiveRecords().ToList(); // Fill in the currently empty list with records

                temp = Page(); // Else keep them here.
            }

            return temp; // Return the IActionResult
        }
    }
}
