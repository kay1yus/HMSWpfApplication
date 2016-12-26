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
    /// Interaction logic for DoctorMainDash.xaml
    /// </summary>
    public partial class DoctorMainDash : Window
    {
        HMSAppEntities dbContext = new HMSAppEntities();
        CollectionViewSource patDocView;
        CollectionViewSource apptmentView;
        CollectionViewSource admissionView;
        public DoctorMainDash()
        {
            InitializeComponent();

            admissionView = ((CollectionViewSource)
               (FindResource("admissionViewSource")));
            DataContext = this;

            apptmentView = ((CollectionViewSource)
               (FindResource("appointmentViewSource")));
            DataContext = this;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dbContext.Appointments.Load();
            apptmentView.Source = dbContext.Appointments.Local;

            dbContext.Admissions.Load();
            admissionView.Source = dbContext.Admissions.Local;

            System.Windows.Data.CollectionViewSource appointmentViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("appointmentViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // appointmentViewSource.Source = [generic data source]

            System.Windows.Data.CollectionViewSource admissionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("admissionViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // admissionViewSource.Source = [generic data source]
        }

        private void btnApptmentUpdate_Click(object sender, RoutedEventArgs e)
        {
            dbContext.SaveChanges();
        }

        private void btnApptment_Click(object sender, RoutedEventArgs e)
        {
            //to hide other panels
            collapsePanels();

            //to show appointment panel
            appointmentDataGrid.Visibility = Visibility.Visible;
            appointmentDetailGrid.Visibility = Visibility.Visible;
            btnApptmentUpdate.Visibility = Visibility.Visible;
            appointmentListView.Visibility = Visibility.Visible;
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            Login xLog = new Login();
            this.Close();
            xLog.Show();
        }

       

        private void btnPatient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdmission_Click(object sender, RoutedEventArgs e)
        {
            //to hide other panels
            collapsePanels();

            //to show admission panel
            admissionDetailGrid.Visibility = Visibility.Visible;
            admissionDataGrid.Visibility = Visibility.Visible;
            btnAdmissionUpdate.Visibility = Visibility.Visible;
        }

        private void btnAdmissionUpdate_Click(object sender, RoutedEventArgs e)
        {
            dbContext.SaveChanges();
        }
        private void collapsePanels()
        {
            appointmentDataGrid.Visibility = Visibility.Collapsed;
            appointmentDetailGrid.Visibility = Visibility.Collapsed;
            btnApptmentUpdate.Visibility = Visibility.Collapsed;
            appointmentListView.Visibility = Visibility.Collapsed;
            admissionDetailGrid.Visibility = Visibility.Collapsed;
            admissionDataGrid.Visibility = Visibility.Collapsed;
            btnAdmissionUpdate.Visibility = Visibility.Collapsed;
        }
        
    }
}
