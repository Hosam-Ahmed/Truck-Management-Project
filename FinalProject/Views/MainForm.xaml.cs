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
using Project.Views.RentalManagement;
using FinalProject.Models;
using FinalProject.Models.DB;
using Project.Views.CustomerManagement;
using Project.Views.TruckManagement;
using FinalProject.Views.RentalManagement;

namespace FinalProject.Views
{
    /// <summary>
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        EmployeeDetails ed = new EmployeeDetails();

        public MainForm()
        {
            InitializeComponent();
            ed = DAO.fetchPersonalInfo().FirstOrDefault();

            greetingLabel.Content = (" Kia  Ora  ,  " + ed.Name + " \n" + "Welcome   to   the   NZ   Truck   Rentals ");

            if (ed.Role == "Admin")
            {
                addEmployee.IsEnabled = true;
                addTruck.IsEnabled = true;
            }
            else
            {
                addEmployee.IsEnabled = false;
                addTruck.IsEnabled= false;
            }

        }

        private void addEmployee_Click(object sender, RoutedEventArgs e)
        {
            mainControl.Children.Clear();
            mainControl.Children.Add(new addEmployeeUC());
        }

        private void searchEmployee_Click(object sender, RoutedEventArgs e)
        {
            mainControl.Children.Clear();
            mainControl.Children.Add(new viewAndUpdateEmployeeDetailsUC());
        }

        private void viewEmployee_Click(object sender, RoutedEventArgs e)
        {
            mainControl.Children.Clear();
            mainControl.Children.Add(new viewPersonalDetailsUC());
        }

        private void updateEmployee_Click(object sender, RoutedEventArgs e)
        {
            mainControl.Children.Clear();
            mainControl.Children.Add(new viewAndUpdateEmployeeDetailsUC());
        }

        private void addCustomer_Click(object sender, RoutedEventArgs e)
        {
            mainControl.Children.Clear();
            mainControl.Children.Add(new addCustomerUC());
        }

        private void searchCustomer_Click(object sender, RoutedEventArgs e)
        {
            mainControl.Children.Clear();
            mainControl.Children.Add(new displayPeopleInformationUC());
        }

        private void viewCustomer_Click(object sender, RoutedEventArgs e)
        {
            mainControl.Children.Clear();
            mainControl.Children.Add(new viewAndUpdateCustomerInformationUC());
        }

        private void updateCustomer_Click(object sender, RoutedEventArgs e)
        {
            mainControl.Children.Clear();
            mainControl.Children.Add(new viewAndUpdateCustomerInformationUC());
        }

        private void addTruck_Click(object sender, RoutedEventArgs e)
        {
            mainControl.Children.Clear();
            mainControl.Children.Add(new addTruckUC());
        }

        private void addFeature_Click(object sender, RoutedEventArgs e)
        {
            mainControl.Children.Clear();
            mainControl.Children.Add(new addFeatureUC());
        }

        private void searchTruck_Click(object sender, RoutedEventArgs e)
        {
            mainControl.Children.Clear();
            mainControl.Children.Add(new displayTruckDetailsUC());
        }

        private void updateTruck_Click(object sender, RoutedEventArgs e)
        {
            mainControl.Children.Clear();
            mainControl.Children.Add(new updateTruckUC());
        }

        private void viewTruck_Click(object sender, RoutedEventArgs e)
        {
            mainControl.Children.Clear();
            mainControl.Children.Add(new viewTrucksUC());
        }

        private void rentTruck_Click(object sender, RoutedEventArgs e)
        {
            mainControl.Children.Clear();
            mainControl.Children.Add(new rentTruckUC());
        }

        private void searchRented_Click(object sender, RoutedEventArgs e)
        {
            mainControl.Children.Clear();
            mainControl.Children.Add(new searchRentedUC());
        }

        private void returnRented_Click(object sender, RoutedEventArgs e)
        {
            mainControl.Children.Clear();
            mainControl.Children.Add(new returnTruckUC());
        }

        private void viewRented_Click(object sender, RoutedEventArgs e)
        {
            mainControl.Children.Clear();
            mainControl.Children.Add(new viewRentedUC());
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }
    }
}
