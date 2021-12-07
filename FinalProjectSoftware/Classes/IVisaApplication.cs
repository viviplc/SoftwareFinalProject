using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    public interface IVisaApplication : IComparable<IVisaApplication>
    {
        public VisaApplicant Applicant { get; set; }
        public String Time { get; set; }
        public Boolean IsAvailable { get; set; }
        public String UCI { get; set; }
        public Funds Funds { get; set; }
        public string ToString();
    }
}
