using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    public delegate void VisaServicesDelegate();
    interface IVisa : IComparable<IVisaApplication>
    {
        public DateTime ApplicationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string UCI { get; set; }
        public string ServicesProvided { get; set; }
        public string VisaType { get; set; }
        VisaServicesDelegate ServicesDelegate { get; set; }
        public void CallServicesProvided();
    }
}
