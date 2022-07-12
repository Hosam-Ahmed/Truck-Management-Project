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
    /// Interaction logic for viewRentedUC.xaml
    /// </summary>
    public partial class searchRentedUC : UserControl
    {
        public searchRentedUC()
        {
            InitializeComponent();
            Load();
            customerIDcomboBox.ItemsSource = DAO.getCustomer();
            customerIDcomboBox.DisplayMemberPath = "CustomerId";
            customerIDcomboBox.SelectedValuePath = "CustomerId";

            errorLabel.Visibility = Visibility.Hidden;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (customerIDcomboBox.SelectedItem != null)
            {
                grid.ItemsSource = DAO.viewRentedCustomer(int.Parse(customerIDcomboBox.Text));

                errorLabel.Visibility = Visibility.Hidden;
                customerIDcomboBox.BorderBrush = Brushes.Black;
            }
            else
            {
                errorLabel.Visibility = Visibility.Visible;
                customerIDcomboBox.BorderBrush = Brushes.Red;
            }
        }

        private void Load()
        {
            grid.ItemsSource = DAO.viewRented();
        }
    }
}
