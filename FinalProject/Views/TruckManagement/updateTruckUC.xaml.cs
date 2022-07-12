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

namespace Project.Views.TruckManagement
{
    /// <summary>
    /// Interaction logic for updateTruckUC.xaml
    /// </summary>
    public partial class updateTruckUC : UserControl
    {
        List<TruckDetailsDisplay> data = null;
        TruckModel model = null;
        IndividualTruck truck = null;

        public updateTruckUC()
        {
            InitializeComponent();

            hide(true);
            errorLabel.Visibility = Visibility.Hidden;
        }

        private void showButton_Click(object sender, RoutedEventArgs e)
        {
            data = DAO.GetTruckDetails();
            grid.ItemsSource = data;
        }


        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            int output = DAO.validEmptyInput(formGrid);

            if (output != 0 && string.IsNullOrEmpty(modelTextBox.Text))
                errorLabel.Visibility = Visibility.Visible;
            else
            {
                string truckmodel = modelTextBox.Text;

                model = DAO.searchTruckByModel(truckmodel);
                truck = DAO.getTruckWithModel(truckmodel);

                if (model == null)
                {
                    MessageBox.Show("No record found");
                    grid.ItemsSource = null;
                    hide(true);
                }
                else
                {
                    hide(false);

                    colorTextBox.Text = truck.Colour;
                    registrationNumberTextBox.Text = truck.RegistrationNumber;
                    wofexpiryDateDatePicker.SelectedDate = truck.WofexpiryDate;
                    registrationExpiryDateDatePicker.SelectedDate = truck.RegistrationExpiryDate;
                    dailyRentalPriceTextBox.Text = truck.DailyRentalPrice.ToString();
                    advanceDepositRequiredTextBox.Text = truck.AdvanceDepositRequired.ToString();
                    seatsTextBox.Text = model.Seats.ToString();
                    statusComboBox.Text = truck.Status;

                    output = DAO.validEmptyInput(formGrid);
                }

                errorLabel.Visibility = Visibility.Hidden;
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            int output = DAO.validEmptyInput(formGrid);

            if (output != 0)
                errorLabel.Visibility = Visibility.Visible;
            else
            {
                truck = DAO.getTruckWithModel(modelTextBox.Text);
                model = DAO.searchTruckByModel(modelTextBox.Text);

                truck.Colour = colorTextBox.Text;
                truck.RegistrationNumber = registrationNumberTextBox.Text;
                truck.RegistrationExpiryDate = registrationExpiryDateDatePicker.SelectedDate.Value.Date;
                truck.WofexpiryDate = wofexpiryDateDatePicker.SelectedDate.Value.Date;
                truck.DailyRentalPrice = decimal.Parse(dailyRentalPriceTextBox.Text);
                truck.AdvanceDepositRequired = decimal.Parse(advanceDepositRequiredTextBox.Text);
                model.Seats = int.Parse(seatsTextBox.Text);
                truck.Status = statusComboBox.Text;

                DAO.customTruckTable(truck, model);
                MessageBox.Show("Details updated successfully!");

                errorLabel.Visibility = Visibility.Hidden;
                hide(true);
            }
        }

        private void hide(bool hide)
        {
            if (hide == true)
            {
                colorTextBox.Visibility = Visibility.Hidden;
                registrationNumberTextBox.Visibility = Visibility.Hidden;
                wofexpiryDateDatePicker.Visibility = Visibility.Hidden;
                registrationExpiryDateDatePicker.Visibility = Visibility.Hidden;
                dailyRentalPriceTextBox.Visibility = Visibility.Hidden;
                advanceDepositRequiredTextBox.Visibility = Visibility.Hidden;
                seatsTextBox.Visibility = Visibility.Hidden;
                statusComboBox.Visibility = Visibility.Hidden;
            }
            else
            {
                colorTextBox.Visibility = Visibility.Visible;
                registrationNumberTextBox.Visibility = Visibility.Visible;
                wofexpiryDateDatePicker.Visibility = Visibility.Visible;
                registrationExpiryDateDatePicker.Visibility = Visibility.Visible;
                dailyRentalPriceTextBox.Visibility = Visibility.Visible;
                advanceDepositRequiredTextBox.Visibility = Visibility.Visible;
                seatsTextBox.Visibility = Visibility.Visible;
                statusComboBox.Visibility = Visibility.Visible;
            }
        }
    }
}
