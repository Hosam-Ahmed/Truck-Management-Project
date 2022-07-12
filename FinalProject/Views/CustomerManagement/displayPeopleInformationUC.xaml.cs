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

namespace Project.Views.CustomerManagement
{
    /// <summary>
    /// Interaction logic for displayPeopleInformationUC.xaml
    /// </summary>
    public partial class displayPeopleInformationUC : UserControl
    {
        public displayPeopleInformationUC()
        {
            InitializeComponent();
            searchCustomerButton.Visibility = Visibility.Hidden;
            idComboBox.ItemsSource = DAO.GetPersonID();
            idComboBox.DisplayMemberPath = "PersonId";
            idComboBox.SelectedValuePath = "PersonId";
            errorLabel.Visibility = Visibility.Hidden;
            customerDataGrid.Visibility = Visibility.Hidden;
        }

        private void showAllCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            customerDataGrid.Visibility = Visibility.Visible;
            customerDataGrid.ItemsSource = DAO.getPeople();
        }

        private void searchCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if (idComboBox.SelectedIndex == -1)
            {
                idComboBox.BorderBrush = Brushes.Red;
                errorLabel.Visibility = Visibility.Visible;
            }
            else
            {
                int id = int.Parse(idComboBox.Text);
                idComboBox.BorderBrush = Brushes.Black;
                customerDataGrid.Visibility = Visibility.Visible;
                customerDataGrid.ItemsSource = DAO.getPeople(id);
                errorLabel.Visibility = Visibility.Hidden;
            }
        }

        private void ClearFilledComboBox_Click(object sender, RoutedEventArgs e)
        {
            idComboBox.SelectedIndex = -1;
        }

        private void FilledComboBoxEnabledCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            searchCustomerButton.Visibility = Visibility.Visible;
        }
    }
}
