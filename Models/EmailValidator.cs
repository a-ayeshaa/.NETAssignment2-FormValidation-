using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AssignmentFormValidation.Models
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class EmailValidator : ValidationAttribute
    {
        public string OtherProperty
        {
            get;
            private set;
        }
        public EmailValidator(string otherProperty)
        {
            OtherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo property = validationContext.ObjectType.GetProperty(OtherProperty);
            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = property.GetValue(validationContext.ObjectInstance);

            if (comparisonValue == null || value == null)
            {
                return new ValidationResult("Please enter your email in format id@student.aiub.edu");
            }

            if (value.ToString()==comparisonValue.ToString()+"@student.aiub.edu")
                return ValidationResult.Success;

            return new ValidationResult("Please enter your email in format id@student.aiub.edu");
        }
    }
}