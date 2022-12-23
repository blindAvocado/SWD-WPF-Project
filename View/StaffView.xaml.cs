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

namespace SWD_WPF_Project.View
{
    /// <summary>
    /// Interaction logic for StaffView.xaml
    /// </summary>
    public partial class StaffView : UserControl
    {
        public StaffView()
        {
            InitializeComponent();
        }

        private void clientsTab_Click(object sender, RoutedEventArgs e)
        {
            clientsDataGrid.Visibility = Visibility.Visible;
            courierDataGrid.Visibility = Visibility.Collapsed;
            
            buttonCreateClient.Visibility = Visibility.Visible;
            buttonCreateCourier.Visibility = Visibility.Collapsed;
        }

        private void couriersTab_Click(object sender, RoutedEventArgs e)
        {
            clientsDataGrid.Visibility = Visibility.Collapsed;
            courierDataGrid.Visibility = Visibility.Visible;

            buttonCreateClient.Visibility = Visibility.Collapsed;
            buttonCreateCourier.Visibility = Visibility.Visible;
        }

        private void buttonCreateClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonCreateCourier_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
