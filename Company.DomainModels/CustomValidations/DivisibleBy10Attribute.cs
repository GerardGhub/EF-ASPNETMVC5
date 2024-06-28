using System;
using System.ComponentModel.DataAnnotations;

namespace Company.DomainModels.CustomValidations
{
    /// <summary>
    ///  Custom validation attribute to check if a value is divisible by 10.
    /// </summary>
    public class DivisibleBy10Attribute : ValidationAttribute
    {
        /// <summary>
        /// Overrides the IsValid method to include custom validation logic.
        /// </summary>
         /// <param name="value">The value to be validated.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>ValidationResult indicating whether validation succeeded or failed.</returns>

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Convert the value to a double
            double price = Convert.ToDouble(value);

            // Check if the value is divisible by 10
            if (price % 10 == 0)
            {
                // If divisible by 10, validation is successful
                return ValidationResult.Success;
            }
            else
            {
                // If not divisible by 10, return a validation error with the specified error message
                return new ValidationResult(this.ErrorMessage);
            }
        }
    }
}



