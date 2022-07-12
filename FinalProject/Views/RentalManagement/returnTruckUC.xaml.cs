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

namespace Project.Views.RentalManagement
{
    /// <summary>
    /// Interaction logic for returnTruckUC.xaml
    /// </summary>
    public partial class returnTruckUC : UserControl
    {
        TruckRental rent = null;
        IndividualTruck truck = null;

        public returnTruckUC()
        {
            InitializeComponent();

            truckIDComboBox.ItemsSource = DAO.getRentedTrucks();
            truckIDComboBox.DisplayMemberPath = "RegistrationNumber";
            truckIDComboBox.SelectedValuePath = "RegistrationNumber";

            errorLabel.Visibility = Visibility.Hidden;
            hideTruck(true);
        }

        private void searchTruckButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(truckIDComboBox.Text))
            {
                errorLabel.Visibility = Visibility.Visible;
                truckIDComboBox.BorderBrush = Brushes.Red;
                hideTruck(true);
            }
            else if (!string.IsNullOrEmpty(truckIDComboBox.Text))
            {
                truck = DAO.searchTruckRego(truckIDComboBox.Text);
                rent = DAO.searchRented(truck);
                TruckModel model = DAO.searchTruckByModelID(truck);

                hideTruck(false);
                truckModelTextBox.Text = model.Model;
                manufacturerTextBox.Text = model.Manufacturer;
                registrationTextBox.Text = truck.RegistrationNumber;
                colourTextBox.Text = truck.Colour;
                totalCostTextBox.Text = truck.DailyRentalPrice.ToString();

                errorLabel.Visibility = Visibility.Hidden;
                truckIDComboBox.BorderBrush = Brushes.Black;
            }
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(truckIDComboBox.Text))
            {
                errorLabel.Visibility = Visibility.Visible;
                truckIDComboBox.BorderBrush = Brushes.Red;
                hideTruck(true);
            }
            else
            {
                hideTruck(true);

                truck = DAO.searchTruckRego(truckIDComboBox.Text);
                rent = DAO.searchRented(truck);

                truck.Status = "Available for rent";
                rent.ReturnDate = DateTime.Now;

                DAO.returnTruck(rent, truck);

                MessageBox.Show("Truck Returned");

                errorLabel.Visibility = Visibility.Hidden;
                truckIDComboBox.BorderBrush = Brushes.Black;
            }
        }

        private void hideTruck(bool hide)
        {
            if (hide == true)
            {
                registrationTextBox.Visibility = Visibility.Hidden;
                colourTextBox.Visibility = Visibility.Hidden;
                totalCostTextBox.Visibility = Visibility.Hidden;
                truckModelTextBox.Visibility = Visibility.Hidden;
                manufacturerTextBox.Visibility = Visibility.Hidden;
            }
            else
            {
                registrationTextBox.Visibility = Visibility.Visible;
                colourTextBox.Visibility = Visibility.Visible;
                totalCostTextBox.Visibility = Visibility.Visible;
                truckModelTextBox.Visibility = Visibility.Visible;
                manufacturerTextBox.Visibility = Visibility.Visible;
            }
        }
    }
}