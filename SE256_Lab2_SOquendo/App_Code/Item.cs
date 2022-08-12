using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using week5_class;

namespace SE256_Lab2_SOquendo.App_Code
{
    public class Item
    {
        private string productID;
        private string productName;
        private string company;
        private string category;
        private DateTime dateReleased;
        private double price;

        protected string feedback;

        public string ProductID
        {
            get
            {
                return productID;
            }

            set
            {
                productID = value;
            }
        }//----- productID class --------

        public string ProductName
        {
            get
            {
                return productName;
            }

            set
            {
                if (!ValidationLibrary.badWords(value))
                {
                    productName = value;
                }
                else
                {
                    feedback += "\nERROR: Product name contains inappropriate words";
                }
            }
        }//------ productName class ----

        public string Company
        {
            get
            {
                return company;
            }

            set
            {
                if (!ValidationLibrary.badWords(value))
                {
                    company = value;
                }
                else
                {
                    feedback += "\nERROR: Company name contains inappropriate words";
                }
            }
        }//----- company class ----

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                if (!ValidationLibrary.badWords(value))
                {
                    category = value;
                }
                else
                {
                    feedback += "\nERROR: Category name contains inappropriate words";
                }
            }
        }//----- category class ---------

        public DateTime DateReleased
        {
            get
            {
                return dateReleased;
            }

            set
            {
                if (ValidationLibrary.IsAFutureDate(value) == false)
                {
                    dateReleased = value;
                }
                else
                {
                    feedback += " \nERROR: You cannot enter future dates";
                }
            }
        }//---------- dateReleased class -----------

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
                    feedback += "\nERROR: Price is not sufficient.";
                }
            }
        }//---- price class ------

        public string Feedback
        {
            get { return feedback; }
        }

        public Item()
        {
            productID = "";
            productName = "";
            company = "";
            category = "";
            dateReleased = DateTime.Parse("1/1/1500");
            price = 0.0;
            feedback = "";
        }



    }//------ item class ----
}