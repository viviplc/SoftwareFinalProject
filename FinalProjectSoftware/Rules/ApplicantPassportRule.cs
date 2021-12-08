using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FinalProjectSoftware.Rules
{
    class ApplicantPassportRule : ValidationRule
    {
        private int min;
        private int max;
        public int Min
        {
            get => min;
            set => min = value;
        }
        public int Max
        {
            get => max;
            set => max = value;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = null;
            if (value == null)
            {
                result = new ValidationResult(false,
                       "Invalid Applicant Passport");
            }
            else {
                String passportNumber = value.ToString();
                if (passportNumber.Length >= min && passportNumber.Length <= max)
                {
                    result = ValidationResult.ValidResult;
                }
                else
                {
                    result = new ValidationResult(false,
                    $"Invalid Passport Number. Must be between {min} and {max}.");
                }
            }
            
            return result;
        }
    }
}
