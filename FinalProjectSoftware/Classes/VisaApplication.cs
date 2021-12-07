using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    class VisaApplication : IVisaApplication
    {
        private VisaApplicant applicant;
        private String time;
        private Boolean isAvailable;
        private int applicationNumber;
        private Funds funds;

        public string Time { get => time; set => time = value; }
        public bool IsAvailable { get => isAvailable; set => isAvailable = value; }
        public VisaApplicant Applicant { get => applicant; set => applicant = value; }
        public int ApplicationNumber { get => applicationNumber; set => applicationNumber = value; }
        public Funds Funds { get => funds; set => funds = value; }

        public override string ToString()
        {
            if (!isAvailable)
            {
                String applicationString = $"Application Number {applicationNumber}\n";
                applicationString += $"\t\t Time:  {time}, {applicant}, Visa Operations: {applicant.Visa.getInfoVisa()} \n";
                return applicationString;
            }

            return $"Hour:  {time}";

            
            
        }

        public int CompareTo(IVisaApplication other)
        {
            return applicant.CompareTo(other.Applicant);
        }
    }
}
