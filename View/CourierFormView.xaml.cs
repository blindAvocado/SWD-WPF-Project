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
using System.Runtime.InteropServices;
using System.Windows.Interop;
using SWD_WPF_Project.ViewModels;
using SWD_WPF_Project.Models;

namespace SWD_WPF_Project.View
{
    /// <summary>
    /// Interaction logic for CourierFormView.xaml
    /// </summary>
    public partial class CourierFormView : Window
    {
        public CourierFormView()
        {
            InitializeComponent();
        }

        public CourierFormView(CourierModel courier)
        {
            InitializeComponent();
            var context = new CourierFormViewModel(courier);
            DataContext = context;
            windowTitle.Text = "Изменить курьера";
            buttonSubmitForm.Content = "Изменить";
            buttonSubmitForm.Command = (ICommand)context.GetType().GetProperty("EditCourier").GetValue(context);
        }

        private void windowControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void buttonSubmitForm_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void buttonCloseWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DialogResult = false;
        }
    }
}
