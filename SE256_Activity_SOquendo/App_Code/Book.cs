using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using midterm_oquendo;

namespace SE256_Activity_SOquendo.App_Code
{
    public class Book
    {
        private string title;
        private string authorFirst;
        private string authorLast;
        private string email;
        private DateTime datePublished;
        private int pages;
        private double price;

        protected string feedback;

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                if (ValidationLibrary.badWords(value) == true)
                {
                    title = value;
                }
                else
                {
                    feedback += "\nERROR: Title has a bad word in it";
                }
            }
        }

        public string AuthorFirst
        {
            get
            {
                return authorFirst;
            }

            set
            {
                if (!ValidationLibrary.badWords(value))
                {
                    authorFirst = value;
                }
                else
                {
                    feedback += "\nERROR: Author's name has a bad word in it";
                }
            }
        }

        public string AuthorLast
        {
            get
            {
                return authorLast;
            }

            set
            {
                authorLast = value;
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

        public DateTime DatePublished
        {
            get
            {
                return datePublished;
            }

            set
            {
                if (ValidationLibrary.IsAFutureDate(value) == false)
                {
                    datePublished = value;
                }
                else
                {
                    feedback += "\nERROR: You cannot enter future dates";
                }
            }
        }

        public int Pages
        {
            get
            {
                return pages;
            }

            set
            {
                if (ValidationLibrary.IsMinimumAmount(value,0) == true)
                {
                    pages = value;
                }
                else
                {
                    feedback += "\nERROR: Sorry you entered an invalid number of pages";
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

        public Book()
        {
            title = "";
            authorFirst = "";
            authorLast = "";
            pages = 0;
            datePublished = DateTime.Parse("1/1/1500");
            price = 0.0;
            feedback = "";
        }

    }
}