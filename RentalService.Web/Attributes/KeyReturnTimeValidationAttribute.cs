using RentalService.Web.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentalService.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class KeyReturnTimeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance is DetailedReservationVM model)
            {
                if (model.StartDate == model.EndDate && model.KeyReturnTime <= model.KeyReceiptTime)
                {
                    return new ValidationResult("Return time should be later than receipt time.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
