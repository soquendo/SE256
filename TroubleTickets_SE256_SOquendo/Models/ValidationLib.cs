using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //necessary for ValidationAttribute
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TroubleTickets_SE256_SOquendo.Models
{
    public class MyDateAttribute : ValidationAttribute
    {
        //IsValid will be used to check when date is added to see if its past/present
        //dates should not be future

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime _dateJoin = Convert.ToDateTime(value); //take in object and convert to DateTime
            if (_dateJoin <= DateTime.Now) //if Date is past, return success
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }//----------- end of protected override ValidationResult -----------------

    }//--------- end of MyDateAttribute : ValidationAttribute -------------

    public class StringOptionsValidate : Attribute, IModelValidator
    {
        public string[] Allowed { get; set; } //array of acceptable strings
        public string ErrorMessage { get; set; }

        public IEnumerable<ModelValidationResult> Validate (ModelValidationContext context)
        {
            if (Allowed.Contains(context.Model as string)) //if list contains string from context, good
            {
                return Enumerable.Empty<ModelValidationResult>();
            }
            else
            {
                return new List<ModelValidationResult> { new ModelValidationResult("", ErrorMessage) };
            }
        }

    }

}//------------ end of .Models ------------
