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
using System.Xml.Serialization;
using System.IO;

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
            InitializeComponent();
            visaApplicationCenter.VisaApplicationAppointments = createVisaAppointments();
            refreshAvailableVisaAppointmentSlots();


            InitializeComponent();
            DataContext = visaApplicationCenter;

            Validation.AddErrorHandler(this.TxtApplicantName,
                TxtApplicantName_ValidationError);
            Validation.AddErrorHandler(this.TxtApplicantPassport,
                TxtApplicantPassport_ValidationError);

            

        }

        protected void TxtApplicantPassport_ValidationError(object sender,
            ValidationErrorEventArgs e)
        {
            MessageBox.Show((string)e.Error.ErrorContent);
        }
        protected void TxtApplicantName_ValidationError(object sender,
            ValidationErrorEventArgs e)
        {
            MessageBox.Show((string)e.Error.ErrorContent);
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

        private void WriteXMLFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(VisaApplicationList));
            TextWriter writter = new StreamWriter("appointments.xml");
            try
            {
                serializer.Serialize(writter, visaApplicationCenter.TakenVisaApplicationAppointments);
                MessageBox.Show("File saved successfully");
            }
            catch (Exception e)
            {
                MessageBox.Show("File can not be saved" + e);
            }
            finally
            {
                writter.Close();
            }
        }
        private void ReadXMLFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(VisaApplicationList));
            TextReader reader = new StreamReader("appointments.xml");
            try
            {
                visaApplicationCenter.TakenVisaApplicationAppointments = (VisaApplicationList)serializer.Deserialize(reader);
                refreshAppointmentSlotsFromTakenSlots();
            }
            catch (Exception e)
            {
                MessageBox.Show("File can not be reach:" + e);
            }
            finally
            {
                reader.Close();
            }
        }

        private void refreshAppointmentSlotsFromTakenSlots()
        {
            VisaApplicationList allAppointments = createVisaAppointments();
            VisaApplicationList availableAppointments = new();
            int curIndex = 0;
            foreach (VisaApplication appointment in allAppointments)
            {
                var indexInTakenAppointments = visaApplicationCenter.TakenVisaApplicationAppointments.getApplicationIndexFromTime(appointment.Time);
                if (indexInTakenAppointments >= 0)
                {
                    allAppointments[curIndex] = visaApplicationCenter.TakenVisaApplicationAppointments[indexInTakenAppointments];
                } else
                {
                    availableAppointments.Add(appointment);
                }
                curIndex += 1;
            }
            visaApplicationCenter.VisaApplicationAppointments = allAppointments;
            visaApplicationCenter.AvailableVisaApplicationAppointments = availableAppointments;
        }
    }

    
}
