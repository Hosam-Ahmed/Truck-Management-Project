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
using FinalProject.Models.DB;
using FinalProject.Models;

namespace Project.Views.CustomerManagement
{
    /// <summary>
    /// Interaction logic for addCustomerUC.xaml
    /// </summary>
    public partial class addCustomerUC : UserControl
    {
        public addCustomerUC()
        {
            InitializeComponent();

            errorLabel.Visibility = Visibility.Hidden;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            //checking for validation
            int output = DAO.validEmptyInput(formGrid);
            if (output != 0)
            {
                errorLabel.Visibility = Visibility.Visible;
            }
            else
            {
                //creating person
                TruckPerson person = new TruckPerson();
                person.Name = nameTextBox.Text;
                person.Address = addressTextBox.Text;
                person.Telephone = phoneTextBox.Text;

                //creating customer
                TruckCustomer customer = new TruckCustomer();
                customer.LicenseNumber = licenseTextBox.Text;
                customer.Age = int.Parse(ageTextBox.Text);
                customer.LicenseExpiryDate = licenseExpiryDatePicker.SelectedDate.Value.Date;

                //link customer to person
                customer.Customer = person;

                //adding customer
                DAO.addCustomer(customer);
                MessageBox.Show("Customer Added");

                errorLabel.Visibility = Visibility.Hidden;
            }
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            nameTextBox.Clear();
            addressTextBox.Clear();
            phoneTextBox.Clear();
            licenseTextBox.Clear();
            ageTextBox.Clear();
            licenseExpiryDatePicker.SelectedDate = null;

            errorLabel.Visibility = Visibility.Hidden;

        }
    }
}