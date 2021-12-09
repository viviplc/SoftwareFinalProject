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
using System.Data;
using System.Collections.ObjectModel;

namespace FinalProjectSoftware
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        VisaApplicationCenter visaApplicationCenter = new();
        bool editMode = false;
        VisaApplication visaApplicationBeingEdited = new();
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
            Validation.AddErrorHandler(this.TxtApplicantPhone,
                TxtApplicantPhone_ValidationError);
            Validation.AddErrorHandler(this.TxtApplicantFunds,
                TxtApplicantFunds_ValidationError);

            refreshEditUpdateColumnVisibility();

        }

        protected void TxtApplicantFunds_ValidationError(object sender,
            ValidationErrorEventArgs e)
        {
            MessageBox.Show((string)e.Error.ErrorContent);
        }
        protected void TxtApplicantPhone_ValidationError(object sender,
            ValidationErrorEventArgs e)
        {
            MessageBox.Show((string)e.Error.ErrorContent);
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
            //uncomment below line when appointmentsGrid is ready
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
                refreshAvailableVisaAppointmentSlots();
                refreshTakenVisaAppointmentSlots();
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
            //VisaApplicationList allAppointments = createVisaAppointments();
            //VisaApplicationList availableAppointments = new();
            int curIndex = 0;
            foreach (VisaApplication appointment in visaApplicationCenter.TakenVisaApplicationAppointments)
            {
                //var indexInAllAppointments = visaApplicationCenter.VisaApplicationAppointments.getApplicationIndexFromTime(appointment.Time);
                var indexInAllAppointments = getApplicationIndexFromTime(visaApplicationCenter.VisaApplicationAppointments,appointment.Time);
                visaApplicationCenter.VisaApplicationAppointments[indexInAllAppointments] = appointment;
                curIndex += 1;
            }
           // visaApplicationCenter.VisaApplicationAppointments = allAppointments;
            //visaApplicationCenter.AvailableVisaApplicationAppointments = availableAppointments;
        }

        private void btn_Search_Clicked(object sender, RoutedEventArgs e)
        {
            String searchQuery = TxtSearchQuery.Text;
            if (searchQuery.Length > 0)
            {
                if(visaApplicationCenter.TakenVisaApplicationAppointments != null)
                {
                    var query = from appt in visaApplicationCenter.TakenVisaApplicationAppointments
                                where appt.Applicant.Name.ToLower().StartsWith(searchQuery.ToLower())
                                select appt;
                    ApplicationsGrid.ItemsSource = query;
                    TxtSearchQuery.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Empty search query");
                ApplicationsGrid.ItemsSource = visaApplicationCenter.TakenVisaApplicationAppointments;
            }
            
            refreshEditUpdateColumnVisibility();
        }

        private void btnDisplayClicked(object sender, RoutedEventArgs e)
        {
            ReadXMLFile();
            refreshGridSource();
            refreshEditUpdateColumnVisibility();
        }

        private void btnSaveDataClicked(object sender, RoutedEventArgs e)
        {
            WriteXMLFile();
        }

        private void btn_ApplyForVisa(object sender, RoutedEventArgs e)
        {
            updateApplicantName();
            updateApplicantPassport();
            updateApplicantPhone();
            updateApplicantFunds();
            //resetting the initial state
            BorderVisaTypeSelector.BorderBrush = Brushes.Transparent;
            BorderSlotSelector.BorderBrush = Brushes.Transparent;
            BorderBirthdayPck.BorderBrush = Brushes.Transparent;
            BorderCountrySelector.BorderBrush = Brushes.Transparent;
            LblErrorMessages.Text = "";
            ErrorScroll.Visibility = Visibility.Hidden;

            int slotSelectedIndex = CBSlotSelector.SelectedIndex;
            String slotSelected = CBSlotSelector.Text;
            String name = TxtApplicantName.Text;
            String birthday = PckBirthday.Text;
            String passport = TxtApplicantPassport.Text;
            String phoneString = TxtApplicantPhone.Text;
            String fundsString = TxtApplicantFunds.Text;
            bool fundsSponsor = (bool)CheckSponsor.IsChecked;
            int countryIndex = CBCountrySelector.SelectedIndex;
            String country = CBCountrySelector.Text;

            uint phone = 0;
            double funds = 0.0;

            if (validateInput(slotSelectedIndex, name, birthday, passport, phoneString, fundsString, countryIndex))
            {
                refreshGridSource();
                //logic for validation successfull
                if (uint.TryParse(phoneString, out phone) && double.TryParse(fundsString, out funds))
                {
                    //defining the visa type
                    Visas selectedVisa = new Visas();
                    if (RBWorkVisa.IsChecked == true)
                    {
                        selectedVisa = Visas.WorkVisa;
                    }
                    else if (RBStudentVisa.IsChecked == true)
                    {
                        selectedVisa = Visas.StudentVisa;
                    }
                    else if (RBTourismVisa.IsChecked == true)
                    {
                        selectedVisa = Visas.TourismVisa;
                    }

                    //int visaApplicationIndex = visaApplicationCenter.VisaApplicationAppointments.getApplicationIndexFromTime(slotSelected);
                    int visaApplicationIndex = getApplicationIndexFromTime(visaApplicationCenter.VisaApplicationAppointments, slotSelected);
                    VisaApplication application = visaApplicationCenter.VisaApplicationAppointments[visaApplicationIndex];
                    VisaApplicant applicant = new();
                    applicant.Name = name;
                    applicant.Age = calculateApplicantAge(birthday);
                    applicant.PassportNumber = passport;
                    applicant.Birthday = birthday;
                    applicant.Phone = phone;
                    applicant.Country = country;

                    Visa visa = null;
                    int expirationRange = 0;
                    String uci = "";

                    switch (selectedVisa)
                    {
                        case Visas.WorkVisa:
                            visa = new WorkVisa();
                            visa.VisaType = "Work Visa";
                            expirationRange = 5;
                            if (visaApplicationBeingEdited.Applicant != null&&visaApplicationBeingEdited.Applicant.Visa.VisaType == visa.VisaType)
                            {
                                uci = visaApplicationBeingEdited.UCI;
                            } else
                            {
                                uci = $"WK-{visa.getUCIId()}";
                            }
                            break;
                        case Visas.StudentVisa:
                            visa = new StudentVisa();
                            visa.VisaType = "Student Visa";
                            expirationRange = 2;
                            if (visaApplicationBeingEdited.Applicant!=null&&visaApplicationBeingEdited.Applicant.Visa.VisaType == visa.VisaType)
                            {
                                uci = visaApplicationBeingEdited.UCI;
                            }
                            else
                            {
                                uci = $"ST-{visa.getUCIId()}";
                            }
                            break;
                        case Visas.TourismVisa:
                            visa = new TouristVisa();
                            visa.VisaType = "Tourist Visa";
                            expirationRange = 10;
                            if (visaApplicationBeingEdited.Applicant != null&&visaApplicationBeingEdited.Applicant.Visa.VisaType == visa.VisaType)
                            {
                                uci = visaApplicationBeingEdited.UCI;
                            }
                            else
                            {
                                uci = $"TO-{visa.getUCIId()}";
                            }
                            break;
                        default:
                            break;
                    }

                    DateTime today = DateTime.Now;
                    visa.ApplicationDate = today;
                    visa.ExpirationDate = today.AddYears(expirationRange).ToShortDateString();
                    applicant.Visa = visa;
                    application.Applicant = applicant;
                    application.UCI = uci;
                    application.IsAvailable = false;
                    Funds newFunds = new();
                    newFunds.Amount = funds;
                    newFunds.FromSponsor = fundsSponsor;
                    application.Funds = newFunds;
                    application.Applicant.Visa.ServicesDelegate();

                    if (editMode)
                    {
                        string editedApplicationTime = visaApplicationBeingEdited.Time;
                        string currentApplicationTime = application.Time;
                        if(editedApplicationTime != currentApplicationTime)
                        {
                            int indexOfEditedApplication = getApplicationIndexFromTime(visaApplicationCenter.VisaApplicationAppointments, editedApplicationTime);
                            visaApplicationCenter.VisaApplicationAppointments[indexOfEditedApplication].IsAvailable = true;
                        }
                        editMode = false;
                        endEditMode();
                    }

                    refreshAvailableVisaAppointmentSlots();
                    refreshTakenVisaAppointmentSlots();

                    resetUserInput();
                    refreshGridSource();
                    refreshEditUpdateColumnVisibility();
                }
            }
            

        }

        private void resetUserInput()
        {
            BorderVisaTypeSelector.BorderBrush = Brushes.Transparent;
            BorderSlotSelector.BorderBrush = Brushes.Transparent;
            BorderBirthdayPck.BorderBrush = Brushes.Transparent;
            BorderCountrySelector.BorderBrush = Brushes.Transparent;
            CBSlotSelector.SelectedIndex = -1;
            TxtApplicantName.Text="";
            PckBirthday.Text="";
            TxtApplicantPassport.Text = "";
            TxtApplicantPhone.Text = "";
            TxtApplicantFunds.Text = "";
            CBCountrySelector.SelectedIndex = -1;
            LblErrorMessages.Text = "";
            RBStudentVisa.IsChecked = false;
            RBWorkVisa.IsChecked = false;
            RBTourismVisa.IsChecked = false;
            ErrorScroll.Visibility = Visibility.Hidden;
            CheckSponsor.IsChecked = false;
        }

        private uint calculateApplicantAge(string birthday)
        {
            uint age = 0;
            DateTime birthDate = DateTime.Parse(birthday);
            age = (uint)DateTime.Now.Subtract(birthDate).Days;
            age = age/365;   
            return age;
        }

        private bool validateInput(int slotSelectedIndex, string name, string birthday, string passport, string phoneString, string fundsString, int countryIndex)
        {
            bool passValidation = true;
            string validation = "";

            uint phone = 0;
            double funds = 0.0;

            //Time Slot selection validation
            if (slotSelectedIndex < 0)
            {
                passValidation = false;
                BorderSlotSelector.BorderBrush = Brushes.Red;
                validation += "Must select time slot. \n";
            }

            //Applicant Name validation
            if (name.Length <= 0 || name.Length >= 100 || name == "")
            {
                passValidation = false;
                validation += "Invalid name. \n";
            }

            //Birthday Validation
            //LblErrorMessages.Text = birthday;
            DateTime today = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if (birthday.Length > 0)
            {
                DateTime birthdayDate = DateTime.Parse(birthday);
                if (birthdayDate >= today)
                {
                    passValidation = false;
                    validation += "Invalid birth date. \n";
                    BorderBirthdayPck.BorderBrush = Brushes.Red;
                }
            }
            else {
                passValidation = false;
                validation += "Invalid birth date. \n";
                BorderBirthdayPck.BorderBrush = Brushes.Red;
            }
            

            //Passport Validation
            if (passport.Length < 7 || passport.Length > 9)
            {
                passValidation = false;
                validation += "Invalid passport \n";
            }

            //Phone Validation
            if (phoneString.Length != 10 || !uint.TryParse(phoneString, out phone))
            {
                passValidation = false;
                validation += "Invalid phone \n";
            }

            //funds Validation
            if (!double.TryParse(fundsString, out funds))
            {
                passValidation = false;
                validation += "Invalid funds \n";
            }

            //country validation
            if (countryIndex < 0)
            {
                passValidation = false;
                BorderCountrySelector.BorderBrush = Brushes.Red;
                validation += "Must select Country. \n";
            }

            //Visa Type selection
            if (RBWorkVisa.IsChecked == false && RBStudentVisa.IsChecked == false && RBTourismVisa.IsChecked == false)
            {
                passValidation = false;
                validation += "Must select Visa Type. \n";
                BorderVisaTypeSelector.BorderBrush = Brushes.Red;
            }

            LblErrorMessages.Text = validation;
            ErrorScroll.Visibility = Visibility.Visible;

            return passValidation;
        }
        private void btnDeleteRowClicked(object sender, RoutedEventArgs e)
        {
            var currentRowIndex = ApplicationsGrid.Items.IndexOf(ApplicationsGrid.CurrentItem);
            var selectedApplication = (VisaApplication)ApplicationsGrid.SelectedItems[0];
            var curRowTime = selectedApplication.Time;
            //var indexInAllApointments = visaApplicationCenter.VisaApplicationAppointments.getApplicationIndexFromTime(curRowTime);
            var indexInAllApointments = getApplicationIndexFromTime(visaApplicationCenter.VisaApplicationAppointments,curRowTime);
            visaApplicationCenter.VisaApplicationAppointments[indexInAllApointments].IsAvailable = true;
            refreshTakenVisaAppointmentSlots();
            refreshAvailableVisaAppointmentSlots();
            refreshGridSource();
            refreshEditUpdateColumnVisibility();
        }

        private void btnUpdateRowClicked(object sender, RoutedEventArgs e)
        {
            resetUserInput();
            editMode = true;
            startEditMode();
            var currentRowIndex = ApplicationsGrid.Items.IndexOf(ApplicationsGrid.CurrentItem);
            VisaApplication selectedApplication = (VisaApplication)ApplicationsGrid.SelectedItems[0];
            visaApplicationBeingEdited = selectedApplication;
            TxtApplicantName.Text = selectedApplication.Applicant.Name;
            PckBirthday.Text = selectedApplication.Applicant.Birthday;
            TxtApplicantPassport.Text = selectedApplication.Applicant.PassportNumber;
            TxtApplicantPhone.Text = selectedApplication.Applicant.Phone.ToString();
            TxtApplicantFunds.Text = selectedApplication.Funds.Amount.ToString();
            CheckSponsor.IsChecked = selectedApplication.Funds.FromSponsor;
            CBCountrySelector.SelectedItem = selectedApplication.Applicant.Country;

            switch(selectedApplication.Applicant.Visa.VisaType)
            {
                case "Work Visa":
                    RBWorkVisa.IsChecked = true;
                    RBStudentVisa.IsChecked = false;
                    RBTourismVisa.IsChecked = false;
                    break;
                case "Student Visa":
                    RBWorkVisa.IsChecked = false;
                    RBStudentVisa.IsChecked = true;
                    RBTourismVisa.IsChecked = false;
                    break;
                case "Tourism Visa":
                    RBWorkVisa.IsChecked = false;
                    RBStudentVisa.IsChecked = false;
                    RBTourismVisa.IsChecked = true;
                    break;
                default:
                    RBWorkVisa.IsChecked = false;
                    RBStudentVisa.IsChecked = false;
                    RBTourismVisa.IsChecked = true;
                    break;
            }

            VisaApplicationList newAppointmentsList = createEditAppointmentList(selectedApplication);

            CBSlotSelector.ItemsSource = newAppointmentsList;
            CBSlotSelector.SelectedIndex = getApplicationIndexFromTime(newAppointmentsList,selectedApplication.Time);

            updateApplicantName();
            updateApplicantPassport();
            updateApplicantPhone();
            updateApplicantFunds();
        }

        private VisaApplicationList createEditAppointmentList(VisaApplication currentlyEditedApplication)
        {
            VisaApplicationList newAppointmentsList = new();
            foreach(VisaApplication visaApplication in visaApplicationCenter.VisaApplicationAppointments)
            {
                if (visaApplication.IsAvailable || (currentlyEditedApplication.Time == visaApplication.Time))
                {
                    newAppointmentsList.Add(visaApplication);
                }
            }
            return newAppointmentsList;
        }

        private void startEditMode()
        {
            btnApplyForVisa.Content = "Update";
            btnCancelEdit.Visibility = Visibility.Visible;

        }

        private void endEditMode()
        {
            btnApplyForVisa.Content = "Apply for Visa";
            btnCancelEdit.Visibility = Visibility.Hidden;
            resetUserInput();
            CBSlotSelector.ItemsSource = visaApplicationCenter.AvailableVisaApplicationAppointments;
        }

        private void btn_CancelEdit(object sender, RoutedEventArgs e)
        {
            endEditMode();
        }

        private void refreshGridSource()
        {
            ApplicationsGrid.ItemsSource = visaApplicationCenter.TakenVisaApplicationAppointments;
        }

        private void updateApplicantName() 
        {
            BindingExpression be = TxtApplicantName.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
        }

        private void updateApplicantPassport()
        {
            BindingExpression be = TxtApplicantPassport.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
        }

        private void updateApplicantPhone()
        {
            BindingExpression be = TxtApplicantPhone.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
        }

        private void updateApplicantFunds()
        {
            BindingExpression be = TxtApplicantFunds.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
        }

        private void TextChangeApplicantName(object sender, RoutedEventArgs e)
        {
            updateApplicantName();
        }

        private void TextChangeApplicantName(object sender, TextCompositionEventArgs e)
        {
            updateApplicantName();
        }

        private void TextChangeApplicantPassport(object sender, RoutedEventArgs e)
        {
            updateApplicantPassport();
        }

        private void TextChangeApplicantPassport(object sender, TextCompositionEventArgs e)
        {
            updateApplicantPassport();
        }

        private void TextChangeApplicantPhone(object sender, TextCompositionEventArgs e)
        {
            updateApplicantPhone();
        }

        private void TextChangeApplicantPhone(object sender, RoutedEventArgs e)
        {
            updateApplicantPhone();
        }

        private void TextChangeApplicantFunds(object sender, RoutedEventArgs e)
        {
            updateApplicantFunds();
        }

        private void TextChangeApplicantFunds(object sender, TextChangedEventArgs e)
        {
            updateApplicantFunds();
        }

        public int getApplicationIndexFromTime(VisaApplicationList ApplicationList, String time)
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

        private void refreshEditUpdateColumnVisibility()
        {
            var num = ApplicationsGrid.Items.Count;
            if(num == 0)
            {
                ApplicationsGrid.Columns[ApplicationsGrid.Columns.Count - 1].Visibility = Visibility.Hidden;
                ApplicationsGrid.Columns[ApplicationsGrid.Columns.Count - 2].Visibility = Visibility.Hidden;
            } else
            {
                ApplicationsGrid.Columns[ApplicationsGrid.Columns.Count - 1].Visibility = Visibility.Visible;
                ApplicationsGrid.Columns[ApplicationsGrid.Columns.Count - 2].Visibility = Visibility.Visible;
            }
        }

    }

   

}
