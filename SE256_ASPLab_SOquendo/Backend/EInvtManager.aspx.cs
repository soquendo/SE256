using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SE256_ASPLab_SOquendo.App_Code;

namespace SE256_ASPLab_SOquendo.Backend
{
    public partial class EinvtMgr : System.Web.UI.Page
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

            string strEInvt_ID = "";
            int intEInvt_ID = 0;

            //does eBook_ID exist?
            if ((!IsPostBack) && Request.QueryString["EInvt_ID"] != null)
            {
                //if there is an ID, there is no need to show the Add button
                //btnAdd.Visible = true;
                //btnAdd.Enabled = false;
                //btnDelete.Visible = true; //not visible
                //btnUpdate.Visible = true;
                //btnDelete.Enabled = true; //not enabled
                //btnUpdate.Enabled = true;

                //If so.. gather person's ID and fill form
                strEInvt_ID = Request.QueryString["EInvt_ID"].ToString();
                lblEInvt_ID.Text = strEInvt_ID;

                intEInvt_ID = Convert.ToInt32(strEInvt_ID);

                //Fill the "temp" person's info based on ID
                EInvt temp = new EInvt();
                SqlDataReader dr = temp.FindOneOrder(intEInvt_ID);

                while (dr.Read())
                {
                    txtColor.Text = dr["Color"].ToString();
                    txtSize.Text = dr["Size"].ToString();
                    txtStyle.Text = dr["Style"].ToString();
                    txtUserEmail.Text = dr["Email"].ToString();
                    txtPrice.Text = dr["Price"].ToString();


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
            EInvt temp = new EInvt();

            temp.Color = txtColor.Text;
            temp.Size = txtSize.Text;
            temp.Style = txtStyle.Text;
            temp.Email = txtUserEmail.Text;

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
            EInvt temp = new EInvt();
            temp.EInvt_ID = Int32.Parse(lblEInvt_ID.Text);

            temp.Color = txtColor.Text;
            temp.Size = txtSize.Text;
            temp.Style = txtStyle.Text;
            temp.Email = txtUserEmail.Text;


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
            Int32 intEInvt_ID = Convert.ToInt32(lblEInvt_ID.Text); //get the ID from the label

            //create EBook so we can use the delete method
            EInvt temp = new EInvt();

            //use the EBook ID and pass it to the delete func and get number of records deleted
            lblFeedback.Text = temp.DeleteOneEInvt(intEInvt_ID);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/backend/ControlPanel");        //send user back to control panel
        }


    }
}