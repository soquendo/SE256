using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reservations.Models; //included this in order to create a temporary reserv object

using Microsoft.Extensions.Configuration;

namespace Reservations.Pages
{
    public class AddReservationModel : PageModel
    {
        [BindProperty]      //requires object to come via a form
        public ReservationModel rRes { get; set; } //instance of reserv model

        private readonly IConfiguration _configuration;

        public AddReservationModel(IConfiguration configuration)
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
                if (rRes is null == false)
                {
                    ReservationDataAccessLayer factory = new ReservationDataAccessLayer(_configuration);
                    factory.Create(rRes); //runs the create function to add record, results in feedback
                }

                temp = Page();
            }

            return temp;            //return the resulting IActionResult
        }

    }
}