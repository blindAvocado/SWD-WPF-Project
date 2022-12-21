using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace SWD_WPF_Project.Models
{
    public class OrderModel : ModelBase
    {
        private int _id;
        private int _status;
        private string _statusName;
        private DateTime _createdDate;
        private int _clientID;
        private string _clientName;
        private string _pickupAddress;
        private DateTime _pickupDate;
        private string _deliveryAddress;
        private DateTime _deliveryDate;
        private decimal _sumPrice;
        private int? _courier;
        private int? _transport;
        private string _comment;

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public int Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
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

        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set
            {
                _createdDate = value;
                OnPropertyChanged(nameof(CreatedDate));
            }
        }

        public int ClientID
        {
            get { return _clientID; }
            set
            {
                _clientID = value;
                OnPropertyChanged(nameof(Client));
            }
        }

        public string ClientName
        {
            get { return _clientName; }
            set
            {
                _clientName = value;
                OnPropertyChanged(nameof(ClientName));
            }
        }

        public string PickupAddress
        {
            get { return _pickupAddress; }
            set
            {
                _pickupAddress = value;
                OnPropertyChanged(nameof(PickupAddress));
            }
        }

        public DateTime PickupDate
        {
            get { return _pickupDate; }
            set
            {
                _pickupDate = value;
                OnPropertyChanged(nameof(PickupDate));
            }
        }

        public string DeliveryAddress
        {
            get { return _deliveryAddress; }
            set
            {
                _deliveryAddress = value;
                OnPropertyChanged(nameof(DeliveryAddress));
            }
        }

        public DateTime DeliveryDate
        {
            get { return _deliveryDate; }
            set
            {
                _deliveryDate = value;
                OnPropertyChanged(nameof(DeliveryDate));
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

        public OrderModel() { }

        public OrderModel(Order order)
        {
            ID = order.id_order;
            Status = order.status_order;
            CreatedDate = order.createdDate_order;
            ClientID = order.client_order;
            PickupAddress = order.pickupAddress_order;
            PickupDate = order.pickupDate_order;
            DeliveryAddress = order.deliveryAddress_order;
            DeliveryDate = order.deliveryDate_order;
            SumPrice = order.sumPrice_order;
            Courier = order.courier_order;
            Transport = order.transport_order;
            Comment = order.comment_order;
        }
    }
}
