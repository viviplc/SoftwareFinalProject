using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FinalProjectSoftware.Classes
{
    public enum VisaTypes
    {
        TouristVisa = 1, WorkVisa = 2, StudentVisa = 3
    }
    public class VisaApplicant : IVisaApplicant
    {
        private String name;
        private uint age;
        private String passportNumber;
        private String birthday;
        private uint phone;
        private String country;
        private Visa visa;
        private short chosenVisaType;

        public string Name { get => name; set => name = value; }
        public uint Age { get => age; set => age = value; }
        public string PassportNumber { get => passportNumber; set => passportNumber = value; }
        public string Birthday { get => birthday; set => birthday = value; }
        public string Country { get => country; set => country = value; }
        public Visa Visa { get => visa; set => visa = value; }

        [XmlIgnore]
        public short ChosenVisaType { get => chosenVisaType; set => chosenVisaType = value; }
        public uint Phone { get => phone; set => phone = value; }

        public override string ToString()
        {
            return $"Name:  {name}, Age: {age}, Passport Number: {passportNumber}, Phone: {phone}, Birthday: {Birthday}, Country: {Country}";
        }

        public int CompareTo(IVisaApplicant other)
        {
            return visa.CompareTo(other.Visa);
        }

    }
}
