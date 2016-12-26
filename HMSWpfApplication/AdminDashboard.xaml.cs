using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace HMSWpfApplication
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {
        Login reLogin;
        public Ward newWard;
        public Doctor newDoc;

        HMSAppEntities context = new HMSAppEntities();
        CollectionViewSource wardView;
        CollectionViewSource docView;
        CollectionViewSource patView;
        CollectionViewSource apptmentView;
        CollectionViewSource admissionView;
        CollectionViewSource billView;
        CollectionViewSource userView;

        public AdminDashboard()
        {
            InitializeComponent();

            //To Load the Administrator dashboard home view
            welcomePage.Visibility = Visibility.Visible;

            try
            {
                newWard = new Ward();
                wardView = ((CollectionViewSource)
                (FindResource("wardViewSource")));
                DataContext = this;

                docView = ((CollectionViewSource)
                (FindResource("doctorViewSource")));
                DataContext = this;

                patView = ((CollectionViewSource)
                (FindResource("patientViewSource")));
                DataContext = this;

                apptmentView = ((CollectionViewSource)
                (FindResource("patientAppointmentsViewSource")));
                DataContext = this;

                admissionView = ((CollectionViewSource)
                (FindResource("admissionViewSource")));
                DataContext = this;

                billView = ((CollectionViewSource)
                (FindResource("billViewSource")));
                DataContext = this;

                userView = ((CollectionViewSource)
                (FindResource("userViewSource")));
                DataContext = this;
            }
            catch (Exception)
            {
                MessageBox.Show("Error Loading datasource");
            }    

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            context.Wards.Load();
            wardView.Source = context.Wards.Local;

            context.Doctors.Load();
            docView.Source = context.Doctors.Local;

            context.Patients.Load();
            patView.Source = context.Patients.Local;

            context.Appointments.Load();
            apptmentView.Source = context.Appointments.Local;

            context.Admissions.Load();
            admissionView.Source = context.Admissions.Local;

            context.Bills.Load();
            billView.Source = context.Bills.Local;

            context.Users.Load();
            userView.Source = context.Users.Local;

          
        } 

        private void btnWard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //To hide unneeded panels and grids from view
                collapsePanels();

                //To change the Dashboard Heading to Ward Detail
                lblDash.Content = "Ward View";
                //To load and make visible the ward details/ list

                wardDataGrid.Visibility = Visibility.Visible;
                wardDetailGrid.Visibility = Visibility.Visible;
                newWardDetailGrid.Visibility = Visibility.Visible;
                NavButtons.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading the Ward Grid");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // If existing window is visible, then delete the Ward.   

                var cur = wardView.View.CurrentItem as Ward;

                var cust = (from c in context.Wards
                            where c.WardID == cur.WardID
                            select c).FirstOrDefault();

                context.Wards.Remove(cust);

                context.SaveChanges();
                wardView.View.Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Problem deleting the ward");
            }

        }

        private void tlWard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //To hide unneeded panels and grids from view
                collapsePanels();

                //To change the Dashboard Heading to Ward Detail
                lblDash.Content = "Ward View";

                //To load and make visible the ward details/ list
                wardDataGrid.Visibility = Visibility.Visible;
                wardDetailGrid.Visibility = Visibility.Visible;
                newWardDetailGrid.Visibility = Visibility.Visible;
                NavButtons.Visibility = Visibility.Visible;

            }
            catch (Exception)
            {
                MessageBox.Show("Error loading the Ward Grid");
            }
        }

        private void tlPatients_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //To close unneeded panels and grids
                collapsePanels();

                //To change the Dashboard Heading to Ward Detail
                lblDash.Content = "Patient View";

                //To load and make visible the ward details/ list
                patientDetailGrid.Visibility = Visibility.Visible;
                patientDataGrid.Visibility = Visibility.Visible;
                btnSavePatient.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading the patients list");
            }
        }

        private void tlDoctor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //To close unneeded panels and grids
                collapsePanels();

                //To change the Dashboard Heading to Ward Detail
                lblDash.Content = "Doctor Detail";
               
                //To load and make visible the ward details/ list
                doctorDataGrid.Visibility = Visibility.Visible;
                doctorDetailGrid.Visibility = Visibility.Visible;
                NavButtonsDoc.Visibility = Visibility.Visible;
                newDoctorDetailGrid.Visibility = Visibility.Visible;

            }
            catch (Exception)
            {
                MessageBox.Show("Error loading the Doctors detail");
            }
        }

        private void tlApptment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //To hide unneeded panels and grids from view
                collapsePanels();

                //To change the Dashboard Heading to Ward Detail
                lblDash.Content = "Appointment View";
                //To load and make visible the ward details/ list

                appointmentsDataGrid.Visibility = Visibility.Visible;
                appointmentDetailGrid.Visibility = Visibility.Visible;
               
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading the Appointment detail");
            }
        }

        private void tlBills_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //To hide unneeded panels and grids from view
                collapsePanels();

                //To change the Dashboard Heading to Ward Detail
                lblDash.Content = "Bills View";

                //To load and make visible the ward details/ list
                billDataGrid.Visibility = Visibility.Visible;
                btnSaveBill.Visibility = Visibility.Visible;

            }
            catch (Exception)
            {
                MessageBox.Show("Error loading the Bill detail");
            }
        }
 

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wardDetailGrid.Visibility = Visibility.Collapsed;
                newWardDetailGrid.Visibility = Visibility.Visible;
                btnSaveWard.Visibility = Visibility.Visible;
                clearWardForm();

                newWard = new Ward();
                int numBeds = 0; int numRoom = 0; int wardID = 0; 

                if (int.TryParse(Guid.NewGuid().ToString(), out wardID))
                {
                    numBeds = int.Parse(numBedsTextBox1.Text.Trim());
                    numRoom = int.Parse(numRoomTextBox1.Text.Trim());
                   

                    newWard.NumBeds = numBeds;
                    newWard.NumRoom = numRoom;
                    newWard.WardID = wardID;
                   

                    context.Wards.Add(newWard);
                    MessageBox.Show("New Ward Created");

                    wardView.View.Refresh();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error adding a new ward");
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.SaveChanges();
                MessageBox.Show("Update Successful!");
            }
            catch (Exception)
            {
                MessageBox.Show("Error saving to database");
            }

        }

        private void clearWardForm()
        {
            numBedsTextBox1.Text = "";
            numRoomTextBox1.Text = "";
            wardNameTextBox1.Text = "";
            wardIDTextBox1.Text = "";
            dateCreatedDatePicker1.Text = "";
        }

        private void btnDoctor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //To close unneeded panels and grids
                collapsePanels();

                //To change the Dashboard Heading to Ward Detail
                lblDash.Content = "Doctor Detail";

                //To load and make visible the ward details/ list
                doctorDataGrid.Visibility = Visibility.Visible;
                doctorDetailGrid.Visibility = Visibility.Visible;
                NavButtonsDoc.Visibility = Visibility.Visible;
                newDoctorDetailGrid.Visibility = Visibility.Visible;

            }
            catch (Exception)
            {
                MessageBox.Show("Error loading the Doctors detail");
            }
        }

        private void btnSaveWard_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }

        private void btnDeleteDoc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // If existing window is visible, then delete the Ward.   

                var cur = docView.View.CurrentItem as Doctor;

                var cust = (from d in context.Doctors
                            where d.DoctorID == cur.DoctorID
                            select d).FirstOrDefault();

                context.Doctors.Remove(cust);

                context.SaveChanges();
                docView.View.Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Problem deleting the ward");
            }
        }

        private void btnAddDoc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                doctorDetailGrid.Visibility = Visibility.Collapsed;
                newDoctorDetailGrid.Visibility = Visibility.Visible;
                clearWardForm();

                newDoc = new Doctor();
                int doctorID = 0;

                if (int.TryParse(Guid.NewGuid().ToString(), out doctorID))
                {
                    newDoc.DoctorName = doctorNameTextBox1.Text.Trim();
                    newDoc.Specialty = specialtyTextBox1.Text.Trim();
                    newDoc.PhoneNo = phoneNoTextBox1.Text.Trim();
                    newDoc.Sex = sexTextBox1.Text.Trim();
                    newDoc.DoctorID = doctorID;
                    newDoc.RoomNo = roomNoTextBox1.Text.Trim();

                    context.Doctors.Add(newDoc);
                    MessageBox.Show("New Doctor Created");

                    docView.View.Refresh();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error adding a new Doctor");

            }

        }

        private void btnUpdateDoc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.SaveChanges();
                MessageBox.Show("Update Successful!");
            }
            catch (Exception)
            {
                MessageBox.Show("Error saving to database");
            }
        }

        private void btnPatient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //To close unneeded panels and grids
                collapsePanels();

                //To change the Dashboard Heading to Ward Detail
                lblDash.Content = "Patient View";

                //To load and make visible the ward details/ list
                patientDetailGrid.Visibility = Visibility.Visible;
                patientDataGrid.Visibility = Visibility.Visible;
                btnSavePatient.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading the patients list");
            }
        }

        private void btnApptment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //To hide unneeded panels and grids from view
                collapsePanels();

                //To change the Dashboard Heading to Ward Detail
                lblDash.Content = "Appointment View";
                //To load and make visible the ward details/ list

                appointmentsDataGrid.Visibility = Visibility.Visible;
                appointmentDetailGrid.Visibility = Visibility.Visible;

            }
            catch (Exception)
            {
                MessageBox.Show("Error loading the Appointment detail");
            }
        }

        private void btnBills_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //To hide unneeded panels and grids from view
                collapsePanels();

                //To change the Dashboard Heading to Ward Detail
                lblDash.Content = "Bills View";

                //To load and make visible the ward details/ list
                billDataGrid.Visibility = Visibility.Visible;
                btnSaveBill.Visibility = Visibility.Visible;

            }
            catch (Exception)
            {
                MessageBox.Show("Error loading the Bill detail");
            }
        }

        private void btnUserAcct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //To hide unneeded panels and grids from view
                collapsePanels();

                //To change the Dashboard Heading to Ward Detail
                lblDash.Content = "User View";

                //To load and make visible the ward details/ list
                userDataGrid.Visibility = Visibility.Visible;
                userDetailGrid.Visibility = Visibility.Visible;
                btnSaveUser.Visibility = Visibility.Visible;

            }
            catch (Exception)
            {
                MessageBox.Show("Error loading the Admission detail");
            }
        }
        //To save/ update changes in the patient panels 
        private void btnSavePatient_Click_1(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }

        //To hide the panels from administrator dashboard
        private void collapsePanels()
        {
            doctorDataGrid.Visibility = Visibility.Collapsed;
            doctorDetailGrid.Visibility = Visibility.Collapsed;
            wardDataGrid.Visibility = Visibility.Collapsed;
            wardDetailGrid.Visibility = Visibility.Collapsed;
            newWardDetailGrid.Visibility = Visibility.Collapsed;
            newDoctorDetailGrid.Visibility = Visibility.Collapsed;
            NavButtons.Visibility = Visibility.Collapsed;
            NavButtonsDoc.Visibility = Visibility.Collapsed;
            patientDataGrid.Visibility = Visibility.Collapsed;
            patientDetailGrid.Visibility = Visibility.Collapsed;
            btnSavePatient.Visibility = Visibility.Collapsed;
            welcomePage.Visibility = Visibility.Collapsed;
            appointmentDetailGrid.Visibility = Visibility.Collapsed;
            appointmentsDataGrid.Visibility = Visibility.Collapsed;
            admissionDetailGrid.Visibility = Visibility.Collapsed;
            admissionDataGrid.Visibility = Visibility.Collapsed;
            btnSaveAdmission.Visibility = Visibility.Collapsed;
            billDataGrid.Visibility = Visibility.Collapsed;
            btnSaveBill.Visibility = Visibility.Collapsed;
            userDataGrid.Visibility = Visibility.Collapsed;
            userDetailGrid.Visibility = Visibility.Collapsed;
            btnSaveUser.Visibility = Visibility.Collapsed;

        }

        private void btnSaveAdmission_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }

        private void btnAdmission_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //To hide unneeded panels and grids from view
                collapsePanels();

                //To change the Dashboard Heading to Ward Detail
                lblDash.Content = "Admission View";

                //To load and make visible the ward details/ list
                admissionDetailGrid.Visibility = Visibility.Visible;
                admissionDataGrid.Visibility = Visibility.Visible;
                btnSaveAdmission.Visibility = Visibility.Visible;

            }
            catch (Exception)
            {
                MessageBox.Show("Error loading the Admission detail");
            }
        }

        private void tlAdmission_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //To hide unneeded panels and grids from view
                collapsePanels();

                //To change the Dashboard Heading to Ward Detail
                lblDash.Content = "Admission View";

                //To load and make visible the ward details/ list
                admissionDetailGrid.Visibility = Visibility.Visible;
                admissionDataGrid.Visibility = Visibility.Visible;
                btnSaveAdmission.Visibility = Visibility.Visible;

            }
            catch (Exception)
            {
                MessageBox.Show("Error loading the Admission detail");
            }
        }

        //to save/ update bills
        private void btnSaveBill_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }
        //to save/ update user credetials
        private void btnSaveUser_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }

        //to exit administrator dashboard and navigate back to the Login window
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            reLogin = new Login();
            reLogin.Show();
        }
    }
}
