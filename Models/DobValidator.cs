using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AssignmentFormValidation.Models
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]

    public class DobValidator : ValidationAttribute
    {
        public DobValidator()
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            if (value == null)
            {
                return new ValidationResult("Age must be greater than 18 as of 1/1/20222");
            }

            DateTime date = Convert.ToDateTime("1/1/2022");
            DateTime dateTime = Convert.ToDateTime(value);
            var time= (date - dateTime).TotalDays;
            int years = ((int)time) / 365;
            if (years >= 18)
            {
                return ValidationResult.Success;    
            }

            return new ValidationResult("Age must be greater than 18 as of 1/1/20222");
        }
    }
}