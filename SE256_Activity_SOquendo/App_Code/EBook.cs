using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using midterm_oquendo;
using System.Data;
using System.Data.SqlClient;

namespace SE256_Activity_SOquendo.App_Code
{
    public class EBook: Book
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
            return @"Server=sql.neit.edu\studentsqlserver,4500;Database=SE133_SOquendo;User Id=SE133_SOquendo;Password=008016420;";
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

            string strSQL = "INSERT INTO EBooks (Title, AuthorFirst, AuthorLast, Email, Pages, Price, DatePublished, DateRentalExpires, BookmarkPage) VALUES (@Title, @AuthorFirst, @AuthorLast, @Email, @Pages, @Price, @DatePublished, @DateRentalExpires, @BookmarkPage)";
            //bark out our command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //commander knows what to say
            comm.Connection = Conn;     //heres the phone

            comm.Parameters.AddWithValue("@Title", Title);
            comm.Parameters.AddWithValue("@AuthorFirst", AuthorFirst);
            comm.Parameters.AddWithValue("@AuthorLast", AuthorLast);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@Pages", Pages);
            comm.Parameters.AddWithValue("@Price", Price);
            comm.Parameters.AddWithValue("@DatePublished", DatePublished);
            comm.Parameters.AddWithValue("@DateRentalExpires", DateRentalExpires);
            comm.Parameters.AddWithValue("@BookmarkPage", BookmarkPage);

