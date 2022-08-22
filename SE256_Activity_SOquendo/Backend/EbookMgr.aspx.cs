using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

using SE256_Activity_SOquendo.App_Code;

namespace SE256_Activity_SOquendo.Backend
{
    public partial class EbookMgr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null && Session["LoggedIn"].ToString() == "TRUE")
            {
                //theyre good
            }
            else
            {
                Response.Redirect("~/Backend/Default.aspx");
            }

            //code to check if there is an existing EBook ID that we need to pull up

            string strEBook_ID = "";
            int intEBook_ID = 0;

            //does eBook_ID exist?
            if ((!IsPostBack) && Request.QueryString["EBook_ID"] != null)
            {
                //if there is an ID, there is no need to show the Add button
                //btnAdd.Visible = true;
                //btnAdd.Enabled = false;
                //btnDelete.Visible = true; //not visible
                //btnUpdate.Visible = true;
                //btnDelete.Enabled = true; //not enabled
                //btnUpdate.Enabled = true;

                //If so.. gather person's ID and fill form
                strEBook_ID = Request.QueryString["EBook_ID"].ToString();
                lblEBook_ID.Text = strEBook_ID;
                
                intEBook_ID = Convert.ToInt32(strEBook_ID);

                //Fill the "temp" person's info based on ID
                EBook temp = new EBook();
                SqlDataReader dr = temp.FindOneBook(intEBook_ID);

                while (dr.Read())
                {
                    txtTitle.Text = dr["Title"].ToString();
                    txtAuthorFirst.Text = dr["AuthorFirst"].ToString();
                    txtAuthorLast.Text = dr["AuthorLast"].ToString();
                    txtAuthorEmail.Text = dr["Email"].ToString();
                    txtPages.Text = dr["Pages"].ToString();
                    txtPrice.Text = dr["Price"].ToString();
                    txtBookmarkPage.Text = dr["BookmarkPage"].ToString();

                    //calDatePublished.VisibleDate = DateTime.Parse(dr["DatePublished"].ToString()).Date;
                    calDatePublished.SelectedDate = DateTime.Parse(dr["DatePublished"].ToString()).Date;

                    //calRentalExpires.VisibleDate = DateTime.Parse(dr["DateRentalExpires"].ToString()).Date;
                    calRentalExpires.SelectedDate = DateTime.Parse(dr["DateRentalExpires"].ToString()).Date;

                }

            }
            else
            {
                //no ebook id, so it must be an add. hide the delete and update buttons
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
            EBook temp = new EBook();

            temp.Title = txtTitle.Text;
            temp.AuthorFirst = txtAuthorFirst.Text;
            temp.AuthorLast = txtAuthorLast.Text;
            temp.Email = txtAuthorEmail.Text;
            temp.DatePublished = calDatePublished.SelectedDate;
            temp.DateRentalExpires = calRentalExpires.SelectedDate;

            Int32 intPages = 0;
            if (Int32.TryParse(txtPages.Text, out intPages))
            {
                temp.Pages = intPages;
            }

            Double dblPrice = 0;
            if (Double.TryParse(txtPrice.Text, out dblPrice))
            {
                temp.Price = dblPrice;
            }

            // if bookmark page is legit int, we copy it to the obj
            Int32 intBookmarkPage = 0;
            if (Int32.TryParse(txtBookmarkPage.Text, out intBookmarkPage))
            {
                temp.BookmarkPage = intBookmarkPage;
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
            EBook temp = new EBook();
            temp.EBook_ID = Int32.Parse(lblEBook_ID.Text);

            temp.Title = txtTitle.Text;
            temp.AuthorFirst = txtAuthorFirst.Text;
            temp.AuthorLast = txtAuthorLast.Text;
            temp.Email = txtAuthorEmail.Text;
            temp.DatePublished = calDatePublished.SelectedDate;
            temp.DateRentalExpires = calRentalExpires.SelectedDate;

            Int32 intPages = 0;                 //if number of pages is a legit int, we copy it to the obj
            if (Int32.TryParse(txtPages.Text, out intPages))
            {
                temp.Pages = intPages;
            }

            Double dblPrice = 0;
            if (Double.TryParse(txtPrice.Text, out dblPrice))
            {
                temp.Price = dblPrice;
            }

            // if bookmark page is legit int, we copy it to the obj
            Int32 intBookmarkPage = 0;
            if (Int32.TryParse(txtBookmarkPage.Text, out intBookmarkPage))
            {
                temp.BookmarkPage = intBookmarkPage;
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
            Int32 intEBook_ID = Convert.ToInt32(lblEBook_ID.Text); //get the ID from the label

            //create EBook so we can use the delete method
            EBook temp = new EBook();

            //use the EBook ID and pass it to the delete func and get number of records deleted
            lblFeedback.Text = temp.DeleteOneEBook(intEBook_ID);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/backend/ControlPanel");        //send user back to control panel
        }


    }
}