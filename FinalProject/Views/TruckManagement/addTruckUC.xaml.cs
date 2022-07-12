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

namespace Project.Views.TruckManagement
{
    /// <summary>
    /// Interaction logic for addTruckUC.xaml
    /// </summary>
    public partial class addTruckUC : UserControl
    {
        IndividualTruck newTruck = new IndividualTruck();

        public addTruckUC()
        {
            InitializeComponent();
            errorLabel.Visibility = Visibility.Hidden;
        }

        private void addTruckButton_Click(object sender, RoutedEventArgs e)
        {
            int output = DAO.validEmptyInput(formGrid);

            if (output != 0)
                errorLabel.Visibility = Visibility.Visible;
            else
            {
                //Indvidual Truck input
                string colour = colourTextBox.Text;
                string registerationNumber = regNumberTextBox.Text;
                DateTime wofExpiryDate = wofExpDatePicker.SelectedDate.Value.Date;
                DateTime regExpiryDate = regExpDatePicker.SelectedDate.Value.Date;
                DateTime dateImported = dateImportedDatePicker.SelectedDate.Value.Date;
                int manufacturerYear = int.Parse(manufacturerYearTextBox.Text);
                string status = statusComboBox.Text;
                string fuelType = fuelTypeComboBox.Text;
                string transmission = transmissionComboBox.Text;
                decimal dailyRentalPrice = decimal.Parse(dailyRentalPriceTextBox.Text);
                decimal AdvanceDepositRequired = decimal.Parse(advanceDepositTextBox.Text);

                //Truck model input
                string model = modelTextBox.Text;
                string manufacturer = manufacturerTextBox.Text;
                string size = sizeComboBox.Text;
                int seats = int.Parse(seatsTextBox.Text);
                int doors = int.Parse(doorsTextBox.Text);

                //creating object for new truck
                newTruck = new IndividualTruck();
                newTruck.Colour = colour;
                newTruck.RegistrationNumber = registerationNumber;
                newTruck.WofexpiryDate = wofExpiryDate;
                newTruck.RegistrationExpiryDate = regExpiryDate;
                newTruck.DateImported = dateImported;
                newTruck.ManufactureYear = manufacturerYear;
                newTruck.Status = status;
                newTruck.FuelType = fuelType;
                newTruck.Transmission = transmission;
                newTruck.DailyRentalPrice = dailyRentalPrice;
                newTruck.AdvanceDepositRequired = AdvanceDepositRequired;

                //creating object for truck model
                TruckModel truckModel = new TruckModel();
                truckModel.Model = model;
                truckModel.Manufacturer = manufacturer;
                truckModel.Size = size;
                truckModel.Seats = seats;
                truckModel.Doors = doors;

                newTruck.TruckModel = truckModel;

                DAO.addNewTruck(newTruck);
                MessageBox.Show("Truck added successfully");
                clear();
            }
        }

        private void clear()
        {
            colourTextBox.Clear();
            regNumberTextBox.Clear();
            wofExpDatePicker.SelectedDate = null;
            regExpDatePicker.SelectedDate = null;
            dateImportedDatePicker.SelectedDate = null;
            manufacturerTextBox.Clear();
            manufacturerYearTextBox.Clear();
            statusComboBox.SelectedItem = null;
            fuelTypeComboBox.SelectedItem = null;
            transmissionComboBox.SelectedItem = null;
            dailyRentalPriceTextBox.Clear();
            advanceDepositTextBox.Clear();
            modelTextBox.Clear();
            manufacturerTextBox.Clear();
            sizeComboBox.SelectedItem = null;
            doorsTextBox.Clear();
            seatsTextBox.Clear();
        }
    }
}
