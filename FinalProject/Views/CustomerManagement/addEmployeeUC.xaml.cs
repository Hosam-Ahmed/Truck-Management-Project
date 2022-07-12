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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FinalProject.Models;
using FinalProject.Models.DB;

namespace Project.Views.CustomerManagement
{
    /// <summary>
    /// Interaction logic for addEmployeeUC.xaml
    /// </summary>
    public partial class addEmployeeUC : UserControl
    {
        public addEmployeeUC()
        {
            InitializeComponent();
            errorLabel.Visibility = Visibility.Hidden;
            usernameErrorLabel.Visibility = Visibility.Hidden;
        }


        private void addEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            int output = DAO.validEmptyInput(formGrid);
            if (output != 0)
            {
                if (usernameErrorLabel.Visibility == Visibility.Hidden)
                    errorLabel.Visibility = Visibility.Visible;
                else
                    errorLabel.Visibility = Visibility.Hidden;
            }
            else
            {

                string name = nameTextBox.Text;
                string address = addressTextBox.Text;
                string telephone = telephoneTextBox.Text;
                string officeAddress = officeAddressTextBox.Text;
                string phoneExt = phoneExtTextBox.Text;
                string username = usernameTextBox.Text;
                string password = passwordTextBox.Text;
                string role = roleComboBox.Text;
                //Parent Class
                TruckPerson truckPerson = new TruckPerson();
                truckPerson.Name = name;
                truckPerson.Address = address;
                truckPerson.Telephone = telephone;

                //Child Class
                TruckEmployee truckEmployee = new TruckEmployee();
                truckEmployee.OfficeAddress = officeAddress;
                truckEmployee.Username = username;
                truckEmployee.Password = password;
                truckEmployee.Role = role;
                truckEmployee.PhoneExtensionNumber = phoneExt;
                truckEmployee.Employee = truckPerson;
                errorLabel.Visibility = Visibility.Hidden;


                try
                {
                    DAO.addEmployee(truckEmployee);
                    MessageBox.Show("Employee Added Successfully!");
                    nameTextBox.Clear();
                    addressTextBox.Clear();
                    telephoneTextBox.Clear();
                    officeAddressTextBox.Clear();
                    usernameTextBox.Clear();
                    passwordTextBox.Clear();
                    phoneExtTextBox.Clear();
                    errorLabel.Visibility = Visibility.Hidden;
                }

                catch (Exception ex)
                {

                    usernameErrorLabel.Visibility = Visibility.Visible;
                    usernameTextBox.BorderBrush = Brushes.Red;
                }
            }
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            nameTextBox.Clear();
            addressTextBox.Clear();
            telephoneTextBox.Clear();
            officeAddressTextBox.Clear();
            usernameTextBox.Clear();
            passwordTextBox.Clear();
            phoneExtTextBox.Clear();
        }
    }
}
