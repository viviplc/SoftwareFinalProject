using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FinalProjectSoftware.Rules
{
    class ApplicantPhoneRule : ValidationRule
    {
        private int size;
        public int Size
        {
            get => size;
            set => size = value;
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = null;
            String phoneString = value.ToString();
            uint phone = 0;
            if (uint.TryParse(phoneString, out phone))
            {
                if (phoneString.Length != size)
                {
                    result = new ValidationResult(false,
                    $"Invalid phone number, {size} digits expected");
                }
                else
                {
                    result = ValidationResult.ValidResult;
                }
            }
            else
            {
                result = new ValidationResult(false,
                $"{phoneString} is not a number");
            }
            return result;
        }
    }
}
