using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

using SE256_Activity_SOquendo.App_Code;


namespace SE256_Activity_SOquendo
{
    public partial class EBookSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if user's loggd in, keep them here
            if (Session["LoggedIn"] != null && Session["LoggedIn"].ToString() == "TRUE")
            {
                //user is good
            }
            else
            {
                //if not logged in, send to backend to login
                Response.Redirect("~/Backend/Default.aspx");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Filling a dataset and binding it to a gridview obj
            //******************************

            EBook temp = new EBook(); //create person obj

            //use obj function to fill a dataset obj
            DataSet ds = temp.SearchEBooks_DS(txtTitle.Text, txtAuthorLast.Text);

            dgResults.DataSource = ds;          //point GV to dataset
            dgResults.DataMember = ds.Tables[0].TableName;  //point GV to the one table
            dgResults.DataBind();       //bind data (open faucet)

            //output results using a datareader bound to a repeater object
            //***************************

            SqlDataReader dr = null;

            //fill the reader with zero or more results
            dr = temp.SearchEBooks_DR(txtTitle.Text, txtAuthorLast.Text);

            //like connecting a hose, then turning faucet on
            rptSearch.DataSource = dr;  //point or connect the repeater to the reader
            rptSearch.DataBind();       //bind the data


            //output results using a datareader to fill in a literal obj
            dr = temp.SearchEBooks_DR(txtTitle.Text, txtAuthorLast.Text);
            //start the table
            litResults.Text = "<table>";
            //create a header row
            litResults.Text += "<th>Title</th><th>First Name</th><th>Last Name</th><th>Date Published</th><th>Edit Link</th>";

            //loop through the results and add each as their own table row
            while (dr.Read())
            {
                litResults.Text +=
                    "<tr>" +
                    "<td>" + dr["Title"].ToString() + "</td>" +
                    "<td>" + dr["AuthorFirst"].ToString() + "</td>" +
                    "<td>" + dr["AuthorLast"].ToString() + "</td>" +
                    "<td>" + dr["DatePublished"].ToString() + "</td>" +
                    "<td>" + "<a href='EBookMgr.aspx?EBook_ID=" + dr["eBook_ID"].ToString() + "'>Edit</a></td>" +
                    "</tr>";
            }

            //close hte table, once the loop adding results is complete
            litResults.Text += "</table>";

        }
    }
}