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
    /// Interaction logic for displayTruckDetails.xaml
    /// </summary>
    public partial class displayTruckDetailsUC : UserControl
    {
        public displayTruckDetailsUC()
        {
            InitializeComponent();
            grid.ItemsSource = DAO.GetTruckDetails();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            string truckmodel = modelTextBox.Text;

            TruckModel tm = DAO.searchTruckByModel(truckmodel);
            if (tm == null)
            {
                MessageBox.Show("No record found");
                grid.ItemsSource = null;
            }
            else
            {
                MessageBox.Show("record found");

                grid.ItemsSource = DAO.GetTruckDetails(truckmodel);
            }
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = grid.SelectedItem as TruckDetailsDisplay;


            if (t != null)
            {
                var truck = DAO.GetTruckByID(t.TruckId);
                if (truck != null)
                {
                    var features = DAO.getTruckFeatures(truck.TruckId);
                    if (features.Count == 0)
                    {
                        errorLabel.Content = "This Truck Doesn't have any features";
                        truckfeatureListBox.ItemsSource = DAO.getTruckFeatures(truck.TruckId);
                    }
                    else
                    {
                        errorLabel.Content = "";
                        truckfeatureListBox.ItemsSource = DAO.getTruckFeatures(truck.TruckId);
                    }
                }
            }
            else
                truckfeatureListBox.ItemsSource = null;
        }
    }
}
