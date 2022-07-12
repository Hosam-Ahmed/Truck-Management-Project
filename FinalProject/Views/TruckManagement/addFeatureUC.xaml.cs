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
using Microsoft.EntityFrameworkCore;
using FinalProject.Models.DB;
using FinalProject.Models;

namespace Project.Views.TruckManagement
{
    /// <summary>
    /// Interaction logic for addFeatureUC.xaml
    /// </summary>
    public partial class addFeatureUC : UserControl
    {
        public addFeatureUC()
        {
            InitializeComponent();
            featureListBox.ItemsSource = DAO.getExistingTruckFeature();
            truckIdComboBox.ItemsSource = DAO.GetTrucks();
            truckIdComboBox.DisplayMemberPath = "RegistrationNumber";
            truckIdComboBox.SelectedValuePath = "RegistrationNumber";
        }

        private void addFeatureButton_Click(object sender, RoutedEventArgs e)
        {
            IndividualTruck truck = DAO.getTruckByRegistartionNumber(truckIdComboBox.Text);
            TruckFeatureAssociation tfa = new TruckFeatureAssociation();

            if (truck != null)
            {
                var feature = featureListBox.SelectedItem as TruckFeature;
                tfa.TruckId = truck.TruckId;
                tfa.FeatureId = feature.FeatureId;

                List <TruckFeatureAssociation> getFeatures = DAO.getTruckFeatures(truck.TruckId);

                bool pass = false;
                int count = 0;

                foreach (var feat in getFeatures)
                {
                    if (tfa.FeatureId == feat.FeatureId)
                    {
                        errorLabel.Content = "Feature Already Exists";
                        count++;
                    }
                    else
                        pass = true;
                }

                if (pass == true & count == 0)
                {
                    DAO.addTruckFeatures(tfa);
                    MessageBox.Show("Feature added to truck successfully");
                    truckfeatureListBox.ItemsSource = DAO.getTruckFeatures(truck.TruckId);
                }
            }
            else
                MessageBox.Show("OOPS Something went wrong");
        }

        private void selectButton_Click_1(object sender, RoutedEventArgs e)
        {
            IndividualTruck truck = DAO.getTruckByRegistartionNumber(truckIdComboBox.Text);
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
                    errorLabel.Content = "Feature Exists";
                    truckfeatureListBox.ItemsSource = DAO.getTruckFeatures(truck.TruckId);
                }
            }
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            IndividualTruck truck = DAO.getTruckByRegistartionNumber(truckIdComboBox.Text);
            TruckFeatureAssociation tfa = new TruckFeatureAssociation();

            if (truck != null)
            {
                var feature = truckfeatureListBox.SelectedItem as TruckFeatureAssociation;
                tfa.TruckId = truck.TruckId;
                tfa.FeatureId = feature.FeatureId;

                DAO.deleteExistingFeature(tfa);
                MessageBox.Show("Feature updated successfully");
                truckfeatureListBox.ItemsSource = DAO.getTruckFeatures(truck.TruckId);
            }
            else
                MessageBox.Show("OOPS Something went wrong");

        }
    }
}

