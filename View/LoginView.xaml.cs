using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SWD_WPF_Project.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void placeholderEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textEmail.Focus();
        }

        private void textEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textEmail.Text) && textEmail.Text.Length > 0)
                placeholderEmail.Visibility = Visibility.Collapsed;
            else
                placeholderEmail.Visibility = Visibility.Visible;

        }

        private void placeholderPass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textPass.Focus();
        }

        private void textPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textPass.Password) && textPass.Password.Length > 0)
                placeholderPass.Visibility = Visibility.Collapsed;
            else
                placeholderPass.Visibility = Visibility.Visible;
        }

        private void buttonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
