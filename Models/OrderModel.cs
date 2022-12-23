using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DAL.Entities;

namespace SWD_WPF_Project.Models
{
    public class OrderModel : ModelBase
    {
        private int _id;
        private int _statusID;
        private string _statusName;
        private Brush _statusBGBrush;
        private ClientModel _client;
        private DateTime _createdDate;
        private LogisticsModel _pickup;
        private LogisticsModel _delivery;
        private decimal _sumPrice;
        private int? _courier;
        private int? _transport;
        private string _comment;
        private List<OrderContentModel> _cargo;

        private double[] districtMultipliers = { 1.3, 1.5, 1 };
        private double _insuranceFee = 0.03;
        private decimal _deliveryFee = 1500;
        private decimal _weightLimitPrice = 25;
        private double _weightLimit = 100;

        private double _totalCargoWeight;
        private decimal _totalCargoSum;
        private decimal _pickupPrice;
        private decimal _deliveryPrice;
        private decimal _insurancePrice;
        private decimal _weightPrice;

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public int StatusID
        {
            get { return _statusID; }
            set
            {
                _statusID = value;
                OnPropertyChanged(nameof(StatusID));
            }
        }

        public string StatusName
        {
            get { return _statusName; }
            set
            {
                _statusName = value;
                OnPropertyChanged(nameof(StatusName));
            }
        }

        public Brush StatusBGBrush
        {
            get { return _statusBGBrush; }
            set
            {
                _statusBGBrush = value;
                OnPropertyChanged(nameof(StatusBGBrush));
            }
        }

        public ClientModel Client
        {
            get { return _client; }
            set
            {
                _client = value;
                OnPropertyChanged(nameof(Client));
            }
        }

        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set
            {
                _createdDate = value;
                OnPropertyChanged(nameof(CreatedDate));
            }
        }
        
        public LogisticsModel Pickup
        {
            get { return _pickup; }
            set
            {
                _pickup = value;
                OnPropertyChanged(nameof(Pickup));
            }
        }

        public LogisticsModel Delivery
        {
            get { return _delivery; }
            set
            {
                _delivery = value;
                OnPropertyChanged(nameof(Delivery));
            }
        }

        public decimal SumPrice
        {
            get { return _sumPrice; }
            set
            {
                _sumPrice = value;
                OnPropertyChanged(nameof(SumPrice));
            }
        }

        public int? Courier
        {
            get { return _courier; }
            set
            {
                _courier = value;
                OnPropertyChanged(nameof(Courier));
            }
        }

        public int? Transport
        {
            get { return _transport; }
            set
            {
                _transport = value;
                OnPropertyChanged(nameof(Transport));
            }
        }

        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        public List<OrderContentModel> Cargo
        {
            get { return _cargo; }
            set
            {
                _cargo = value;
                OnPropertyChanged(nameof(Cargo));
            }
        }

        public double[] DistrictMultipliers
        {
            get { return districtMultipliers; }
            set
            {
                districtMultipliers = value;
                OnPropertyChanged(nameof(DistrictMultipliers));
            }
        }

        public double InsuranceFee
        {
            get { return _insuranceFee; }
            set
            {
                _insuranceFee = value;
                OnPropertyChanged(nameof(InsuranceFee));
            }
        }

        public decimal DeliveryFee
        {
            get { return _deliveryFee; }
            set
            {
                _deliveryFee = value;
                OnPropertyChanged(nameof(DeliveryFee));
            }
        }

        public double WeightLimit
        {
            get { return _weightLimit; }
            set
            {
                _weightLimit = value;
                OnPropertyChanged(nameof(WeightLimit));
            }
        }

        public decimal TotalCargoSum
        {
            get { return _totalCargoSum; }
            set
            {
                _totalCargoSum = value;
                OnPropertyChanged(nameof(TotalCargoSum));
            }
        }

        public double TotalCargoWeight
        {
            get { return _totalCargoWeight; }
            set
            {
                _totalCargoWeight = value;
                OnPropertyChanged(nameof(TotalCargoWeight));
            }
        }

        public decimal PickupPrice
        {
            get { return _pickupPrice; }
            set
            {
                _pickupPrice = value;
                OnPropertyChanged(nameof(PickupPrice));
            }
        }

        public decimal DeliveryPrice
        {
            get { return _deliveryPrice; }
            set
            {
                _deliveryPrice = value;
                OnPropertyChanged(nameof(DeliveryPrice));
            }
        }

        public decimal InsurancePrice
        {
            get { return _insurancePrice; }
            set
            {
                _insurancePrice = value;
                OnPropertyChanged(nameof(InsurancePrice));
            }
        }

        public decimal WeightPrice
        {
            get { return _weightPrice; }
            set
            {
                _weightPrice = value;
                OnPropertyChanged(nameof(WeightPrice));
            }
        }

        public decimal WeightLimitPrice
        {
            get { return _weightLimitPrice; }
            set
            {
                _weightLimitPrice = value;
                OnPropertyChanged(nameof(WeightLimitPrice));
            }
        }

        public void CalcDistrictSum()
        {
            PickupPrice = 0;
            DeliveryPrice = 0;

            if (Pickup.DistrictID != 0)
                PickupPrice += DeliveryFee * (decimal)districtMultipliers[Pickup.DistrictID - 1];

            if (Delivery.DistrictID != 0)
                DeliveryPrice += DeliveryFee * (decimal)districtMultipliers[Delivery.DistrictID - 1];
        }

        //Высчитывание веса заказа и стоимости за вес
        public void CalcWeightSum()
        {
            TotalCargoWeight = 0;
            TotalCargoSum = 0;
            WeightPrice = 0;

            //Высчитывание веса заказа
            if (Cargo != null)
            {
                foreach (var cargo in Cargo)
                {
                    TotalCargoWeight += cargo.Weight;
                    TotalCargoSum += cargo.Price * cargo.Quantity;
                }

                //Перерасчет стоимости за превышение порога в 100кг
                if (TotalCargoWeight > WeightLimit)
                {
                    double tempWeight = TotalCargoWeight - WeightLimit;
                    WeightPrice += (decimal)tempWeight * WeightLimitPrice;
                }

            }
        }

        //Высчитывание стоимости страхования
        public void CalcInsuranceSum()
        {
            InsurancePrice = 0;

            if (Cargo != null)
            {
                foreach (var cargo in Cargo)
                {
                    InsurancePrice += cargo.Price * cargo.Quantity * (decimal)InsuranceFee;
                }
            }
        }

        public void CalcTotalSum()
        {
            SumPrice = 0;

            CalcDistrictSum();
            CalcInsuranceSum();
            CalcWeightSum();

            SumPrice = PickupPrice + DeliveryPrice + InsurancePrice + WeightPrice;
        }

        public OrderModel() { }

        public OrderModel(Order order)
        {
            ID = order.id_order;
            StatusID = order.status_order;
            CreatedDate = order.createdDate_order;
            Client = new ClientModel();
            Client.ID = order.client_order;
            Pickup = new LogisticsModel();
            Pickup.DistrictID = order.pickupDistrict_order;
            Pickup.Address = order.pickupAddress_order;
            Pickup.Date = order.pickupDate_order;
            Delivery = new LogisticsModel();
            Delivery.DistrictID = order.deliveryDistrict_order;
            Delivery.Address = order.deliveryAddress_order;
            Delivery.Date = order.deliveryDate_order;
            SumPrice = order.sumPrice_order;
            Courier = order.courier_order;
            Transport = order.transport_order;
            Comment = order.comment_order;
        }
    }
}
