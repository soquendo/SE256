using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using midterm_oquendo;
using System.Data;
using System.Data.SqlClient;

namespace SE256_ASPLab_SOquendo.App_Code
{
    public class EInvt: Invt
    {
        
        private int eInvt_ID;

        public Int32 EInvt_ID
        {
            get
            {
                return eInvt_ID;
            }

            set
            {
                if (value >= 0)
                {
                    eInvt_ID = value;
                }
                else
                {
                    feedback += "\nERROR: Sorry you entered invalid EInvt ID";
                }
            }
        }//------- 

        private string GetConnected()
        {
            return @"Server=sql.neit.edu\studentsqlserver,4500;Database=SE133_SOquendo;User Id=SE133_SOquendo;Password=008016420;";
        }

        public EInvt() : base() //calls the parents constructor
        {
            //BookmarkPage = 0;
            //dateRentalExpires = DateTime.Now.AddDays(14);
        }

        public string AddARecord()
        {
            string strResult = ""; //init string var
            SqlConnection Conn = new SqlConnection(); //make connection to obj
            Conn.ConnectionString = @GetConnected(); //set who, what, where of DB

            string strSQL = "INSERT INTO EInvts (Color, Size, Style, Email, Price) VALUES (@Color, @Size, @Style, @Email, @Price)";
            //bark out our command
            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL;  //commander knows what to say
            comm.Connection = Conn;     //heres the phone

            comm.Parameters.AddWithValue("@Color", Color);
            comm.Parameters.AddWithValue("@Size", Size);
            comm.Parameters.AddWithValue("@Style", Style);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@Price", Price);

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

        public DataSet SearchEInvts_DS(String strColor, String strSize)
        {
            //create dataset to return filled
            DataSet ds = new DataSet();

            //create command for SQL statement
            SqlCommand comm = new SqlCommand();

            //write select statement to perform search
            String strSQL = "SELECT EInvt_ID, Color, Size, Style FROM EInvts WHERE 0=0";

            //if the first/last name is filled in include it as search criteria
            if (strColor.Length > 0)
            {
                strSQL += " AND Title LIKE @Title";
                comm.Parameters.AddWithValue("@Title", "%" + strColor + "%");
            }
            if (strSize.Length > 0)
            {
                strSQL += " AND AuthorLast LIKE @AuthorLast";
                comm.Parameters.AddWithValue("@AuthorLast", "%" + strSize + "%");
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
            da.Fill(ds, "EInvts_Temp");     //fill dataset with results from database and call it "EBooks_Temp"
            conn.Close();   //close conn (hangs up phone)

            //return data
            return ds;
        }

        public SqlDataReader SearchEInvts_DR(String strColor, String strSize)
        {
            //declare a datareader to return filled
            SqlDataReader dr;
            //create a command for SQL statement
            SqlCommand comm = new SqlCommand();
            //Write a Select statement to perform search
            String strSQL = "SELECT EInvt_ID, Color, Size, Style FROM EInvts WHERE 0=0";

            //if the first/last name is filled in, include it as search criteria
            if (strColor.Length > 0)
            {
                strSQL += " AND Title LIKE @Title";
                comm.Parameters.AddWithValue("@Title", "%" + strColor + "%");
            }
            if (strSize.Length > 0)
            {
                strSQL += " AND Size LIKE @Size";
                comm.Parameters.AddWithValue("@Size", "%" + strSize + "%");
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

        public SqlDataReader FindOneInvt(int intEBook_ID)
        {
            //create and initialize the DB tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            string strConn = GetConnected(); //my connection string

            //my SQL command string to pull up one ebook's data
            string sqlString = "SELECT * FROM EInvts WHERE EInvt_ID = @EInvt_ID;";

            conn.ConnectionString = strConn; //tell the conn obj the who what where how

            //give the command obj the info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("EInvt_ID", intEInvt_ID);

            //open the database conn and yell our SQL command
            conn.Open();

            //return some form of feedback
            return comm.ExecuteReader();    //return the dataset to be used by other - the calling form
        }//----- end of public SqlDataReader 

        public string DeleteOneEInvt(int intEInvt_ID)
        {
            Int32 intRecords = 0;
            string strResult = "";

            //create and initialize the DB tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            //my conn string
            string strConn = GetConnected();

            //my sql command string to pull up ebook data
            string sqlString = "DELETE FROM EInvts WHERE EInvt_ID = @EInvt_ID;";

            //tell the ocnn obj the who what where how
            conn.ConnectionString = strConn;

            //give the command obj info it needs
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@EInvt_ID", intEInvt_ID);

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
            string strSQL = "UPDATE EInvts SET Color = @Color, Size = @Size, Style = @Style, Email=@Email, Price=@Price WHERE EInvt_ID=@EInvt_ID;";

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
            comm.Parameters.AddWithValue("@Color", Color);
            comm.Parameters.AddWithValue("@Size", Size);
            comm.Parameters.AddWithValue("@Style", Style);
            comm.Parameters.AddWithValue("@Email", Email);
            comm.Parameters.AddWithValue("@Price", Price);
            comm.Parameters.AddWithValue("@EInvt_ID", EInvt_ID);

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



    }
}