﻿using SWD_WPF_Project.Models;
using SWD_WPF_Project.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SWD_WPF_Project.ViewModels
{
    public class OrderFormViewModel : ViewModelBase
    {
        private readonly ClientService _clientService = new ClientService();
        private readonly OrderService _orderService = new OrderService();
        private readonly DistrictService _districtService = new DistrictService();
        private readonly CargoService _cargoService = new CargoService();

        public ObservableCollection<ClientModel> AllClients { get; set; }
        public ObservableCollection<DistrictModel> AllDistricts { get; set; }
        public ObservableCollection<CargoTypeModel> AllCargoTypes { get; set; }

        public ObservableCollection<OrderContentModel> CargoList { get; set; }
        public ClientModel SelectedClient { get; set; }
        public DistrictModel SelectedDistrict { get; set; }
        public OrderModel SelectedOrder { get; set; }

        private void SetAllClients()
        {
            AllClients = new ObservableCollection<ClientModel>(_clientService.GetAllClients());
            OnPropertyChanged(nameof(AllClients));
        }

        private void SetAllDistricts()
        {
            AllDistricts = new ObservableCollection<DistrictModel>(_districtService.GetAllDistricts());
            OnPropertyChanged(nameof(AllDistricts));
        }

        private void SetAllCargoTypes()
        {
            AllCargoTypes = new ObservableCollection<CargoTypeModel>(_cargoService.GetAllCargoTypes());
            OnPropertyChanged(nameof(AllCargoTypes));
        }

        public ICommand CreateNewCargoItem { get; }

        public OrderFormViewModel()
        {
            AllClients = new ObservableCollection<ClientModel>();
            AllDistricts = new ObservableCollection<DistrictModel>();
            AllCargoTypes = new ObservableCollection<CargoTypeModel>();
            CargoList = new ObservableCollection<OrderContentModel>();

            SelectedOrder = new OrderModel();

            SetAllClients();
            SetAllDistricts();
            SetAllCargoTypes();

            CreateNewCargoItem = new ViewModelCommand(ExecuteCreateNewCargoItemCommand);
        }

        public OrderFormViewModel(OrderModel order)
        {
            AllClients = new ObservableCollection<ClientModel>();
            AllDistricts = new ObservableCollection<DistrictModel>();
            AllCargoTypes = new ObservableCollection<CargoTypeModel>();

            SelectedOrder = order;

            SetAllClients();
            SetAllDistricts();

            CreateNewCargoItem = new ViewModelCommand(ExecuteCreateNewCargoItemCommand);
        }

        private void ExecuteCreateNewCargoItemCommand(object obj)
        {
            CargoList.Add(new OrderContentModel());
            OnPropertyChanged(nameof(CargoList));
        }
    }
}
