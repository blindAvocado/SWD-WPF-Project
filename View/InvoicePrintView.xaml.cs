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
    /// Interaction logic for InvoicePrintView.xaml
    /// </summary>
    public partial class InvoicePrintView : Window
    {
        public InvoicePrintView(object order)
        {
            InitializeComponent();
            DataContext = order;
            
        }

        public void PrintInvoice()
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(this, "Договор");
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            PrintInvoice();
            //this.Close();
        }
    }
}
