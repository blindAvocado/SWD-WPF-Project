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
using System.Windows;
using System.Windows.Controls;

namespace SWD_WPF_Project.ViewModels
{
    public class OrdersViewModel : ViewModelBase
    {
        private readonly OrderService _orderService = new OrderService();
        private readonly PeopleService _clientService = new PeopleService();
        private readonly CargoService _cargoService = new CargoService();
        private readonly PeopleService _peopleService = new PeopleService();

        private Visibility _fade;

        public ObservableCollection<OrderModel> AllOrders { get; set; }
        public ObservableCollection<OrderModel> ReadyOrders { get; set; }
        public ObservableCollection<OrderModel> WaitingOrders { get; set; }
        public ObservableCollection<OrderModel> CurrentCollection { get; set; }
        public ObservableCollection<ClientModel> AllClients { get; set; }

        public OrderModel SelectedOrder { get; set; }
        public Visibility Fade
        {
            get { return _fade; }
            set
            {
                _fade = value;
                OnPropertyChanged(nameof(Fade));
            }
        }
        
        private void SetAllOrderProperties(ObservableCollection<OrderModel> Orders)
        {
            foreach (var order in Orders)
            {
                order.Client = _clientService.GetClientModelByID(order.Client.ID);
                order.StatusName = _orderService.GetStatusNameByID(order.StatusID);
                order.StatusBGBrush = _orderService.GetOrderStatusBGColor(order.StatusID);
                order.Pickup.DistrictName = _orderService.GetDistrictNameByID(order.Pickup.DistrictID);
                order.Delivery.DistrictName = _orderService.GetDistrictNameByID(order.Delivery.DistrictID);
                order.CourierName = _peopleService.GetCourierNameById(order.Courier);
                order.Cargo = _cargoService.GetAllCargoForOrder(order.ID);

                if (order.Cargo.Count != 0)
                {
                    foreach (var cargo in order.Cargo)
                    {
                        cargo.CargoType.Name = _cargoService.GetCargoTypeNameByID(cargo.CargoType.ID);
                    }
                }
            }
        }

        private void SetAllOrders()
        {
            AllOrders = new ObservableCollection<OrderModel>(_orderService.GetAllOrders());

            SetAllOrderProperties(AllOrders);

            OnPropertyChanged(nameof(AllOrders));
        }

        private void SetReadyOrders()
        {
            ReadyOrders = new ObservableCollection<OrderModel>(_orderService.GetReadyOrders());

            SetAllOrderProperties(ReadyOrders);

            OnPropertyChanged(nameof(ReadyOrders));
        }

        private void SetWaitingOrders()
        {
            WaitingOrders = new ObservableCollection<OrderModel>(_orderService.GetWaitingOrders());

            SetAllOrderProperties(WaitingOrders);

            OnPropertyChanged(nameof(WaitingOrders));
        }

        private void SetAllClients()
        {
            AllClients = new ObservableCollection<ClientModel>(_clientService.GetAllClients());
            OnPropertyChanged(nameof(AllClients));
        }

        private void SetAllTables()
        {
            SetAllOrders();
            SetReadyOrders();
            SetWaitingOrders();
        }

        public ICommand ShowAllOrders { get; }
        public ICommand ShowReadyOrders { get; }
        public ICommand ShowWaitingOrders { get; }
        public ICommand ShowCreateOrderDialog { get; }
        public ICommand ShowEditOrderDialog { get; }
        public ICommand DeleteOrder { get; }

        public OrdersViewModel()
        {
            AllOrders = new ObservableCollection<OrderModel>();
            ReadyOrders = new ObservableCollection<OrderModel>();
            WaitingOrders = new ObservableCollection<OrderModel>();
            AllClients = new ObservableCollection<ClientModel>();

            ShowAllOrders = new ViewModelCommand(ExecuteShowAllOrdersCommand);
            ShowReadyOrders = new ViewModelCommand(ExecuteShowReadyOrdersCommand);
            ShowWaitingOrders = new ViewModelCommand(ExecuteShowWaitingOrdersCommand);

            SetAllTables();
            SetAllClients();

            Fade = Visibility.Collapsed;
            ExecuteShowAllOrdersCommand(null);

            ShowCreateOrderDialog = new ViewModelCommand(ExecuteShowCreateOrderDialogCommand);
            ShowEditOrderDialog = new ViewModelCommand(ExecuteShowEditOrderDialogCommand);
            DeleteOrder = new ViewModelCommand(ExecuteDeleteOrderCommand);
        }

        private void ExecuteDeleteOrderCommand(object obj)
        {

            _orderService.DeleteOrderCargo(SelectedOrder.ID);
            _orderService.DeleteOrder(SelectedOrder);

            SetAllTables();
            ExecuteShowAllOrdersCommand(null);
        }

        private void ExecuteShowEditOrderDialogCommand(object obj)
        {
            Fade = Visibility.Visible;
            var dialog = new OrderFormView(SelectedOrder);
            dialog.ShowDialog();
            Fade = Visibility.Collapsed;

            SetAllTables();
            ExecuteShowAllOrdersCommand(null);
        }

        private void ExecuteShowCreateOrderDialogCommand(object obj)
        {
            Fade = Visibility.Visible;
            var dialog = new OrderFormView();
            dialog.ShowDialog();
            Fade = Visibility.Collapsed;

            SetAllTables();
            ExecuteShowAllOrdersCommand(null);
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
