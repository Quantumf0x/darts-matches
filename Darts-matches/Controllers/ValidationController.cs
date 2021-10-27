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

        public static string GetErrorMessage(object value)
        {
            string errorMessage = string.Empty;
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                errorMessage = "You cannot leave the field empty";
            }
            return errorMessage;
        }

        public ValidationResult StringInputValidate(object value)
        {
            string error = GetErrorMessage(value);
            if (string.IsNullOrEmpty(error))
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, error);
        }

        public ValidationResult MatchDateValidate(DateTime? value)
        {
            string error = string.Empty;
            var datevalue = value.ToString();
            if (datevalue == null || datevalue == string.Empty)
            {
                error = "You cannot leave the datefield empty";
            }
            if (string.IsNullOrEmpty(error) || error == null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, error);
        }

        public ValidationResult SetsAndLegValidate(string value)
        {
            string error = string.Empty;
            if (value == "0" || value.Contains("-"))
            {
                error = "Number of sets must be 1 or higher";
            }
            if (string.IsNullOrEmpty(error) || error == null)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, error);
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