            //connect to server
            try
            {
                Conn.Open();        //open conn to DB - like dialing a phone
                int intRecs = comm.ExecuteNonQuery();
                strResult = $"SUCCESS: Inserted {intRecs} records.";    //report making the connection and adding record
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

        public DataSet SearchEBooks_DS(String strTitle, String strAuthorLast)
        {
            //create dataset to return filled
            DataSet ds = new DataSet();

            //create command for SQL statement
            SqlCommand comm = new SqlCommand();

            //write select statement to perform search
            String strSQL = "SELECT EBook_ID, Title, AuthorFirst, AuthorLast, DatePublished FROM EBooks WHERE 0=0";

            //if the first/last name is filled in include it as search criteria
            if (strTitle.Length > 0)
            {
                strSQL += " AND Title LIKE @Title";
                comm.Parameters.AddWithValue("@Title", "%" + strTitle + "%");
            }
            if (strAuthorLast.Length > 0)
            {
                strSQL += " AND AuthorLast LIKE @AuthorLast";
                comm.Parameters.AddWithValue("@AuthorLast", "%" + strAuthorLast + "%");
            }

            //create DB tools and configure
            SqlConnection conn = new SqlConnection();
            //Create the who, what where of the DB
            string strConn = @GetConnected();
            conn.ConnectionString = strConn;

            //Fill in basic infor to command obj
            comm.Connection = conn;     //tell commander what conn to use
            comm.CommandText = strSQL;  //tell commander what to say

            //create data adapter
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;    //commander needs a translator(dataAdapter) to speak with datasets

            //--------------------------------------

            //get data
            conn.Open();        //open conn (pick up phone)
            da.Fill(ds, "EBooks_Temp");     //fill dataset with results from database and call it "EBooks_Temp"
            conn.Close();   //close conn (hangs up phone)

            //return data
            return ds;
        }

        public SqlDataReader SearchEBooks_DR(String strTitle, String strAuthorLast)
        {
            //declare a datareader to return filled
            SqlDataReader dr;
            //create a command for SQL statement
            SqlCommand comm = new SqlCommand();
            //Write a Select statement to perform search
            String strSQL = "SELECT EBook_ID, Title, AuthorFirst, AuthorLast, DatePublished FROM EBooks WHERE 0=0";

            //if the first/last name is filled in, include it as search criteria
            if (strTitle.Length > 0)
            {
                strSQL += " AND Title LIKE @Title";
                comm.Parameters.AddWithValue("@Title", "%" + strTitle + "%");
            }
            if (strAuthorLast.Length > 0)
            {
                strSQL += " AND AuthorLast LIKE @AuthorLast";
                comm.Parameters.AddWithValue("@AuthorLast", "%" + strAuthorLast + "%");
            }

            //create DB tools and configure
            SqlConnection conn = new SqlConnection();
            //Create the who, what, where of the DB
            string strConn = @GetConnected();
            conn.ConnectionString = strConn;

            //Fill in basic info to command obj
            comm.Connection = conn; //tell commander what connection to use
            comm.CommandText = strSQL; // tell the commander what to say

            //-----------------------------------

            //get data
            conn.Open();                //open the connection (pick up phone)
            dr = comm.ExecuteReader();  //fill dataset with results from database
            //conn.CLOSE(); //closing conn will destroy the data reader

            //return the data
            return dr;
        }

        public SqlDataReader FindOneBook(int intEBook_ID)
        {
            //create and initialize the DB tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            string strConn = GetConnected(); //my connection string

            //my SQL command string to pull up one ebook's data
            string sqlString = "SELECT * FROM EBooks WHERE EBook_ID = @EBook_ID;";

            conn.ConnectionString = strConn; //tell the conn obj the who what where how

            //give the command obj the info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("EBook_ID", intEBook_ID);

            //open the database conn and yell our SQL command
            conn.Open();

            //return some form of feedback
            return comm.ExecuteReader();    //return the dataset to be used by other - the calling form
        }//----- end of public SqlDataReader 

        public string DeleteOneEBook(int intEBook_ID)
        {
            Int32 intRecords = 0;
            string strResult = "";

            //create and initialize the DB tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //my conn string
            string strConn = GetConnected();

            //my sql command string to pull up ebook data
            string sqlString = "DELETE FROM EBooks WHERE EBook_ID = @EBook_ID;";

            //tell the ocnn obj the who what where how
            conn.ConnectionString = strConn;

            //give the command obj info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@EBook_ID", intEBook_ID);

            try
            {
                //open the conn
                conn.Open();

                //run the delete and store the number of records affected
                intRecords = comm.ExecuteNonQuery();
                strResult = intRecords.ToString() + " Records Deleted.";
            }
            catch (Exception err)
            {
                strResult = "ERROR: " + err.Message;    //set feedback to state there was an error
            }
            finally
            {
                conn.Close();
            }
            return strResult;
        }//------------ end of DeleteOneEBook -----------------

        public string UpdateARecord()
        {
            Int32 intRecords = 0;
            string strResult = "";

            //create sql command string
            string strSQL = "UPDATE EBooks SET Title = @Title, AuthorFirst = @AuthorFirst, AuthorLast = @AuthorLast, Email=@Email, Pages=@Pages, Price=@Price, DatePublished=@DatePublished, DateRentalExpires=@DateRentalExpires, BookmarkPage=@BookmarkPage, WHERE EBook_ID=@EBook_ID;";

            //create a conn to DB
            SqlConnection conn = new SqlConnection();
            //create whowhatwhere of the DB
            string strConn = GetConnected();
            conn.ConnectionString = strConn;

            //bark otu command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL; //commander knows what to say
            comm.Connection = conn;     //heres the phone

            //fill in parameters - has to be created in same sequence as they are in the sql statement
            comm.Parameters.AddWithValue("@Title", Title);
            comm.Parameters.AddWithValue("@AuthorFirst", AuthorFirst);
            comm.Parameters.AddWithValue("@AuthorLast", AuthorLast);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@Pages", Pages);
            comm.Parameters.AddWithValue("@Price", Price);
            comm.Parameters.AddWithValue("@DatePublished", DatePublished);
            comm.Parameters.AddWithValue("@DateRentlaExpires", DateRentalExpires);
            comm.Parameters.AddWithValue("@BookmarkPage", BookmarkPage);
            comm.Parameters.AddWithValue("@EBook_ID", EBook_ID);

            try
            {
                //open the conn
                conn.Open();

                //run the update and store the number of records affected
                intRecords = comm.ExecuteNonQuery();
                strResult = intRecords.ToString() + " Records Updated.";
            }
            catch (Exception err)
            {
                strResult = "ERROR: " + err.Message; //set feedback to state there was error
            }
            finally
            {
                //close the connection
                conn.Close();
            }

            return strResult;

        }//----------- end of UpdateARecord ----------------



    }//---------- end of EBook class ---------------
}