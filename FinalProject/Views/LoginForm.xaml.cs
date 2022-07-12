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
using FinalProject.Models.DB;
using FinalProject.Models;
using FinalProject.Views;


namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        EmployeeDetails ed = new EmployeeDetails();

        public LoginForm()
        {
            InitializeComponent();
            errorLabel.Visibility = Visibility.Hidden;
            crediantilErrorlabel.Visibility = Visibility.Hidden;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            int output = DAO.validEmptyInput(formGrid);
            if (output != 0)
                errorLabel.Visibility = Visibility.Visible;
            else
            {
                errorLabel.Visibility = Visibility.Hidden;
                string usname = usernameTextBox.Text;
                string pass = passwordTextBox.Text;
                TruckEmployee truckEmployee = new TruckEmployee();
                truckEmployee.Username = usname;
                truckEmployee.Password = pass;
                try
                {
                    DAO.login(truckEmployee);
                    MainForm mainWindow = new MainForm();
                    mainWindow.Show();
                    this.Hide();
                    errorLabel.Visibility = Visibility.Hidden;
                }
                catch (Exception ex)
                {
                    crediantilErrorlabel.Visibility = Visibility.Visible;
                    usernameTextBox.Clear();
                    passwordTextBox.Clear();
                    usernameTextBox.BorderBrush = Brushes.Red;
                    passwordTextBox.BorderBrush = Brushes.Red;
                }
            }
        }
    }
}
