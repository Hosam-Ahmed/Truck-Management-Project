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

namespace Project.Views.RentalManagement
{
    /// <summary>
    /// Interaction logic for searchRentedUC.xaml
    /// </summary>
    public partial class viewRentedUC : UserControl
    {
        public viewRentedUC()
        {
            InitializeComponent();
            Load();

            errorLabel.Visibility = Visibility.Hidden;
        }

        private void Load()
        {
            grid.ItemsSource = DAO.viewRented();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (fromDateDatePicker.SelectedDate == null && toDateDatePicker.SelectedDate == null)
            {
                errorLabel.Visibility = Visibility.Visible;
                fromDateDatePicker.BorderBrush = Brushes.Red;
                toDateDatePicker.BorderBrush = Brushes.Red;
            }
            else if (fromDateDatePicker.SelectedDate == null)
            {
                fromDateDatePicker.BorderBrush = Brushes.Red;
                errorLabel.Visibility = Visibility.Visible;
            }
            else if (toDateDatePicker.SelectedDate == null)
            {
                toDateDatePicker.BorderBrush = Brushes.Red;
                errorLabel.Visibility = Visibility.Visible;
            }
            else if (toDateDatePicker.SelectedDate != null && toDateDatePicker.SelectedDate != null)
            {
                errorLabel.Visibility = Visibility.Hidden;
                fromDateDatePicker.BorderBrush = Brushes.Black;
                toDateDatePicker.BorderBrush = Brushes.Black;

                DateTime fromDate = fromDateDatePicker.SelectedDate.Value.Date;
                DateTime toDate = toDateDatePicker.SelectedDate.Value.Date;

                grid.ItemsSource = DAO.searchRentedByDate(fromDate, toDate);
            }
            else
            {
                errorLabel.Visibility = Visibility.Hidden;
                fromDateDatePicker.BorderBrush = Brushes.Black;
                toDateDatePicker.BorderBrush = Brushes.Black;
            }
        }
    }
}