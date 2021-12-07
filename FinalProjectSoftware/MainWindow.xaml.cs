using System;
using FinalProjectSoftware.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalProjectSoftware
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        VisaApplicationCenter visaApplicationCenter = new();
        public MainWindow()
        {
            visaApplicationCenter.VisaApplicationAppointments = createVisaAppointments();
            refreshAvailableVisaAppointmentSlots();
            InitializeComponent();
        }


        private VisaApplicationList createVisaAppointments()
        {
            VisaApplicationList visaApplicationAppointments = new();
            DateTime startTime = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0);

            for (int i = 0; i < 16; i++)
            {
                VisaApplication newVisaApplicationAppointment = new();
                newVisaApplicationAppointment.IsAvailable = true;
                newVisaApplicationAppointment.Time = startTime.ToString("HH:mm:ss");
                visaApplicationAppointments.Add(newVisaApplicationAppointment);
                startTime = startTime.AddMinutes(30);
            }
            return visaApplicationAppointments;
        }

        private void refreshAvailableVisaAppointmentSlots()
        {
            VisaApplicationList newAppointmentSlots = new();
            foreach (VisaApplication appointment in visaApplicationCenter.VisaApplicationAppointments)
            {
                if (appointment.IsAvailable)
                {
                    newAppointmentSlots.Add(appointment);
                }
            }
            visaApplicationCenter.AvailableVisaApplicationAppointments = newAppointmentSlots;

        }

        private void refreshTakenVisaAppointmentSlots()
        {
            VisaApplicationList newAppointmentSlots = new();
            foreach (VisaApplication appointment in visaApplicationCenter.VisaApplicationAppointments)
            {
                if (!appointment.IsAvailable)
                {
                    newAppointmentSlots.Add(appointment);
                }
            }
            visaApplicationCenter.TakenVisaApplicationAppointments = newAppointmentSlots;
            //AppointmentsGrid.ItemsSource = studio.TakenAppointments;
        }
    }

    
}
