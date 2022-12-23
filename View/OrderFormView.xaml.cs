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
using SWD_WPF_Project.ViewModels;
using SWD_WPF_Project.Models;

namespace SWD_WPF_Project.View
{
    /// <summary>
    /// Interaction logic for OrderFormView.xaml
    /// </summary>
    public partial class OrderFormView : Window
    {
        public OrderFormView()
        {
            InitializeComponent();
        }

        public OrderFormView(OrderModel order)
        {
            InitializeComponent();
            var context = new OrderFormViewModel(order);
            DataContext = context;
            windowTitle.Text = "Изменить заказ";
            buttonSubmitForm.Content = "Изменить";
            buttonSubmitForm.Command = (ICommand)context.GetType().GetProperty("EditOrder").GetValue(context);
            technicalInfoSection.Visibility = Visibility.Visible;
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
