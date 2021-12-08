using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Serialization;

namespace FinalProjectSoftware.Classes
{
    [XmlRoot("VisaApplicationList")]
    [XmlInclude(typeof(StudentVisa))]
    [XmlInclude(typeof(WorkVisa))]
    [XmlInclude(typeof(TouristVisa))]
    public class VisaApplicationList : ObservableCollection<VisaApplication>
    {

    }
}
