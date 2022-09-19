using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TroubleTickets_SE256_SOquendo.Models;

// Added to use IConfiguration, to get our DB Connection string from the appsettings.json file
using Microsoft.Extensions.Configuration;



namespace TroubleTickets_SE256_SOquendo.Models
{
    public class TicketAdminDataAccessLayer
    {
        string connectionString; // string receieves the connection string from the constructor

        //lets us read in from config file like appsettings
        private readonly IConfiguration _configuration;

        //The Razor page that creates this data factory and passes the configuration object, we could collect the connection string for this project.

        public TicketAdminDataAccessLayer(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        
        }

        public IEnumerable<TicketAdmin> GetAdminLogin(TicketAdmin tAdmin)
        {
            List<TicketAdmin> lstTicketAdmin = new List<TicketAdmin>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string strSQL = "SELECT TOP 1 * FROM TicketAdmin_Registry WHERE TicketAdmin_Email = @TicketAdmin_Email AND TicketAdmin_PW = @TicketAdmin_PW;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.CommandType = CommandType.Text;

                    // Fill in search params with login form data
                    cmd.Parameters.AddWithValue("@TicketAdmin_Email", tAdmin.TicketAdmin_Email);
                    cmd.Parameters.AddWithValue("@TicketAdmin_PW", tAdmin.TicketAdmin_PW);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(); // Populate data reader (rdr) from DB

                    // Loop thru each record, for each record fill a temporary trouble ticket object with current record's data.
                    // Then add this temporary ticket obj to the list. List will be available to the CSHTML to format.
                    while (rdr.Read())
                    {
                        TicketAdmin tMatch = new TicketAdmin(); // Create temp object

                        // Fill in the temp obj from DB results
                        tMatch.TicketAdmin_ID = Convert.ToInt32(rdr["TicketAdmin_ID"]); // Needed to convert to Int32
                        tMatch.TicketAdmin_Email = rdr["TicketAdmin_Email"].ToString();
                        tMatch.TicketAdmin_PW = rdr["TicketAdmin_PW"].ToString();

                        lstTicketAdmin.Add(tMatch); // Add the object to list
                    }
                    con.Close();
                }
            }
            catch (Exception err)
            {
                // Nothing at this moment
            }
            return lstTicketAdmin; // Return LIST so razor page can build HTML table based on this list
        }//--------------------- end of ienumerable TicketAdmin ----------------

    }
}
