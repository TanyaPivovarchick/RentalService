using RentalService.Web.ViewModels.Filters;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentalService.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StartDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance is RentalPointCarFilterVM model)
            {
                if (model.StartDate <= DateTime.Now.Date)
                {
                    return new ValidationResult("Start date should be later than today.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
