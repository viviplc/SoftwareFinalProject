using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSoftware.Classes
{
    class VisaApplicationList : IEnumerable<VisaApplication>
    {
        private List<VisaApplication> applicationList = null;

        public VisaApplicationList()
        {
            applicationList = new List<VisaApplication>();
        }

        //indexer
        public VisaApplication this[int index]
        {
            get => applicationList[index];
            set => applicationList[index] = value;
        }

        //Add method 
        public void Add(VisaApplication newApplication)
        {
            applicationList.Add(newApplication);
        }

        //Count method
        public int Count
        {
            get => applicationList.Count;
        }

        //RemoveAt method
        public void RemoveAt(int index)
        {
            applicationList.RemoveAt(index);
        }

        //Remove method
        public void Remove(VisaApplication application)
        {
            applicationList.Remove(application);
        }

        public void Sort()
        {
            applicationList.Sort();
        }

        public IEnumerator<VisaApplication> GetEnumerator()
        {
            return ((IEnumerable<VisaApplication>)applicationList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<VisaApplication>)applicationList).GetEnumerator();
        }

        public int getApplicationIndexFromTime(String time)
        {
            for (int i = 0; i < applicationList.Count; i++)
            {
                if (applicationList[i].Time == time)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
