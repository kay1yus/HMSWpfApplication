using System;
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
using System.Windows.Shapes;

namespace HMSWpfApplication
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        HMSAppEntities context = new HMSAppEntities();

        //To create an instance of a patient
        public Patient newPatient;

        private Login reLog;
        CollectionViewSource newPatientView;

        public Registration()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource patientViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("patientViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // patientViewSource.Source = [generic data source]
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                newPatient = new Patient();
                newPatient.Address = addressTextBox.Text;
                newPatient.FirstName = firstNameTextBox.Text;
                newPatient.LastName = lastNameTextBox.Text;
                newPatient.Email = emailTextBox.Text;
                newPatient.Sex = sexTextBox.Text;
                context.Patients.Add(newPatient);
                context.SaveChanges();

                reLog = new Login();
                reLog.Show();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error adding new patient");
            }
      

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Login relogin = new Login();
            this.Close();
            relogin.Show();
        }
    }
}
