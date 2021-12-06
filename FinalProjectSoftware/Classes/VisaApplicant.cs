using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    public enum VisaTypes
    {
        TouristVisa = 1, WorkVisa = 2, StudentVisa = 3
    }
    class VisaApplicant
    {
        private String name;
        private uint age;
        private String passportNumber;
        private String birthday;
        private String country;
        private Visa visa;
        private short chosenVisaType;
        // Romeno - Do we need credit card info as well?

        public string Name { get => name; set => name = value; }
        public uint Age { get => age; set => age = value; }
        public string PassportNumber { get => passportNumber; set => passportNumber = value; }
        public string Birthday { get => birthday; set => birthday = value; }
        public string Country { get => country; set => country = value; }
        public Visa Visa { get => visa; set => visa = value; }
        public short ChosenVisaType { get => chosenVisaType; set => chosenVisaType = value; }

        public override string ToString()
        {
            return $"Name:  {name}, Age: {age}, Passport Number: {passportNumber}, Birthday: {Birthday}, Country: {Country}";
        }

        /*
        Will uncomment after IApplicant implementation is complete 
        public int CompareTo(IApplicant other)
        {
            return visa.CompareTo(other.Visa);
        }

        */
    }
}
