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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        ////To create an instance of the ModelEntities
        HMSAppEntities context;
        AdminDashboard amw = new AdminDashboard(); 
        DoctorMainDash dmd = new DoctorMainDash();
        PatientDash pmv = new PatientDash();
        Registration regForm = new Registration();

        public Login()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            regForm.Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            tbxUserName.Clear();
            tbxPwd.Clear();
            lblValid.Content = "";
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context = new HMSAppEntities();

                var result = context.Users.FirstOrDefault(i => i.UserName.Equals(tbxUserName.Text) && i.Password.Equals(tbxPwd.Password));
                if (result != null)
                {
                    if (result.RoleID.Equals(1))
                    {
                        amw.Show();
                        this.Close();
                    }
                    else if (result.RoleID.Equals(2))
                    {
                        dmd.Show();
                        
                        this.Close();
                    }
                    else if (result.RoleID.Equals(3))
                    {
                        pmv.Show();
                        this.Close();
                    }
                    else
                        MessageBox.Show("User not found!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problem validating user credential");
            }
        }

        private void btnCloseSplash_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
