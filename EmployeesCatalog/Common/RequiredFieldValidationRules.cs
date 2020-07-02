using System;
using System.Globalization;
using System.Windows.Controls;

namespace EmployeesCatalog.Common
{
    public class RequiredFieldValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string errorMessage = string.Empty;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
                errorMessage = string.Format("You cannot leave this field empty.");

            if (!string.IsNullOrEmpty(errorMessage))
                return new ValidationResult(false, errorMessage);
            return ValidationResult.ValidResult;
        }
    }

}
