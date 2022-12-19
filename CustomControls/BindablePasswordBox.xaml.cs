using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

namespace SWD_WPF_Project.CustomControls
{
    /// <summary>
    /// Interaction logic for BindablePasswordBox.xaml
    /// </summary>
    public partial class BindablePasswordBox : UserControl
    {
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(SecureString), typeof(BindablePasswordBox));

        public SecureString Password
        {
            get { return (SecureString)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public BindablePasswordBox()
        {
            InitializeComponent();
            textPass.PasswordChanged += OnPasswordChanged;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = textPass.SecurePassword;
        }

        private void placeholderPass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textPass.Focus();
        }

        //private void textPass_PasswordChanged(object sender, RoutedEventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(textPass.Password) && textPass.Password.Length > 0)
        //        placeholderPass.Visibility = Visibility.Collapsed;
        //    else
        //        placeholderPass.Visibility = Visibility.Visible;
        //}
    }
}
