using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SE256_Lab2_SOquendo.App_Code;

namespace SE256_Lab2_SOquendo.Backend
{
    public partial class InventoryMgr : System.Web.UI.Page
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
        }//---- end of page load ---------------

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Item temp = new Item();
            temp.ProductID = txtProductID.Text;
            temp.ProductName = txtProductName.Text;
            temp.Company = txtCompany.Text;
            temp.Category = txtCategory.Text;
            temp.DateReleased = calDateReleased.SelectedDate;

            Double dblPrice = 0;
            if (Double.TryParse(txtPrice.Text, out dblPrice))
            {
                temp.Price = dblPrice;
            }

            if(temp.Feedback.Contains("ERROR: "))
            {
                lblFeedback.Text = temp.Feedback;
            }
            else
            {
                lblFeedback.Text = temp.ProductName + " by " + temp.Company;
            }
      
         

        }//----- end of btnAdd_Click-----------
    }
}