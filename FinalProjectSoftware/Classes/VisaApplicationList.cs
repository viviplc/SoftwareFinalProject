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
    class VisaApplicationList : IEnumerable<VisaApplication>
    {
        private ObservableCollection<VisaApplication> applicationList = null;

        [XmlArray("VisaApplications")]
        [XmlArrayItem("VisaApplication", typeof(Visa))]
        public ObservableCollection<VisaApplication> ApplicationList { get => applicationList; set => applicationList = value; }

        public VisaApplicationList()
        {
            ApplicationList = new ObservableCollection<VisaApplication>();
        }

        //indexer
        public VisaApplication this[int index]
        {
            get => ApplicationList[index];
            set => ApplicationList[index] = value;
        }

        //Add method 
        public void Add(VisaApplication newApplication)
        {
            ApplicationList.Add(newApplication);
        }

        //Count method
        public int Count
        {
            get => ApplicationList.Count;
        }

        //RemoveAt method
        public void RemoveAt(int index)
        {
            ApplicationList.RemoveAt(index);
        }

        //Remove method
        public void Remove(VisaApplication application)
        {
            ApplicationList.Remove(application);
        }

        public IEnumerator<VisaApplication> GetEnumerator()
        {
            return ((IEnumerable<VisaApplication>)ApplicationList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<VisaApplication>)ApplicationList).GetEnumerator();
        }

        public int getApplicationIndexFromTime(String time)
        {
            for (int i = 0; i < ApplicationList.Count; i++)
            {
                if (ApplicationList[i].Time == time)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
