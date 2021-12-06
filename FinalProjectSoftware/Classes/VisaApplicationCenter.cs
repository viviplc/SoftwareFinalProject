using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectSoftware.Classes
{
    class VisaApplicationCenter: INotifyPropertyChanged
    {
        private VisaApplicationList visaApplicationAppointments;
        private VisaApplicationList availableVisaApplicationAppointments;
        private VisaApplicationList takenVisaApplicationAppointments;

        public event PropertyChangedEventHandler PropertyChanged;

        public VisaApplicationCenter()
        {
        }

        public VisaApplicationCenter(VisaApplicationList appointments, VisaApplicationList availableAppointments)
        {
            this.visaApplicationAppointments = appointments;
            this.availableVisaApplicationAppointments = availableAppointments;
        }

        public VisaApplicationList VisaApplicationAppointments { get => visaApplicationAppointments; set => visaApplicationAppointments = value; }
        public VisaApplicationList AvailableVisaApplicationAppointments
        {
            get { return availableVisaApplicationAppointments; }
            set
            {
                availableVisaApplicationAppointments = value;
                NotifyPropertyChanged();
            }
        }

        public VisaApplicationList TakenVisaApplicationAppointments
        {
            get => takenVisaApplicationAppointments; set
            {
                takenVisaApplicationAppointments = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
