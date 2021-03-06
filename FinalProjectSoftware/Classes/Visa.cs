using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FinalProjectSoftware.Classes
{
    public abstract class Visa : IVisa
    {
        private DateTime applicationDate;
        private String expirationDate;
        private String servicesProvided;
        private String visaType;

        private VisaServicesDelegate servicesDelegate = null;

        public void setupVisaServicesDelegate()
        {
            servicesDelegate += PayVisaFees;
            servicesDelegate += ConfirmAppointment;
            servicesDelegate += AssignConsul;
        }

        public DateTime ApplicationDate { get => applicationDate; set => applicationDate = value; }
        public String ExpirationDate { get => expirationDate; set => expirationDate = value; }
        [XmlIgnore]
        public string ServicesProvided { get => servicesProvided; set => servicesProvided = value; }
        
        public string VisaType { get => visaType; set => visaType = value; }
        [XmlIgnore]
        public VisaServicesDelegate ServicesDelegate { get => servicesDelegate; set => servicesDelegate=value; }

        public String getInfoVisa()
        {
            return $"Visa Type: {visaType}";
        }

        public void PayVisaFees()
        {
            servicesProvided += "... Visa Fees Payment Provided ... \n";
        }

        public void ConfirmAppointment()
        {
            servicesProvided += "... Visa Appointment Confirmed ... \n";
        }

        public void AssignConsul()
        {
            servicesProvided += "... Visa Consul Assigned ... \n";
        }

        public abstract void CallServicesProvided();

        public int CompareTo(IVisa other)
        {
            return visaType.CompareTo(other.VisaType); 
        }

        public abstract int getUCIId();
    }
}
