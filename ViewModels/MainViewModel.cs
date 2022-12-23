using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SWD_WPF_Project.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;
        private string _headerTitle;

        public ViewModelBase CurrentChildView
        {
            get { return _currentChildView; }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string HeaderTitle
        {
            get { return _headerTitle; }
            set
            {
                _headerTitle = value;
                OnPropertyChanged(nameof(HeaderTitle));
            }
        }

        public ICommand ShowOrdersViewCommand { get; }
        public ICommand ShowReportsViewCommand { get; }
        public ICommand ShowStaffViewCommand { get; }

        public MainViewModel()
        {
            ShowOrdersViewCommand = new ViewModelCommand(ExecuteShowOrdersViewCommand);
            ShowReportsViewCommand = new ViewModelCommand(ExecuteShowReportsViewCommand);
            ShowStaffViewCommand = new ViewModelCommand(ExecuteShowStaffViewCommand);

            ExecuteShowOrdersViewCommand(null);
        }

        private void ExecuteShowStaffViewCommand(object obj)
        {
            CurrentChildView = new StaffViewModel();
            HeaderTitle = "Люди";
        }

        private void ExecuteShowReportsViewCommand(object obj)
        {
            CurrentChildView = new ReportsViewModel();
            HeaderTitle = "Отчеты";
        }

        private void ExecuteShowOrdersViewCommand(object obj)
        {
            CurrentChildView = new OrdersViewModel();
            HeaderTitle = "Заказы";
        }
    }

}
