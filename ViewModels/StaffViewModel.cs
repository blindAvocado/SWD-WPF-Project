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
    public class StaffViewModel : ViewModelBase
    {
        private readonly PeopleService _peopleService = new PeopleService();
        private readonly OrderService _orderService = new OrderService();
        private readonly CargoService _cargoService = new CargoService();
        public ObservableCollection<ClientModel> AllClients { get; set; }
        public ObservableCollection<CourierModel> AllCouriers { get; set; }

        public ClientModel SelectedClient { get; set; }
        public CourierModel SelectedCourier { get; set; }

        public ICommand ShowAllClients { get; }
        public ICommand ShowAllCouriers { get; }
        public ICommand ShowCreateClientDialog { get; }
        public ICommand ShowCreateCourierDialog { get; }
        public ICommand ShowEditClientDialog { get; }
        public ICommand ShowEditCourierDialog { get; }
        public ICommand DeleteClient { get; }
        public ICommand DeleteCourier { get; }

        private Visibility _fade;
        private Visibility _clientsDataGridVisibility;
        private Visibility _couriersDataGridVisibility;
        private Visibility _clientsButtonVisibility;
        private Visibility _couriersButtonVisibility;

        public Visibility Fade
        {
            get { return _fade; }
            set
            {
                _fade = value;
                OnPropertyChanged(nameof(Fade));
            }
        }

        public Visibility ClientsDataGridVisibility
        {
            get { return _clientsDataGridVisibility; }
            set
            {
                _clientsDataGridVisibility = value;
                OnPropertyChanged(nameof(ClientsDataGridVisibility));
            }
        }

        public Visibility CouriersDataGridVisibility
        {
            get { return _couriersDataGridVisibility; }
            set
            {
                _couriersDataGridVisibility = value;
                OnPropertyChanged(nameof(CouriersDataGridVisibility));
            }
        }

        public Visibility ClientsButtonVisibility
        {
            get { return _clientsButtonVisibility; }
            set
            {
                _clientsButtonVisibility = value;
                OnPropertyChanged(nameof(ClientsButtonVisibility));
            }
        }

        public Visibility CouriersButtonVisibility
        {
            get { return _couriersButtonVisibility; }
            set
            {
                _couriersButtonVisibility = value;
                OnPropertyChanged(nameof(CouriersButtonVisibility));
            }
        }


        private void SetAllClients()
        {
            AllClients = new ObservableCollection<ClientModel>(_peopleService.GetAllClients());

            foreach (var client in AllClients)
            {
                client.BG = _peopleService.GetRandomBGColor();
            }

            OnPropertyChanged(nameof(AllClients));
        }

        private void SetAllCouriers()
        {
            AllCouriers = new ObservableCollection<CourierModel>(_peopleService.GetAllCouriers());

            foreach (var courier in AllCouriers)
            {
                courier.BG = _peopleService.GetRandomBGColor();
            }

            OnPropertyChanged(nameof(AllCouriers));
        }

        public StaffViewModel()
        {
            SetAllClients();
            SetAllCouriers();

            ShowAllClients = new ViewModelCommand(ExecuteShowAllClientsCommand);
            ShowAllCouriers = new ViewModelCommand(ExecuteShowAllCouriersCommand);
            ShowCreateClientDialog = new ViewModelCommand(ExecuteShowCreateClientDialogCommand);
            ShowCreateCourierDialog = new ViewModelCommand(ExecuteShowCreateCourierDialogCommand);
            ShowEditClientDialog = new ViewModelCommand(ExecuteShowEditClientDialogCommand);
            ShowEditCourierDialog = new ViewModelCommand(ExecuteShowEditCourierDialogCommand);
            DeleteClient = new ViewModelCommand(ExecuteDeleteClientCommand);
            DeleteCourier = new ViewModelCommand(ExecuteDeleteCourierCommand);

            Fade = Visibility.Collapsed;
            ClientsDataGridVisibility = Visibility.Visible;
            ClientsButtonVisibility = Visibility.Visible;
            CouriersDataGridVisibility = Visibility.Collapsed;
            CouriersButtonVisibility = Visibility.Collapsed;

            ExecuteShowAllClientsCommand(null);

        }

        private void ExecuteDeleteCourierCommand(object obj)
        {
            //найти все заказы и обнулить
            //удалить курьера

            var orderList = _orderService.GetAllOrdersByCourierID(SelectedCourier.ID);
            foreach (var order in orderList)
            {
                order.Courier = null;
                _orderService.EditOrder(order);
            }

            _peopleService.DeleteCourier(SelectedCourier);

            SetAllCouriers();
            ExecuteShowAllCouriersCommand(null);
        }

        private void ExecuteDeleteClientCommand(object obj)
        {
            //найти все заказы
            //найти все товары и удалить
            //удалить заказы
            //удалить клиента

            var orderList = _orderService.GetAllOrdersByClientID(SelectedClient.ID);
            foreach (var order in orderList)
            {
                var cargoList = _cargoService.GetAllCargoForOrder(order.ID);
                foreach (var cargo in cargoList)
                {
                    _cargoService.DeleteCargo(cargo);
                }

                _orderService.DeleteOrder(order);
            }

            _peopleService.DeleteClient(SelectedClient);

            SetAllClients();
            ExecuteShowAllClientsCommand(null);
        }

        private void ExecuteShowEditCourierDialogCommand(object obj)
        {
            Fade = Visibility.Visible;

            var dialog = new CourierFormView(SelectedCourier);
            dialog.ShowDialog();

            Fade = Visibility.Collapsed;

            SetAllCouriers();
            ExecuteShowAllCouriersCommand(null);
        }

        private void ExecuteShowEditClientDialogCommand(object obj)
        {
            Fade = Visibility.Visible;

            var dialog = new ClientFormView(SelectedClient);
            dialog.ShowDialog();

            Fade = Visibility.Collapsed;

            SetAllClients();
            ExecuteShowAllClientsCommand(null);
        }

        private void ExecuteShowCreateCourierDialogCommand(object obj)
        {
            Fade = Visibility.Visible;

            var dialog = new CourierFormView();
            dialog.ShowDialog();

            Fade = Visibility.Collapsed;

            SetAllCouriers();
            ExecuteShowAllCouriersCommand(null);
        }

        private void ExecuteShowCreateClientDialogCommand(object obj)
        {
            Fade = Visibility.Visible;

            var dialog = new ClientFormView();
            dialog.ShowDialog();

            Fade = Visibility.Collapsed;

            SetAllClients();
            ExecuteShowAllClientsCommand(null);
        }

        private void ExecuteShowAllClientsCommand(object obj)
        {
            ClientsDataGridVisibility = Visibility.Visible;
            ClientsButtonVisibility = Visibility.Visible;
            CouriersDataGridVisibility = Visibility.Collapsed;
            CouriersButtonVisibility = Visibility.Collapsed;
        }

        private void ExecuteShowAllCouriersCommand(object obj)
        {
            ClientsDataGridVisibility = Visibility.Collapsed;
            ClientsButtonVisibility = Visibility.Collapsed;
            CouriersDataGridVisibility = Visibility.Visible;
            CouriersButtonVisibility = Visibility.Visible;
        }
    }
}
