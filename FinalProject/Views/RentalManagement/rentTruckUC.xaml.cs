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
using Project.Views.CustomerManagement;

namespace FinalProject.Views.RentalManagement
{
    /// <summary>
    /// Interaction logic for rentTruckUC.xaml
    /// </summary>
    public partial class rentTruckUC : UserControl
    {
        IndividualTruck truck = null;
        TruckCustomer customer = null;

        public rentTruckUC()
        {
            InitializeComponent();

            truckIDComboBox.ItemsSource = DAO.GetIndividualTrucks();
            truckIDComboBox.DisplayMemberPath = "RegistrationNumber";
            truckIDComboBox.SelectedValuePath = "RegistrationNumber";

            customerIDComboBox.ItemsSource = DAO.getCustomer();
            customerIDComboBox.DisplayMemberPath = "CustomerId";
            customerIDComboBox.SelectedValuePath = "CustomerId";

            hideTruck(true);
            hideCustomer(true);
            errorLabel.Visibility = Visibility.Hidden;
        }

        private void addCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            MainForm frm = new MainForm();
            frm.Show();
            frm.mainControl.Children.Clear();
            frm.mainControl.Children.Add(new addCustomerUC());
            Window.GetWindow(this).Close();
        }

        private void rent_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(truckIDComboBox.Text) && string.IsNullOrEmpty(customerIDComboBox.Text) && returnDateDatePicker.SelectedDate == null)
            {
                errorLabel.Visibility = Visibility.Visible;
                truckIDComboBox.BorderBrush = Brushes.Red;
                customerIDComboBox.BorderBrush = Brushes.Red;
                returnDateDatePicker.BorderBrush = Brushes.Red;
                hideTruck(true);
                hideCustomer(true);
            }
            else if (string.IsNullOrEmpty(truckIDComboBox.Text))
            {
                errorLabel.Visibility = Visibility.Visible;
                truckIDComboBox.BorderBrush = Brushes.Red;
            }
            else if (string.IsNullOrEmpty(customerIDComboBox.Text))
            {
                errorLabel.Visibility = Visibility.Visible;
                customerIDComboBox.BorderBrush = Brushes.Red;
            }
            else if (returnDateDatePicker.SelectedDate == null)
            {
                errorLabel.Visibility = Visibility.Visible;
                returnDateDatePicker.BorderBrush = Brushes.Red;
            }
            else if (!string.IsNullOrEmpty(truckIDComboBox.Text) && !string.IsNullOrEmpty(customerIDComboBox.Text) && returnDateDatePicker.SelectedDate != null)
            {
                truck = DAO.searchTruckRego(truckIDComboBox.Text);
                customer = DAO.searchCustomerID(int.Parse(customerIDComboBox.Text));

                DateTime rentDate = DateTime.Now;
                DateTime returnDate = returnDateDatePicker.SelectedDate.Value.Date;
                TimeSpan difference = returnDate - rentDate;
                int days = difference.Days;

                decimal total = days * (int)truck.DailyRentalPrice;

                TruckRental rent = new TruckRental();
                rent.TruckId = truck.TruckId;
                rent.CustomerId = customer.CustomerId;
                rent.RentDate = rentDate;
                rent.ReturnDueDate = returnDate;
                rent.TotalPrice = total;

                DAO.rentTruck(rent, truck);
                MessageBox.Show("Truck Rented");
            }
            else
            {
                truckIDComboBox.BorderBrush = Brushes.Black;
                customerIDComboBox.BorderBrush = Brushes.Black;
                returnDateDatePicker.BorderBrush = Brushes.Black;
                errorLabel.Visibility = Visibility.Hidden;
            }
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(truckIDComboBox.Text) && string.IsNullOrEmpty(customerIDComboBox.Text))
            {
                errorLabel.Visibility = Visibility.Visible;
                truckIDComboBox.BorderBrush = Brushes.Red;
                customerIDComboBox.BorderBrush = Brushes.Red;
                hideTruck(true);
                hideCustomer(true);
            }
            else if (!string.IsNullOrEmpty(truckIDComboBox.Text) && string.IsNullOrEmpty(customerIDComboBox.Text))
            {
                truck = DAO.searchTruckRego(truckIDComboBox.Text);
                TruckModel model = DAO.searchTruckByModelID(truck);

                hideTruck(false);
                registrationTextBox.Text = truck.RegistrationNumber;
                colourTextBox.Text = truck.Colour;
                rentTextBox.Text = truck.DailyRentalPrice.ToString();
                truckModelTextBox.Text = model.Model;
                manufacturerTextBox.Text = model.Manufacturer;

                customerIDComboBox.BorderBrush = Brushes.Red;
                truckIDComboBox.BorderBrush = Brushes.Black;
                errorLabel.Visibility = Visibility.Hidden;
                hideCustomer(true);
            }
            else if (string.IsNullOrEmpty(truckIDComboBox.Text) && !string.IsNullOrEmpty(customerIDComboBox.Text))
            {
                customer = DAO.searchCustomerID(int.Parse(customerIDComboBox.Text));
                TruckPerson person = DAO.getCustomerOnly(int.Parse(customerIDComboBox.Text));

                hideCustomer(false);
                nameTextBox.Text = person.Name;
                licenseTextBox.Text = customer.LicenseNumber;

                truckIDComboBox.BorderBrush = Brushes.Red;
                customerIDComboBox.BorderBrush = Brushes.Black;
                errorLabel.Visibility = Visibility.Hidden;
                hideTruck(true);
            }
            else if (!string.IsNullOrEmpty(truckIDComboBox.Text) && !string.IsNullOrEmpty(customerIDComboBox.Text))
            {
                truck = DAO.searchTruckRego(truckIDComboBox.Text);
                TruckModel model = DAO.searchTruckByModelID(truck);
                customer = DAO.searchCustomerID(int.Parse(customerIDComboBox.Text));
                TruckPerson person = DAO.getCustomerOnly(int.Parse(customerIDComboBox.Text));

                hideTruck(false);
                hideCustomer(false);
                registrationTextBox.Text = truck.RegistrationNumber;
                colourTextBox.Text = truck.Colour;
                rentTextBox.Text = truck.DailyRentalPrice.ToString();
                truckModelTextBox.Text = model.Model;
                manufacturerTextBox.Text = model.Manufacturer;

                nameTextBox.Text = person.Name;
                licenseTextBox.Text = customer.LicenseNumber;

                truckIDComboBox.BorderBrush = Brushes.Black;
                customerIDComboBox.BorderBrush = Brushes.Black;
                returnDateDatePicker.BorderBrush = Brushes.Black;

                errorLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                truckIDComboBox.BorderBrush = Brushes.Black;
                customerIDComboBox.BorderBrush = Brushes.Black;
                returnDateDatePicker.BorderBrush = Brushes.Black;
                errorLabel.Visibility = Visibility.Hidden;
                hideTruck(true);
                hideCustomer(true);
            }
        }

        private void hideTruck(bool hide)
        {
            if (hide == true)
            {
                registrationTextBox.Visibility = Visibility.Hidden;
                colourTextBox.Visibility = Visibility.Hidden;
                rentTextBox.Visibility = Visibility.Hidden;
                truckModelTextBox.Visibility = Visibility.Hidden;
                manufacturerTextBox.Visibility = Visibility.Hidden;
            }
            else
            {
                registrationTextBox.Visibility = Visibility.Visible;
                colourTextBox.Visibility = Visibility.Visible;
                rentTextBox.Visibility = Visibility.Visible;
                truckModelTextBox.Visibility = Visibility.Visible;
                manufacturerTextBox.Visibility = Visibility.Visible;
            }
        }

        private void hideCustomer(bool hide)
        {
            if (hide == true)
            {
                nameTextBox.Visibility = Visibility.Hidden;
                licenseTextBox.Visibility = Visibility.Hidden;
            }
            else
            {
                nameTextBox.Visibility = Visibility.Visible;
                licenseTextBox.Visibility = Visibility.Visible;
            }
        }
    }
}
