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
    /// Interaction logic for viewTrucksUC.xaml
    /// </summary>
    public partial class viewTrucksUC : UserControl
    {
        public viewTrucksUC()
        {
            InitializeComponent();

            grid.ItemsSource = DAO.GetIndividualTrucks();
        }

        private void avaliableButton_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = DAO.GetIndividualTrucks();
        }
    }
}