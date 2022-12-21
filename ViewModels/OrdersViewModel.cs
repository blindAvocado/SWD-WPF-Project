using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using SWD_WPF_Project.Models;
using SWD_WPF_Project.Services;
using SWD_WPF_Project.View;

namespace SWD_WPF_Project.ViewModels
{
    public class OrdersViewModel : ViewModelBase
    {
        private readonly OrderService _orderService = new OrderService();
        private readonly ClientService _clientService = new ClientService();

        public ObservableCollection<OrderModel> AllOrders { get; set; }
        public ObservableCollection<OrderModel> ReadyOrders { get; set; }
        public ObservableCollection<OrderModel> WaitingOrders { get; set; }
        public ObservableCollection<OrderModel> CurrentCollection { get; set; }
        public ObservableCollection<ClientModel> AllClients { get; set; }
        
        public int ClientID { get; set; }

        private void SetAllOrders()
        {
            AllOrders = new ObservableCollection<OrderModel>(_orderService.GetAllOrders());

            foreach (var order in AllOrders)
            {
                order.ClientName = _clientService.GetClientNameByID(order.ClientID);
                order.StatusName = _orderService.GetStatusNameByID(order.StatusID);
            }

            OnPropertyChanged(nameof(AllOrders));
        }

        private void SetReadyOrders()
        {
            ReadyOrders = new ObservableCollection<OrderModel>(_orderService.GetReadyOrders());

            foreach (var order in ReadyOrders)
            {
                order.ClientName = _clientService.GetClientNameByID(order.ClientID);
                order.StatusName = _orderService.GetStatusNameByID(order.StatusID);
            }

            OnPropertyChanged(nameof(ReadyOrders));
        }

        private void SetWaitingOrders()
        {
            WaitingOrders = new ObservableCollection<OrderModel>(_orderService.GetWaitingOrders());

            foreach (var order in WaitingOrders)
            {
                order.ClientName = _clientService.GetClientNameByID(order.ClientID);
                order.StatusName = _orderService.GetStatusNameByID(order.StatusID);
            }

            OnPropertyChanged(nameof(WaitingOrders));
        }

        private void SetAllClients()
        {
            AllClients = new ObservableCollection<ClientModel>(_clientService.GetAllClients());
            OnPropertyChanged(nameof(AllClients));
        }

        public ICommand ShowAllOrders { get; }
        public ICommand ShowReadyOrders { get; }
        public ICommand ShowWaitingOrders { get; }
        public ICommand ShowCreateOrderDialog { get; }

        public OrdersViewModel()
        {
            AllOrders = new ObservableCollection<OrderModel>();
            ReadyOrders = new ObservableCollection<OrderModel>();
            WaitingOrders = new ObservableCollection<OrderModel>();
            AllClients = new ObservableCollection<ClientModel>();

            ShowAllOrders = new ViewModelCommand(ExecuteShowAllOrdersCommand);
            ShowReadyOrders = new ViewModelCommand(ExecuteShowReadyOrdersCommand);
            ShowWaitingOrders = new ViewModelCommand(ExecuteShowWaitingOrdersCommand);

            SetAllOrders();
            SetReadyOrders();
            SetWaitingOrders();
            SetAllClients();

            ExecuteShowAllOrdersCommand(null);

            ShowCreateOrderDialog = new ViewModelCommand(ExecuteShowCreateOrderDialogCommand);
        }

        private void ExecuteShowCreateOrderDialogCommand(object obj)
        {
            var dialog = new OrderFormView();
            dialog.ShowDialog();
        }

        private void ExecuteShowWaitingOrdersCommand(object obj)
        {
            CurrentCollection = WaitingOrders;
            OnPropertyChanged(nameof(CurrentCollection));
        }

        private void ExecuteShowReadyOrdersCommand(object obj)
        {
            CurrentCollection = ReadyOrders;
            OnPropertyChanged(nameof(CurrentCollection));
        }

        private void ExecuteShowAllOrdersCommand(object obj)
        {
            CurrentCollection = AllOrders;
            OnPropertyChanged(nameof(CurrentCollection));
        }
    }
}
