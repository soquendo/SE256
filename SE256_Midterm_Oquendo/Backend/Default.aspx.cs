using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE256_Midterm_Oquendo.Backend
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUName.Text == "Scott" && txtPW.Text == "NEIT")
            {
                //if we have a match for both user and pw, set sessions so other paes know they logged in and give msg.
                Session["UName"] = txtUName.Text;
                Session["LoggedIn"] = "TRUE";
                lblFeedback.Text = "Successful Login.. Now what do you want to do?";
                Response.Redirect("~/Backend/ControlPanel.aspx"); //Do not stick around, send them to control panel
            }
            else
            {
                //Else.. we do not have both matches, so we set clear any potential session vars and give msg.
                Session["UName"] = "";
                Session["LoggedIn"] = "FALSE";
                lblFeedback.Text = "Login failed.. please try again, or go away.";
            }
        }

    }
}