using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reservations.Models;
using Microsoft.Extensions.Configuration;

namespace Reservations.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        /*public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }*/

        //Bind Property connects property to a post
        //adding SupportsGet allows data to come via URL
        [BindProperty(SupportsGet = true)]

        public string FName { get; set; } //first name property with default set/get

        /*public void OnGet()
        {
            //if the url does not have an FName value passed, we will set default
            if (string.IsNullOrWhiteSpace(FName))
            {
                FName = "You"; //set default value
            }
        }*/

        private readonly IConfiguration _configuration;     //instance of iconfig class = allows us to read config file

        ReservationDataAccessLayer factory;
        public List<ReservationModel> resv { get; set; }

        public IndexModel(IConfiguration configuration)
        {
            //constructor code goes below
            _configuration = configuration;

            factory = new ReservationDataAccessLayer(_configuration);
        }

        public void OnGet()
        {
            //if url does not have FName value passes, we'll set default
            if (string.IsNullOrWhiteSpace(FName))
            {
                FName = "You!"; //set def value
            }

            resv = factory.GetActiveRecords().ToList(); //fill in currently empty list with records
        }
    }
}

