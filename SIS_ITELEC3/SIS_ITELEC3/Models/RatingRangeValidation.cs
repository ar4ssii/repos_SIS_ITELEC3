using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SIS_ITELEC3.Models
{
    public class RatingRangeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            double rating;
            if (value != null && double.TryParse(value.ToString(), out rating))
            {
                if (rating >= 1.0 && rating <= 5.0)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Rating must be between 1.0 and 5.0");
                }
            }

            return new ValidationResult("Rating is required and must be a number between 1.0 and 5.0.");
        }
    }
}