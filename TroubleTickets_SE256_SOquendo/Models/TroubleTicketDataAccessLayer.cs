using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using TroubleTickets_SE256_SOquendo.Models;

using Microsoft.Extensions.Configuration;


namespace TroubleTickets_SE256_SOquendo.Models
{
    public class TroubleTicketDataAccessLayer
    {
        string connectionString; //string that receives connection str from constructor

        private readonly IConfiguration _configuration; //instance of IConfiguration class - allows us to read in from config file like appsettings

        //razor page creates this data factory and passes the config obj to it
        public TroubleTicketDataAccessLayer(IConfiguration configuration)
        {
            //via config obj, we can collect conn string for this proj
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public void Create(TroubleTicketModel ticket)
        {
            //a little more efficient bc it deletes sql conn and anything inside when brackets close
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //sql statement to add a record with start info [lacks response/solution - this is for update]
                //we are using parameters to avoid issues with hacks like sql injection hacks

                string sql = "INSERT Into TroubleTickets (Ticket_Title, Ticket_Desc, Category, Reporting_Email, Orig_Date) VALUES (@Ticket_Title, @Ticket_Desc, @Category, @Reporting_Email, @Orig_Date);";

                //init feedback to avoid reusing error messages once they have been fixed
                ticket.Feedback = "";

                //use TRY since connected with a resource we cannot control, if we get error, it jumps to CATCH
                try
                {
                    //creating a command obj that uses the sql command and conn string
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        //tell command our sql string
                        command.CommandType = CommandType.Text; //fill in parameters
                        command.Parameters.AddWithValue("@Ticket_Title", ticket.Ticket_Title);
                        command.Parameters.AddWithValue("@Ticket_Desc", ticket.Ticket_Desc);
                        command.Parameters.AddWithValue("@Category", ticket.Category);
                        command.Parameters.AddWithValue("@Reporting_Email", ticket.Reporting_Email);
                        command.Parameters.AddWithValue("@Orig_Date", DateTime.Now); //filling in current date and time

                        //connect to the db - the conn can be the first issue we run across
                        connection.Open();
                        //perform command, this returns the number of records affected - use that number and concatenate to a string to provide feedback
                        ticket.Feedback = command.ExecuteNonQuery().ToString() + " Record Added";
                        //close conn
                        connection.Close();
                    }
                }
                catch (Exception err)
                {
                    //if an error occurs, lets list it as feedback
                    ticket.Feedback = "ERROR: " + err.Message;
                }
                //return RedirectToAction("Index");
                //send over to Index action at this point
            }

        } //-------- END OF PUBLIC VOID CREATE --------

        public IEnumerable<TroubleTicketModel> GetActiveRecords()
        {
            List<TroubleTicketModel> FirstTix = new List<TroubleTicketModel>(); // list to hold TroubleTickets from db table

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string strSQL = "SELECT * FROM TroubleTickets ORDER BY Orig_Date;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(); //populate the data reader from db

                    //loop thru each record
                    //for each, fill a temp trouble ticket obj w current records data
                    //then add this temp ticket obj to the list - list will be avail to the CSHTML to format
                    while (rdr.Read())
                    {
                        TroubleTicketModel ticket = new TroubleTicketModel();

                        ticket.Ticket_ID = Convert.ToInt32(rdr["Ticket_ID"]);   //needed to convert to string, then int32
                        ticket.Ticket_Title = rdr["Ticket_Title"].ToString();
                        ticket.Category = rdr["Category"].ToString();
                        ticket.Reporting_Email = rdr["Reporting_Email"].ToString();
                        ticket.Orig_Date = DateTime.Parse(rdr["Orig_Date"].ToString());     //needed to convert to string, then to date
                        ticket.Active = Boolean.Parse(rdr["Active"].ToString());            // needed to parse to string, then to a boolean
                        ticket.Responder_Email = rdr["Responder_Email"].ToString();
                        ticket.Responder_Notes = rdr["Responder_Notes"].ToString();

                        FirstTix.Add(ticket); //add newly created ticket and add to the list of tix

                    }
                    con.Close();
                }
            }
            catch(Exception err)
            {
                //nothing at the moment
            }
            return FirstTix;      //return the list so the razor page can build the html table based on the list
        }//------ end of IEnumerable --------


    }
}
