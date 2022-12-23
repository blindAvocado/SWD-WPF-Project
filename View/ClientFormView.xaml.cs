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
    /// Interaction logic for ClientFormView.xaml
    /// </summary>
    public partial class ClientFormView : Window
    {
        public ClientFormView()
        {
            InitializeComponent();
        }

        public ClientFormView(ClientModel client)
        {
            InitializeComponent();
            var context = new ClientFormViewModel(client);
            DataContext = context;
            windowTitle.Text = "Изменить клиента";
            buttonSubmitForm.Content = "Изменить";
            buttonSubmitForm.Command = (ICommand)context.GetType().GetProperty("EditClient").GetValue(context);
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
