using RentalService.Web.ViewModels.Filters;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentalService.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EndDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance is RentalPointCarFilterVM model)
            {
                if (model.EndDate < model.StartDate)
                {
                    return new ValidationResult("End date shouldn't be earlier than start date.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
