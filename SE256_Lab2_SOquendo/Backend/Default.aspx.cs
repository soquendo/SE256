﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE256_Lab2_SOquendo.Backend
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUName.Text == "Scott" && txtPW.Text == "NEIT")
            {
                Session["UName"] = txtUName.Text;
                Session["LoggedIn"] = "TRUE";
                lblFeedback.Text = "Successful Login";
                Response.Redirect("~/Backend/ControlPanel.aspx");
            }
            else
            {
                Session["UName"] = "";
                Session["LoggedIn"] = "FALSE";
                lblFeedback.Text = "Login Failed.. please try again";
            }
        }
    }
}