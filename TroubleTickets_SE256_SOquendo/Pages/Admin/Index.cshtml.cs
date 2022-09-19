using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using TroubleTickets_SE256_SOquendo.Models; //creates a temporary ticket object
using Microsoft.Extensions.Configuration; // uses IConfiguration to get DB Connection string from the appsettings.json file
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace TroubleTickets_SE256_SOquendo.Pages.Admin
{
    public class IndexModel : PageModel
    {

        [BindProperty]  // Requires object to come via a form
        public TicketAdmin tAdmin { get; set; } // Instance of Admin Model
        private readonly IConfiguration _configuration; // Instance of IConfiguration class... allows us to read in from config file like appsettings

        public IndexModel(IConfiguration configuration)
        {
            // Constructor code goes below.
            _configuration = configuration;
        }


        public void OnGet()
        {
            HttpContext.Session.SetInt32("test", 5);
        }

        // This event handler occurs when a form is posted to this pg
        public IActionResult OnPost()
        {
            IActionResult temp;
            List<TicketAdmin> lstTicketAdmin = new List<TicketAdmin>(); // List to hold ticket admins from DB table

            if (ModelState.IsValid == false)     // If there are any errors, point to this page
            {

                temp = Page();

            }
            else
            {
                if (tAdmin != null)
                {
                    TicketAdminDataAccessLayer factory = new TicketAdminDataAccessLayer(_configuration);

                    //runs func to return login search results in feedback
                    lstTicketAdmin = factory.GetAdminLogin(tAdmin).ToList();

                    if (lstTicketAdmin.Count > 0)
                    {
                        // If we found a record, store info in session and redirect us to control panel
                        HttpContext.Session.SetInt32("TicketAdmin_ID", lstTicketAdmin[0].TicketAdmin_ID);
                        HttpContext.Session.SetString("TicketAdmin_Email", lstTicketAdmin[0].TicketAdmin_Email);
                        temp = Redirect("/Admin/ControlPanel");

                    }
                    else
                    {
                        tAdmin.Feedback = "Login Failed."; //If it failed (no record), set message and keep them here.
                        temp = Page();
                    }
                }
                else
                {
                    temp = Page(); // If tAdmin is null, then keep them here
                }


            }


            return temp; // Return the resulting IActionResult
        }
    }
}