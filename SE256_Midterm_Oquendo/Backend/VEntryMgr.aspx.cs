using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

using SE256_Midterm_Oquendo.App_Code;

namespace SE256_Midterm_Oquendo.Backend
{
    public partial class VEntryMgr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null && Session["LoggedIn"].ToString() == "TRUE")
            {
                //good
            }
            else
            {
                Response.Redirect("~/Backend/Default.aspx");
            }

            //code to check if there is an existing EBook ID that we need to pull up

            string strVEntry_ID = "";
            int intVEntry_ID = 0;

            //does vEntry_ID exist?
            if ((!IsPostBack) && Request.QueryString["VEntry_ID"] != null)
            {
                //if there is an ID, there is no need to show the Add button
                //btnAdd.Visible = true;
                //btnAdd.Enabled = false;
                //btnDelete.Visible = true; //not visible
                //btnUpdate.Visible = true;
                //btnDelete.Enabled = true; //not enabled
                //btnUpdate.Enabled = true;

                //If so.. gather person's ID and fill form
                strVEntry_ID = Request.QueryString["VEntry_ID"].ToString();
                lblVEntry_ID.Text = strVEntry_ID;

                intVEntry_ID = Convert.ToInt32(strVEntry_ID);

                //Fill the "temp" person's info based on ID
                VEntry temp = new VEntry();
                SqlDataReader dr = temp.FindOneMovie(intVEntry_ID);

                while (dr.Read())
                {
                    txtTitle.Text = dr["Title"].ToString();
                    txtGenre.Text = dr["Genre"].ToString();
                    txtRating.Text = dr["Rating"].ToString();
                    txtRuntime.Text = dr["Runtime"].ToString();
                    txtPrice.Text = dr["Price"].ToString();

                    //calDatePublished.VisibleDate = DateTime.Parse(dr["DatePublished"].ToString()).Date;
                    calYear.SelectedDate = DateTime.Parse(dr["Year"].ToString()).Date;

                    //calRentalExpires.VisibleDate = DateTime.Parse(dr["DateRentalExpires"].ToString()).Date;
                    calRentalExpires.SelectedDate = DateTime.Parse(dr["DateRentalExpires"].ToString()).Date;

                }

            }
            else
            {
                //no ventry id, so it must be an add. hide the delete and update buttons
                //btnAdd.Visible = true;
                //btnAdd.Enabled = true;
                //btnDelete.Visible = true; //not visible
                //btnUpdate.Visible = true;
                //btnDelete.Enabled = false; //not enabled
                //btnUpdate.Enabled = false;
            }


        }//----- end of Page Load -------------



        protected void btnAdd_Click(object sender, EventArgs e)
        {
            VEntry temp = new VEntry();

            temp.Title = txtTitle.Text;

            if (rdoAction.Checked)
                txtGenre.Text = "Action";
            else if (rdoAdventure.Checked)
                txtGenre.Text = "Adventure";
            else if (rdoComedy.Checked)
                txtGenre.Text = "Comedy";
            else if (rdoCrime.Checked)
                txtGenre.Text = "Crime";
            else if (rdoDrama.Checked)
                txtGenre.Text = "Drama";
            else if (rdoHorror.Checked)
                txtGenre.Text = "Horror";
            else if (rdoSciFi.Checked)
                txtGenre.Text = "Science Fiction";
            else if (rdoSuspense.Checked)
                txtGenre.Text = "Suspense";

            temp.Genre = txtGenre.Text;
            temp.Rating = txtRating.Text;
            temp.Runtime = txtRuntime.Text;
            temp.Year = calYear.SelectedDate;
            temp.DateRentalExpires = calRentalExpires.SelectedDate;

            Double dblPrice = 0;
            if (Double.TryParse(txtPrice.Text, out dblPrice))
            {
                temp.Price = dblPrice;
            }

            if (temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text = temp.Feedback;
            }
            else
            {
                lblFeedback.Text = temp.AddARecord();
            }
        }//---------- end of btnAdd_Click -------------

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            VEntry temp = new VEntry();
            temp.VEntry_ID = Int32.Parse(lblVEntry_ID.Text);

            temp.Title = txtTitle.Text;
            temp.Genre = txtGenre.Text;
            temp.Rating = txtRating.Text;
            temp.Runtime = txtRuntime.Text;
            temp.Year = calYear.SelectedDate;
            temp.DateRentalExpires = calRentalExpires.SelectedDate;

            Double dblPrice = 0;
            if (Double.TryParse(txtPrice.Text, out dblPrice))
            {
                temp.Price = dblPrice;
            }

            if (temp.Feedback.Contains("ERROR:"))
            {
                lblFeedback.Text = temp.Feedback;
            }
            else
            {
                lblFeedback.Text = temp.UpdateARecord();
            }
        } //----------------end of btnUpdate_Click---------------------

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Int32 intVEntry_ID = Convert.ToInt32(lblVEntry_ID.Text); //get the ID from the label

            //create VEntry so we can use the delete method
            VEntry temp = new VEntry();

            //use the VEntry ID and pass it to the delete func and get number of records deleted
            lblFeedback.Text = temp.DeleteOneVEntry(intVEntry_ID);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/backend/ControlPanel");        //send user back to control panel
        }
    }
}