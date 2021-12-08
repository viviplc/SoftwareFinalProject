using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FinalProjectSoftware.Rules
{
    class ApplicantFundsRule : ValidationRule
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
                       "Invalid Applicant Funds");
            }
            else
            {
                String fundsString = value.ToString();
                double funds = 0;
                if (fundsString.Length !=0 && double.TryParse(fundsString, out funds))
                {
                    if (funds > min && funds < max)
                    {
                        result = ValidationResult.ValidResult;
                    }
                    else
                    {
                        result = new ValidationResult(false,
                    $"Invalid funds, must be between {min} and {max}");
                    }

                }
                else
                {
                    result = new ValidationResult(false,
                    $"Invalid funds, {fundsString} is not a number");
                }
            }
            return result;
        }
    }
}
