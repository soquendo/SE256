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
            List<TroubleTicketModel> lstTix = new List<TroubleTicketModel>(); // list to hold TroubleTickets from db table

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

                        lstTix.Add(ticket); //add newly created ticket and add to the list of tix

                    }
                    con.Close();
                }
            }
            catch(Exception err)
            {
                //nothing at the moment
            }
            return lstTix;      //return the list so the razor page can build the html table based on the list
        }//------ end of IEnumerable --------

        public TroubleTicketModel GetOneRecord(int? id)
        {
            TroubleTicketModel ticket = new TroubleTicketModel(); // Placeholder for record based on ID

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Configure our command onject with SQL statement and connection
                    string strSQL = "SELECT * FROM TroubleTickets WHERE Ticket_ID = @Ticket_ID;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Ticket_ID", id); // Set the parameter using the method param

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(); // Populate the data reader (rdr) from DB

                    // Loop through each record
                    // For each record fill a temporary trouble ticket object with current record's data
                    // Then add this temporary ticket object to the list. List will be available to the CSHTML to format.
                    while (rdr.Read())
                    {
                        ticket.Ticket_ID = Convert.ToInt32(rdr["Ticket_ID"]); // Needed to convert to string, the Int32
                        ticket.Ticket_Title = rdr["Ticket_Title"].ToString();
                        ticket.Category = rdr["Category"].ToString();
                        ticket.Reporting_Email = rdr["Reporting_Email"].ToString();
                        ticket.Orig_Date = DateTime.Parse(rdr["Orig_Date"].ToString()); // Needed to parse to sting, then to a Boolean
                        ticket.Reporting_Email = rdr["Responder_Email"].ToString();
                        ticket.Responder_Notes = rdr["Responder_Notes"].ToString();


                        // Create a DateTime object, if there is an existing close date, tempDate gets filled with TryParse
                        DateTime tempDate;
                        if (rdr["Close_Date"] != null && DateTime.TryParse(rdr["Close_Date"].ToString(), out tempDate))
                        {
                            ticket.Close_Date = tempDate; // If there is a date in tempDate, store it in Close_Date property/field
                        }

                        ticket.Ticket_Desc = rdr["Ticket_Desc"].ToString();
                    }
                    con.Close();
                }
            }
            catch (Exception err) // If there is a runtime error during TRY, we catch it and store error in Feedback
            {

                ticket.Feedback = "ERROR: " + err.Message;

            }

            return ticket; // Return the list so the Razor page can build HTML table based on this list
        }

        // To Update the records of a particular trouble ticket
        public void UpdateTicket(TroubleTicketModel tTicket)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(); // Create a basic command onject and add SQL and Conn later

                    // Because Close_Date is only necessary during a Closure of a Ticket, we use an if statement to set our SQL statement
                    string strSQL;
                    if (tTicket.Active == false)
                    {
                        strSQL = "UPDATE TroubleTickets SET Responder_Email = @Responder_Email, Responder_Notes = @Responder_Notes, " + "Close_Date = @Close_Date, Active = @Active WHERE Ticket_ID = @Ticket_ID;";

                    }
                    else
                    {
                        strSQL = "UPDATE TroubleTickets SET Responder_Email = @Responder_Email, Responder_Notes = @Responder_Notes, " + "Active = @Active WHERE Ticket_ID = @Ticket_ID;";
                    }

                    // Configure the command object
                    cmd.CommandText = strSQL;
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;

                    // Fill parameters with form values
                    cmd.Parameters.AddWithValue("@Responder_Email", tTicket.Responder_Email);
                    cmd.Parameters.AddWithValue("@Responder_Notes", tTicket.Responder_Notes);

                    // If this ticket is being closed, then set the date for close_date
                    if (tTicket.Active == false)
                    {
                        cmd.Parameters.AddWithValue("@Close_Date", DateTime.Now);
                    }

                    cmd.Parameters.AddWithValue("@Active", tTicket.Active);

                    cmd.Parameters.AddWithValue("@Ticket_ID", tTicket.Ticket_ID);

                    // DO the update deed
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                }
            }
            catch (Exception err)
            {
                // If there is a runtime error, report it in feedback
                tTicket.Feedback = "ERROR: " + err.Message;
            }

        }
        public TroubleTicketModel DeleteTicket(int? id)
        {
            TroubleTicketModel ticket = new TroubleTicketModel(); // Pleaceholder for record based on ID
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string strSQL = "DELETE FROM TroubleTickets WHERE Ticket_ID = @Ticket_ID;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Ticket_ID", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception err)
            {
                // If there is a runtime error, report it in feedback
                ticket.Feedback = "ERROR: " + err.Message;
            }

            return ticket;
        }
    }
}
