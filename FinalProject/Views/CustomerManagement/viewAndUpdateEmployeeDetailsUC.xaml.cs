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
    /// Interaction logic for viewAndUpdateEmployeeDetailsUC.xaml
    /// </summary>
    public partial class viewAndUpdateEmployeeDetailsUC : UserControl
    {
        int count;
        TruckPerson ed = new TruckPerson();
        EmployeeDetails emd = new EmployeeDetails();

        public viewAndUpdateEmployeeDetailsUC()
        {
            InitializeComponent();
            isVisibleEmployeeFields(false);
            isVisibleIDInputs(false);
            errorLabel.Visibility = Visibility.Hidden;
            usernameTextBox.IsEnabled = false;
            roleComboBox.IsEnabled = false;
            detailsDataGrid.Visibility = Visibility.Hidden;
        }

        private void isAdmin(bool v)
        {
            if (v)
            {
                updateButoon.Visibility = Visibility.Visible;
                roleComboBox.IsEnabled = true;
                nameTextBox.IsEnabled = true;
                addressTextBox.IsEnabled = true;
                telephoneTextBox.IsEnabled = true;
                officeAddressTextBox.IsEnabled = true;
                phoneExtTextBox.IsEnabled = true;
                officeAddressTextBox.IsEnabled = true;
                usernameTextBox.IsEnabled = false;
                passwordTextBox.IsEnabled = true;
                roleComboBox.IsEnabled = true;
                updateButoon.IsEnabled = true;
            }
            else
            {
                updateButoon.Visibility = Visibility.Hidden;
                roleComboBox.IsEnabled = false;
                nameTextBox.IsEnabled = false;
                addressTextBox.IsEnabled = false;
                telephoneTextBox.IsEnabled = false;
                officeAddressTextBox.IsEnabled = false;
                phoneExtTextBox.IsEnabled = false;
                officeAddressTextBox.IsEnabled = false;
                usernameTextBox.IsEnabled = false;
                passwordTextBox.IsEnabled = false;
                roleComboBox.IsEnabled = false;
                updateButoon.IsEnabled = false;

            }
        }

        private void isVisibleIDInputs(bool v)
        {
            if (v)
            {
                idComboBox.Visibility = Visibility.Visible;
                searchIDButton.Visibility = Visibility.Visible;
            }
            else
            {
                idComboBox.Visibility = Visibility.Hidden;
                searchIDButton.Visibility = Visibility.Hidden;
            }
        }

        private void isVisibleEmployeeFields(bool v)
        {
            if (v)
            {
                nameTextBox.Visibility = Visibility.Visible;
                addressTextBox.Visibility = Visibility.Visible;
                telephoneTextBox.Visibility = Visibility.Visible;
                officeAddressTextBox.Visibility = Visibility.Visible;
                phoneExtTextBox.Visibility = Visibility.Visible;
                officeAddressTextBox.Visibility = Visibility.Visible;
                usernameTextBox.Visibility = Visibility.Visible;
                passwordTextBox.Visibility = Visibility.Visible;
                roleComboBox.Visibility = Visibility.Visible;
                updateButoon.Visibility = Visibility.Visible;

            }
            else
            {
                nameTextBox.Visibility = Visibility.Hidden;
                addressTextBox.Visibility = Visibility.Hidden;
                telephoneTextBox.Visibility = Visibility.Hidden;
                officeAddressTextBox.Visibility = Visibility.Hidden;
                phoneExtTextBox.Visibility = Visibility.Hidden;
                officeAddressTextBox.Visibility = Visibility.Hidden;
                usernameTextBox.Visibility = Visibility.Hidden;
                passwordTextBox.Visibility = Visibility.Hidden;
                roleComboBox.Visibility = Visibility.Hidden;
                updateButoon.Visibility = Visibility.Hidden;

            }
        }
        private void searchEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            isVisibleIDInputs(true);
            isVisibleEmployeeFields(false);

            count = 1;
            idComboBox.ItemsSource = DAO.GetEmployeeID();
            idComboBox.DisplayMemberPath = "EmployeeId";
            idComboBox.SelectedValuePath = "EmployeeId";
        }

        private void searchAllEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            detailsDataGrid.Visibility = Visibility.Visible;
            detailsDataGrid.ItemsSource = DAO.GetEmployee();
        }

        private void updateButoon_Click(object sender, RoutedEventArgs e)
        {
            if (count == 1)
            {
                int output = DAO.validEmptyInput(formGrid);
                if (output != 0)
                {
                    MessageBox.Show("Enter Missing val");
                }
                else
                {
                    int id = int.Parse(idComboBox.Text);
                    ed = DAO.searchEmployeeByID(id);
                    string name = nameTextBox.Text;
                    string address = addressTextBox.Text;
                    string telephone = telephoneTextBox.Text;
                    string officeAddress = officeAddressTextBox.Text;
                    string phoneExt = phoneExtTextBox.Text;
                    string username = usernameTextBox.Text;
                    string password = passwordTextBox.Text;
                    string role = roleComboBox.Text;
                    if (ed != null)
                    {
                        ed.Name = name;
                        ed.Address = address;
                        ed.Telephone = telephone;
                        ed.TruckEmployee.OfficeAddress = officeAddress;
                        ed.TruckEmployee.PhoneExtensionNumber = phoneExt;
                        ed.TruckEmployee.Username = username;
                        ed.TruckEmployee.Password = password;
                        ed.TruckEmployee.Role = roleComboBox.Text;
                        DAO.updateEmployeeRecord(ed);
                        MessageBox.Show("Updated Successfully");
                        isVisibleEmployeeFields(false);
                    }
                }

            }
        }


        private void SearchID_Click(object sender, RoutedEventArgs e)
        {
            emd = DAO.fetchPersonalInfo().FirstOrDefault();

            if (count == 1)
            {

                if (idComboBox.SelectedIndex == -1)
                {
                    idComboBox.BorderBrush = Brushes.Red;
                    errorLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    int id = int.Parse(idComboBox.Text);
                    errorLabel.Visibility = Visibility.Hidden;
                    idComboBox.BorderBrush = Brushes.Black;
                    TruckPerson p = DAO.searchEmployeeByID(id);
                    if (p != null)
                    {
                        addressTextBox.Text = p.Address;
                        telephoneTextBox.Text = p.Telephone;
                        nameTextBox.Text = p.Name;
                        phoneExtTextBox.Text = p.TruckEmployee.PhoneExtensionNumber;
                        usernameTextBox.Text = p.TruckEmployee.Username;
                        passwordTextBox.Text = p.TruckEmployee.Password;
                        officeAddressTextBox.Text = p.TruckEmployee.OfficeAddress;
                        roleComboBox.Text = p.TruckEmployee.Role;


                        isVisibleEmployeeFields(true);
                        if (emd.Role == "Admin")
                        {
                            isAdmin(true);
                        }
                        else
                        {
                            isAdmin(false);

                        }
                    }
                }
            }
        }
    }
}

