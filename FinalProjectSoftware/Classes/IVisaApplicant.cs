using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    public interface IVisaApplicant : IComparable<IVisaApplicant>
    {
        public string Name { get; set; }
        public uint Age { get; set; }
        public string PassportNumber { get; set; }
        public string Birthday { get; set; }
        public string Country { get; set; }
        public Visa Visa { get; set; }
    }
}
