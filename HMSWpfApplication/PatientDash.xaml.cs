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
    /// Interaction logic for PatientDash.xaml
    /// </summary>
    public partial class PatientDash : Window
    {
        HMSAppEntities context = new HMSAppEntities();
        CollectionViewSource patBillView;
        CollectionViewSource patApptmentView;
        CollectionViewSource patProfileView;
        public PatientDash()
        {
            InitializeComponent();
            patBillView = ((CollectionViewSource)
            (FindResource("billViewSource")));
            DataContext = this;

            patProfileView = ((CollectionViewSource)
            (FindResource("patientViewSource")));
            DataContext = this;

            patApptmentView = ((CollectionViewSource)
            (FindResource("appointmentViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            patientProfileGrid.Visibility = Visibility.Visible;
            btnUpdatePat.Visibility = Visibility.Visible;

            context.Bills.Load();
            patBillView.Source = context.Bills.Local;

            context.Patients.Load();
            patProfileView.Source = context.Patients.Local;

            context.Appointments.Load();
            patApptmentView.Source = context.Appointments.Local;

            
        }

        private void btnBills_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                patientProfileGrid.Visibility = Visibility.Collapsed;
                btnUpdatePat.Visibility = Visibility.Collapsed;
                Apptgrid.Visibility = Visibility.Collapsed;
                btnAppointmentSubmit.Visibility = Visibility.Collapsed;
                appointmentDataGrid.Visibility = Visibility.Collapsed;
                billDataGrid.Visibility = Visibility.Visible;

                //var cur = patBillView.View.CurrentItem as Bill;

               // var cust = (from d in context.Bills
               //             where d.PatientID == cur.PatientID
               //             select d).FirstOrDefault();


                patBillView.View.Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Error viewing bills");
            }
        }

        private void btnApptment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //to clear the appointment form
                appointmentDateDatePicker.Text = "";
                appointmentTimeTextBox.Text = "";
                appointmentIDTextBox.Text = Guid.NewGuid().ToString();

                //to hide panels from the window
                patientProfileGrid.Visibility = Visibility.Collapsed;
                billDataGrid.Visibility = Visibility.Collapsed;
                btnUpdatePat.Visibility = Visibility.Collapsed;


                //to show panels in the Patient window
                Apptgrid.Visibility = Visibility.Visible;
                btnAppointmentSubmit.Visibility = Visibility.Visible;
                appointmentDataGrid.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                MessageBox.Show("Error viewing bills");
            } 

        }

        private void btnUpdatePat_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }

        private void btnAppointmentSubmit_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }
    }
}
