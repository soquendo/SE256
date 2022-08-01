using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SO_WebCalc_Demo
{
    public partial class Default : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            txtLCD.Text += "1";
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            txtLCD.Text += "2";
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            txtLCD.Text += "3";
        }

        protected void btnNums_Click(object sender, EventArgs e)
        {
            Button temp = (Button)sender;   //get the button that was clicked
            txtLCD.Text += temp.Text;       //get the text # from that button text prop
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtLCD.Text = " ";
        }



        protected void btnPlus_Click(object sender, EventArgs e)
        {
            //store the current value as Num1
            Session["Num1"] = txtLCD.Text;

            //clears the LCD for another value/input
            txtLCD.Text = "";

            //store the plus operation for future knowledge and use
            Session["Operand"] = "+";

        }

        protected void btnEquals_Click(object sender, EventArgs e)
        {
            //store the current value in Num2
            Double Num2 = Double.Parse(txtLCD.Text);

            //GetHashCode and convert session for Num1
            Double Num1 = Double.Parse(Session["Num1"].ToString());

            Double Results = 0;

            //Perform the appropriate math
            
            if (Session["Operand"].ToString() == "*")
            {
                //perform multiplication
                Results = Num1 * Num2;
            }
            else if (Session["Operand"].ToString() == "/")
            {
                //perform division
                Results = Num1 / Num2;
            }
            else if (Session["Operand"].ToString() == "+")
            {
                //perform addition
                Results = Num1 + Num2;
            }
            else if (Session["Operand"].ToString() == "-")
            {
                //perform subtraction
                Results = Num1 - Num2;
            }


            //display results in the LCD
            txtLCD.Text = Results.ToString();
        }

        protected void btnDiv_Click(object sender, EventArgs e)
        {
            //store the current value as Num1
            Session["Num1"] = txtLCD.Text;

            //clears the LCD for another value/input
            txtLCD.Text = "";

            //store the div operation for future knowledge and use
            Session["Operand"] = "/";

        }
    }
}