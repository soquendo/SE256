using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using midterm_oquendo;
using System.Data;
using System.Data.SqlClient;

namespace SE256_Activity_SOquendo.App_Code
{
    public class EBook
    {
        private DateTime dateRentalExpires;
        private int bookmarkPage;
        private int eBook_ID;

        public DateTime DateRentalExpires
        {
            get
            {
                return dateRentalExpires;
            }

            set
            {
                if (ValidationLibrary.IsAFutureDate(value))
                {
                    dateRentalExpires = value;
                }
                else
                {
                    feedback += "\nERROR: You must enter future dates";
                }
            }
        }//--------- end of DateRentalExpires ----------------

        public Int32 EBook_ID
        {
            get
            {
                return eBook_ID;
            }

            set
            {
                if (value >= 0)
                {
                    eBook_ID = value;
                }
                else
                {
                    feedback += "\nERROR: Sorry you entered invalid EBook ID";
                }
            }
        }//------- end of Int32 EBook_ID ----------------

        public int BookmarkPage
        {
            get
            {
                return bookmarkPage;
            }

            set
            {
                if (value >= 0 && value <= Pages)
                {
                    bookmarkPage = value;
                }
                else
                {
                    feedback += "\nERROR: Sorry you entered an invalid page number for a bookmark";
                }
            }
        }

        private string GetConnected()
        {
            return @"Server=sql.neit.edu\studentsqlserver,4500;Database=SE245_SLambert;User Id=SE245_SOquendo;Password=008016420;";
        }

        public EBook() : base() //calls the parents constructor
        {
            BookmarkPage = 0;
            dateRentalExpires = DateTime.Now.AddDays(14);
        }

        public string AddARecord()
        {
            string strResult = ""; //init string var
            SqlConnection Conn = new SqlConnection(); //make connection to obj
            Conn.ConnectionString = @GetConnected(); //set who, what, where of DB

            string strSQL = "INSERT INTO EBooks (Title, AuthorFirst, AuthorLast, Email, Pages, DatePublished, DateRentalExpires, BookmarkPage) VALUES (@Title, @AuthorFirst, @AuthorLast, @Email, @Pages, @DatePublished, @DateRentalExpires, @BookmarkPage)";
            //bark out our command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //commander knows what to say
            comm.Connection = Conn;     //heres the phone

            comm.Parameters.AddWithValue("@Title", Title);
            comm.Parameters.AddWithValue("@AuthorFirst", AuthorFirst);
            comm.Parameters.AddWithValue("@AuthorLast", AuthorLast);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@Pages", Pages);
            comm.Parameters.AddWithValue("@DatePublished", DatePublished);
            comm.Parameters.AddWithValue("@DateRentalExpires", DateRentalExpires);
            comm.Parameters.AddWithValue("@BookmarkPage", BookmarkPage);

            //connect to server
            try
            {
                Conn.Open();        //open conn to DB - like dialing a phone
                int intRecs = comm.ExecuteNonQuery();
                strResult = $"SUCCESS: Inserted {intRecs} recorsd.";    //report making the connection and adding record
                Conn.Close();       //hang up after call
            }
            catch (Exception err)   //reaching this means a prob conn to DB
            {
                strResult = "ERROR: " + err.Message;    // set feedback to state there was an error
            }
            finally
            {

            }
            //return result feedback string
            return strResult;
        }//------- end of AddARecord() ---------------
    }//---------- end of EBook class ---------------
}