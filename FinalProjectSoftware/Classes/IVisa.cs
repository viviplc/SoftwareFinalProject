using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    public delegate void VisaServicesDelegate();
    public interface IVisa : IComparable<IVisa>
    {
        public DateTime ApplicationDate { get; set; }
        public String ExpirationDate { get; set; }
        public string ServicesProvided { get; set; }
        public string VisaType { get; set; }
        VisaServicesDelegate ServicesDelegate { get; set; }
        public void CallServicesProvided();
        public int getUCIId();
    }
}
