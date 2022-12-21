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

namespace SWD_WPF_Project.View
{
    /// <summary>
    /// Interaction logic for OrderCreateEditView.xaml
    /// </summary>
    public partial class OrderCreateEditView : Window
    {
        public OrderCreateEditView()
        {
            InitializeComponent();
        }

        private void windowControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void buttonCloseWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DialogResult = false;
        }

        private void buttonSubmitForm_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
