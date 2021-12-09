using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FinalProjectSoftware.Rules
{
    class ApplicantNameRule : ValidationRule
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
            String applicantName = "";
            if (value == null)
            {
                result = new ValidationResult(false,
                       "Invalid Applicant Name");
            }
            else
            {
                applicantName = value.ToString();
                if (applicantName.Length <= min || applicantName.Length >= max)
                {
                    result = new ValidationResult(false,
                       "Invalid Applicant Name");
                }
                else
                {
                    result = ValidationResult.ValidResult;
                }
            }
            return result;
        }
    }
}
