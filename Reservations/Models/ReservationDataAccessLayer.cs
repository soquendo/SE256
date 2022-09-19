using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using Reservations.Models;

using Microsoft.Extensions.Configuration;


namespace Reservations.Models
{
    public class ReservationDataAccessLayer
    {
        string connectionString; //string that receives connection str from constructor

        private readonly IConfiguration _configuration; //instance of IConfiguration class - allows us to read in from config file like appsettings

        //razor page creates this data factory and passes the config obj to it
        public ReservationDataAccessLayer(IConfiguration configuration)
        {
            //via config obj, we can collect conn string for this proj
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public void Create(ReservationModel ticket)
        {
            //a little more efficient bc it deletes sql conn and anything inside when brackets close
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //sql statement to add a record with start info [lacks response/solution - this is for update]
                //we are using parameters to avoid issues with hacks like sql injection hacks

                string sql = "INSERT Into AddReservations (Reserv_PartyName, Reserv_People, Reserv_Date, Reserv_Phone, Reserv_Email, ConfirmEmail, mailList) VALUES (@Reserv_PartyName, @Reserv_People, @Reserv_Date, @Reserv_Phone, @Reserv_Email, @ConfirmEmail, @mailList);";

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
                        command.Parameters.AddWithValue("@Reserv_PartyName", ticket.Reserv_PartyName);
                        command.Parameters.AddWithValue("@Reserv_People", ticket.Reserv_People);
                        command.Parameters.AddWithValue("@Reserv_Date", DateTime.Now);
                        //command.Parameters.AddWithValue("@Reserv_Time", ticket.Reserv_Time);
                        command.Parameters.AddWithValue("@Reserv_Phone", ticket.Reserv_Phone);
                        command.Parameters.AddWithValue("@Reserv_Email", ticket.Reserv_Email);
                        command.Parameters.AddWithValue("@ConfirmEmail", ticket.ConfirmEmail);
                        command.Parameters.AddWithValue("@mailList", ticket.mailList);



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

        public IEnumerable<ReservationModel> GetActiveRecords()
        {
            List<ReservationModel> lstReservs = new List<ReservationModel>(); // list to hold reservations from db table

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string strSQL = "SELECT * FROM AddReservations ORDER BY Reserv_Date;";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(); //populate the data reader from db

                    //loop thru each record
                    //for each, fill a temp trouble ticket obj w current records data
                    //then add this temp ticket obj to the list - list will be avail to the CSHTML to format
                    while (rdr.Read())
                    {
                        ReservationModel ticket = new ReservationModel();

                        ticket.Reserv_ID = Convert.ToInt32(rdr["Reserv_ID"]);   //needed to convert to string, then int32
                        ticket.Reserv_PartyName = rdr["Reserv_PartyName"].ToString();
                        ticket.Reserv_People = Convert.ToInt32(rdr["Reserv_People"]);
                        ticket.Reserv_Date = DateTime.Parse(rdr["Reserv_Date"].ToString());     //needed to convert to string, then to date
                        //ticket.Reserv_Time = DateTime.Parse(rdr["Reserv_Time"].ToString()); //cant get time to work yet
                        ticket.Reserv_Phone = rdr["Reserv_Phone"].ToString();
                        ticket.Reserv_Email = rdr["Reserv_Email"].ToString();
                        ticket.ConfirmEmail = rdr["ConfirmEmail"].ToString();
                        ticket.mailList = Boolean.Parse(rdr["mailList"].ToString());
                        //ticket.Active = Boolean.Parse(rdr["Active"].ToString());            // needed to parse to string, then to a boolean
                        
                        

                        lstReservs.Add(ticket); //add newly created ticket and add to the list of tix

                    }
                    con.Close();
                }
            }
            catch (Exception err)
            {
                //nothing at the moment
            }
            return lstReservs;      //return the list so the razor page can build the html table based on the list
        }//------ end of IEnumerable --------


    }
}
