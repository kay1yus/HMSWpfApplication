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
    /// Interaction logic for DoctorDash.xaml
    /// </summary>
    public partial class DoctorDash : Window
    {
        HMSAppEntities context = new HMSAppEntities();

        private Login relogin = new Login();
        CollectionViewSource patDocView;
        CollectionViewSource apptmentView;
        CollectionViewSource admissionView;


        public DoctorDash()
        {
            InitializeComponent();
            patDocView = ((CollectionViewSource)
                (FindResource("patientViewSource")));
            DataContext = this;

            apptmentView = ((CollectionViewSource)
                (FindResource("appointmentViewSource")));
            DataContext = this;

            //admissionView = ((CollectionViewSource)
            //    (FindResource("admissionViewSource")));
            //DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                appointmentDataGrid.Visibility = Visibility.Visible;
                appointmentDetailGrid.Visibility = Visibility.Visible;

                context.Patients.Load();
                patDocView.Source = context.Patients.Local;

                context.Appointments.Load();
                apptmentView.Source = context.Appointments.Local;

                //context.Admissions.Load();
                //admissionView.Source = context.Admissions.Local;
            }
            catch (Exception)
            {
                MessageBox.Show("Error Loading panels");
            }
           
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPatient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //To show patient details om window
                patientDataGrid.Visibility = Visibility.Visible;
                docPatientDetailGrid.Visibility = Visibility.Visible;

                //To hide appointment details from window
                appointmentDataGrid.Visibility = Visibility.Collapsed;
                appointmentDetailGrid.Visibility = Visibility.Collapsed;
                admissionDataGrid.Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {
                MessageBox.Show("Error Loading patient details");
            }
           
        }

        private void btnAdmission_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //To hide appointment details on window
                appointmentDataGrid.Visibility = Visibility.Visible;
                appointmentDetailGrid.Visibility = Visibility.Visible;

                //To hide patient details from window
                patientDataGrid.Visibility = Visibility.Collapsed;
                docPatientDetailGrid.Visibility = Visibility.Collapsed;

                admissionDataGrid.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                MessageBox.Show("Error Loading admission details");
            }
            
        }

        private void btnApptment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //To show appointment details on window
                appointmentDataGrid.Visibility = Visibility.Visible;
                appointmentDetailGrid.Visibility = Visibility.Visible;

                //To hide patient details from window
                admissionDataGrid.Visibility = Visibility.Collapsed;
                patientDataGrid.Visibility = Visibility.Collapsed;
                docPatientDetailGrid.Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {
                MessageBox.Show("Error Loading appointment details");
            }
            
        }
    }
}
