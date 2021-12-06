using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    interface IApplication : IComparable<IApplication>
    {
        public VisaApplicant applicant { get; set; }
        public String time { get; set; }
        public Boolean isAvailable { get; set; }
        public int applicationNumber { get; set; }
        public Funds funds { get; set; }
        public string ToString();
    }
}
