using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    abstract class Visa
    {
        private DateTime applicationDate;
        private DateTime expirationDate;
        private String uci;
        private String servicesProvided;
        private String visaType;
        //Delegate Pending
        //private VisaServicesDelegate servicesDelegate = null;

        public Visa()
        {
            //setupVisaServicesDelegate();
        }

        /*
        private void setupVisaServicesDelegate()
        {
            servicesDelegate += PayVisaFees;
            servicesDelegate += ConfirmAppointment;
            servicesDelegate += AssignConsul;
        }
        */

        public DateTime ApplicationDate { get => applicationDate; set => applicationDate = value; }
        public DateTime ExpirationDate { get => expirationDate; set => expirationDate = value; }
        public string UCI { get => uci; set => uci = value; }
        public string ServicesProvided { get => servicesProvided; set => servicesProvided = value; }
        public string VisaType { get => visaType; set => visaType = value; }

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

        //Pending applying interfaces compare
    }
}
