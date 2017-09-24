using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HtmlBlogMSB.Models.Data.CustomValidations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AgeValidation : ValidationAttribute
    {
        public int LimitAge { get; set; }
        public void AgeValidationAttribute(int limitAge)
        {
            LimitAge = limitAge;
        }
        protected override ValidationResult IsValid(object Age, ValidationContext validationContext)
        {
            int age = (int)Age;
            if (age >= LimitAge)
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessageString);

        }
    }
}