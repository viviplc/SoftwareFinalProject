using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    public enum Visas
    {
        WorkVisa = 1, StudentVisa = 2, TourismVisa = 3
    }
    class VisaApplication : IVisaApplication
    {
        private VisaApplicant applicant;
        private String time;
        private Boolean isAvailable;
        private String uci;
        private Funds funds;

        public string Time { get => time; set => time = value; }
        public bool IsAvailable { get => isAvailable; set => isAvailable = value; }
        public VisaApplicant Applicant { get => applicant; set => applicant = value; }
        public String UCI { get => uci; set => uci = value; }
        public Funds Funds { get => funds; set => funds = value; }

        public override string ToString()
        {
            if (!isAvailable)
            {
                String applicationString = $"Application Number {uci}\n";
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
