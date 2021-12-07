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

        public int CompareTo(IVisaApplication other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            String applicationString = $"Application Number {applicationNumber}\n";
            applicationString += $"\t\t Time:  {time}, {applicant}, Visa Operations: {applicant.Visa.getInfoVisa()} \n";
            return applicationString;
        }

        /*
         * needs to be implemented after IApplicant is done
         * here I am comparing only main applicants as opposed to comparing all applicants in this application with all applicants in the other application
        public int CompareTo(IApplication other)
        {
            return getMainApplicant().CompareTo(other.getMainApplicant());
        }
        */
    }
}
