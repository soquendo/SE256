using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using midterm_oquendo;

namespace SE256_ASPLab_SOquendo.App_Code
{
    public class Invt
    {
        private string color;
        private string size;
        private string style;
        private string email;
        private double price;

        protected string feedback;

        public string Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        public string Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public string Style
        {
            get
            {
                return style;
            }

            set
            {
                style = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                if (ValidationLibrary.IsValidEmail(value))
                {
                    email = value;
                }
                else
                {
                    feedback += "\nERROR: Invalid email";
                }
            }
        }    

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                if (ValidationLibrary.IsMinimumAmount(value, 1) == true)
                {
                    price = value;
                }
                else
                {
                    feedback += "\nERROR: Price is not sufficient";
                }
            }
        }

        public string Feedback
        {
            get { return feedback; }
        }

        public Invt()
        {
            color = "";
            size = "";
            style = "";
            price = 0.0;
            feedback = "";
        }

    }
}