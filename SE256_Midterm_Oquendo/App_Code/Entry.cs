using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using midterm_oquendo;

namespace SE256_Midterm_Oquendo.App_Code
{
    public class Entry
    {
        private string title;
        private string genre;
        private string rating;
        private string runtime;
        private DateTime year;
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
                if (!ValidationLibrary.badWords(value))
                {
                    title = value;
                }
                else
                {
                    feedback += "\nERROR: Title has a bad word in it";
                }
            }
        }

        public string Genre
                {
                    get
                    {
                        return genre;
                    }

                    set
                    {
                        if (ValidationLibrary.movieGenre(value))
                        {
                            title = value;
                        }
                        else
                        {
                            feedback += "\nERROR: Please select from: Action, Adventure, Crime, Comedy, Drama, Horror, Science Fiction, Suspense";
                        }
                    }
                }

        public string Rating
        {
            get
            {
                return rating;
            }

            set
            {
                if (ValidationLibrary.movieRating(value))
                {
                    rating = value;
                }
                else
                {
                    feedback += "\nERROR: Please select G, PG, PG-13, or R";
                }
            }
        }

        public string Runtime
        {
            get
            {
                return runtime;
            }

            set
            {
                if (ValidationLibrary.IsItNum(value))
                {
                    runtime = value;
                }
                else
                {
                    feedback += "\nERROR: Please enter total runtime in minutes; ex. 104, 90, 189";
                }
                
            }
        }

        public DateTime Year
        {
            get
            {
                return year;
            }

            set
            {
                if (ValidationLibrary.IsAFutureDate(value) == false)
                {
                    year = value;
                }
                else
                {
                    feedback += "\nERROR: You cannot enter future dates";
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

        public Entry()
        {
            title = "";
            genre = "";
            rating = "";
            runtime = "";
            year = DateTime.Parse("1/1/1500");
            price = 0.0;
            feedback = "";
        }

    }
}