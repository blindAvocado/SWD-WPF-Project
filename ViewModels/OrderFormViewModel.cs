using SWD_WPF_Project.Models;
using SWD_WPF_Project.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SWD_WPF_Project.ViewModels
{
    public class OrderFormViewModel : ViewModelBase
    {
        private readonly PeopleService _peopleService = new PeopleService();
        private readonly OrderService _orderService = new OrderService();
        private readonly DistrictService _districtService = new DistrictService();
        private readonly CargoService _cargoService = new CargoService();

        private string _pickupPrice;
        private string _deliveryPrice;
        private string _insurancePrice;
        private string _weightPrice;
        private string _totalPrice;

        public ObservableCollection<ClientModel> AllClients { get; set; }
        public ObservableCollection<CourierModel> AllCouriers { get; set; }
        public ObservableCollection<DistrictModel> AllDistricts { get; set; }
        public ObservableCollection<CargoTypeModel> AllCargoTypes { get; set; }
        public ObservableCollection<OrderStatusModel> AllStatuses { get; set; }

        public OrderModel SelectedOrder { get; set; }
        public OrderContentModel SelectedCargo { get; set; }
        public ClientModel SelectedClient { get; set; }
        public int SelectedClientI { get; set; }
        public ObservableCollection<OrderContentModel> CargoList { get; set; }
        public ObservableCollection<OrderContentModel> CargoListToDelete { get; set; }

        public string PickupPrice
        {
            get { return _pickupPrice; }
            set
            {
                _pickupPrice = value;
                OnPropertyChanged(nameof(PickupPrice));
            }
        }

        public string DeliveryPrice
        {
            get { return _deliveryPrice; }
            set
            {
                _deliveryPrice = value;
                OnPropertyChanged(nameof(DeliveryPrice));
            }
        }
        public string InsurancePrice
        {
            get { return _insurancePrice; }
            set
            {
                _insurancePrice = value;
                OnPropertyChanged(nameof(InsurancePrice));
            }
        }

        public string WeightPrice
        {
            get { return _weightPrice; }
            set
            {
                _weightPrice = value;
                OnPropertyChanged(nameof(WeightPrice));
            }
        }

        public string TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                _totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public bool EditingExisting;

        private void SetAllClients()
        {
            AllClients = new ObservableCollection<ClientModel>(_peopleService.GetAllClients());
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

        private void SetAllStatuses()
        {
            AllStatuses = new ObservableCollection<OrderStatusModel>(_orderService.GetAllStatuses());
            OnPropertyChanged(nameof(AllStatuses));
        }

        private void SetAllCouriers()
        {
            AllCouriers = new ObservableCollection<CourierModel>(_peopleService.GetAllCouriers());
            OnPropertyChanged(nameof(AllCouriers));
        }

        private void SetAllCargo()
        {
            CargoList = new ObservableCollection<OrderContentModel>(_cargoService.GetAllCargoForOrder(SelectedOrder.ID));
            foreach (var cargo in CargoList)
            {
                _cargoService.SetCargoProperties(cargo);
                cargo.WidthStr = cargo.Width.ToString();
                cargo.LengthStr = cargo.Length.ToString();
                cargo.HeightStr = cargo.Height.ToString();
                cargo.WeightStr = cargo.Weight.ToString();
                cargo.PriceStr = cargo.Price.ToString();
                cargo.QuantityStr = cargo.Quantity.ToString();
            }
        }


        private void UpdateCargoProperties()
        {
            foreach (var cargo in CargoList)
            {
                if (cargo.WidthStr != null)
                    cargo.Width = Double.Parse(cargo.WidthStr, System.Globalization.NumberStyles.Float);

                if (cargo.LengthStr != null)
                    cargo.Length = Double.Parse(cargo.LengthStr, System.Globalization.NumberStyles.Float);

                if (cargo.HeightStr != null)
                    cargo.Height = Double.Parse(cargo.HeightStr, System.Globalization.NumberStyles.Float);

                if (cargo.WeightStr != null)
                    cargo.Weight = Double.Parse(cargo.WeightStr, System.Globalization.NumberStyles.Float);

                if (cargo.PriceStr != null)
                    cargo.Price = Decimal.Parse(cargo.PriceStr, System.Globalization.NumberStyles.Float);

                if (cargo.QuantityStr != null)
                    cargo.Quantity = Int32.Parse(cargo.QuantityStr, System.Globalization.NumberStyles.Integer);

            }
        }

        private void BuildCheckoutStrings()
        {
            if (SelectedOrder.Pickup.DistrictID != 0)
                PickupPrice = $"{SelectedOrder.DeliveryFee}₽ * {SelectedOrder.DistrictMultipliers[SelectedOrder.Pickup.DistrictID - 1]} = {SelectedOrder.PickupPrice}₽";

            if (SelectedOrder.Delivery.DistrictID != 0)
                DeliveryPrice = $"{SelectedOrder.DeliveryFee}₽ * {SelectedOrder.DistrictMultipliers[SelectedOrder.Delivery.DistrictID - 1]} = {SelectedOrder.DeliveryPrice}₽";

            InsurancePrice = $"{SelectedOrder.TotalCargoSum}₽ * {SelectedOrder.InsuranceFee * 100}% = {SelectedOrder.InsurancePrice}₽";
            WeightPrice = $"{SelectedOrder.WeightLimitPrice}₽ * {SelectedOrder.TotalCargoWeight - SelectedOrder.WeightLimit} = {SelectedOrder.WeightPrice}₽";
            TotalPrice = $"{SelectedOrder.SumPrice}₽";
        }

        public ICommand CreateNewCargoItem { get; }
        public ICommand SubmitOrder { get; }
        public ICommand EditOrder { get; }
        public ICommand DeleteCargo { get; }

        public OrderFormViewModel()
        {
            EditingExisting = false;

            AllClients = new ObservableCollection<ClientModel>();
            AllDistricts = new ObservableCollection<DistrictModel>();
            AllCargoTypes = new ObservableCollection<CargoTypeModel>();
            CargoList = new ObservableCollection<OrderContentModel>();

            SelectedOrder = new OrderModel();
            SelectedOrder.Pickup = new LogisticsModel();
            SelectedOrder.Delivery = new LogisticsModel();
            SelectedOrder.Pickup.Date = DateTime.Now;
            SelectedOrder.Delivery.Date = DateTime.Now;
            SelectedOrder.Client = new ClientModel();
            SelectedClient = SelectedOrder.Client;

            SetAllClients();
            SetAllDistricts();
            SetAllCargoTypes();

            CreateNewCargoItem = new ViewModelCommand(ExecuteCreateNewCargoItemCommand);
            SubmitOrder = new ViewModelCommand(ExecuteSubmitOrderCommand);
            DeleteCargo = new ViewModelCommand(ExecuteDeleteCargoCommand);

            SelectedOrder.PropertyChanged += SelectedOrder_PropertyChanged;
        }

        private void ExecuteDeleteCargoCommand(object obj)
        {
            if (!EditingExisting)
                CargoList.Remove(SelectedCargo);
            else
            {
                CargoListToDelete.Add(SelectedCargo);
                CargoList.Remove(SelectedCargo);
            }
        }

        private void SelectedOrder_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //SelectedOrder.CalcTotalSum();
            BuildCheckoutStrings();
        }

        private void ExecuteSubmitOrderCommand(object obj)
        {
            _orderService.AddOrder(SelectedOrder);

            int i = _orderService.GetLastIndex();

            if (CargoList.Count != 0)
            {
                foreach (var cargo in CargoList)
                {
                    cargo.Order = i;
                    _cargoService.AddCargo(cargo);
                }
            }

        }

        public OrderFormViewModel(OrderModel order)
        {

            EditingExisting = true;

            AllClients = new ObservableCollection<ClientModel>();
            AllDistricts = new ObservableCollection<DistrictModel>();
            AllCargoTypes = new ObservableCollection<CargoTypeModel>();
            CargoListToDelete = new ObservableCollection<OrderContentModel>();

            SelectedOrder = order;
            SelectedOrder.Cargo = _cargoService.GetAllCargoForOrder(order.ID);
            //CargoList = new ObservableCollection<OrderContentModel>(_cargoService.GetAllCargoForOrder(order.ID));
            SetAllCargo();


            SetAllClients();
            SetAllDistricts();
            SetAllCargoTypes();
            SetAllStatuses();
            SetAllCouriers();

            SelectedClientI = AllClients.IndexOf(AllClients.Where(c => c.ID == SelectedOrder.Client.ID).FirstOrDefault());

            CreateNewCargoItem = new ViewModelCommand(ExecuteCreateNewCargoItemCommand);
            EditOrder = new ViewModelCommand(ExecuteEditOrderCommand);
            DeleteCargo = new ViewModelCommand(ExecuteDeleteCargoCommand);

            SelectedOrder.PropertyChanged += SelectedOrder_PropertyChanged;
        }

        private void ExecuteEditOrderCommand(object obj)
        {
            SelectedOrder.Client = AllClients[SelectedClientI];
            _orderService.EditOrder(SelectedOrder);

            // Изменение информации о товарах
            if (CargoList.Count != 0)
            {
                foreach (var cargo in CargoList)
                {
                    _cargoService.EditCargo(cargo);
                }
            }

            // Удаление товаров из БД
            if (CargoListToDelete.Count != 0)
            {
                foreach (var cargo in CargoListToDelete)
                {
                    _cargoService.DeleteCargo(cargo);
                }
            }
        }

        private void ExecuteCreateNewCargoItemCommand(object obj)
        {
            CargoList.Add(new OrderContentModel());
            CargoList.Last().CargoType = new CargoTypeModel();

            UpdateCargoProperties();
            SelectedOrder.Cargo = CargoList.ToList();

            SelectedOrder.CalcTotalSum();

            OnPropertyChanged(nameof(CargoList));
        }
    }
}
