using System;
using System.Globalization;
using System.Windows.Controls;

namespace Darts_matches.Controllers
{
    public class ValidationController : ValidationRule
    {
        private static ValidationController _instance;
        public static ValidationController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ValidationController();
                }
                return _instance;
            }
        }
        public static string GetErrorMessage(object fieldValue)
        {
            string errorMessage = string.Empty;
            if (fieldValue == null || string.IsNullOrEmpty(fieldValue.ToString()))
                errorMessage = "You cannot leave the field empty";
            return errorMessage;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string error = GetErrorMessage(value);
            if (!string.IsNullOrEmpty(error))
                return new ValidationResult(false, error);
            return ValidationResult.ValidResult;
        }
        public ValidationResult PlayerInputValidate(object value, CultureInfo cultureInfo)
        {
            string stringValue = GetErrorMessage(value);
            if (string.IsNullOrEmpty(stringValue))
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, stringValue);
        }
    }
}
