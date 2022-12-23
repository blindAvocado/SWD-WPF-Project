using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace SWD_WPF_Project.Models
{
    public class OrderContentModel : ModelBase
    {
        private int _id;
        private int _order;
        private double _width;
        private double _length;
        private double _height;
        private double _weight;
        private int _quantity;
        private decimal _price;
        private CargoTypeModel _cargoType;

        private string _widthStr;
        private string _lengthStr;
        private string _heightStr;
        private string _weightStr;
        private string _quantityStr;
        private string _priceStr;


        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public int Order
        {
            get { return _order; }
            set
            {
                _order = value;
                OnPropertyChanged(nameof(Order));
            }
        }

        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        public double Length
        {
            get { return _length; }
            set
            {
                _length = value;
                OnPropertyChanged(nameof(Length));
            }
        }

        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        public double Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public CargoTypeModel CargoType
        {
            get { return _cargoType; }
            set
            {
                _cargoType = value;
                OnPropertyChanged(nameof(CargoType));
            }
        }

        public string WidthStr
        {
            get { return _widthStr; }
            set
            {
                _widthStr = value;
                OnPropertyChanged(nameof(WidthStr));
            }
        }

        public string LengthStr
        {
            get { return _lengthStr; }
            set
            {
                _lengthStr = value;
                OnPropertyChanged(nameof(LengthStr));
            }
        }

        public string HeightStr
        {
            get { return _heightStr; }
            set
            {
                _heightStr = value;
                OnPropertyChanged(nameof(HeightStr));
            }
        }

        public string WeightStr
        {
            get { return _weightStr; }
            set
            {
                _weightStr = value;
                OnPropertyChanged(nameof(WeightStr));
            }
        }

        public string QuantityStr
        {
            get { return _quantityStr; }
            set
            {
                _quantityStr = value;
                OnPropertyChanged(nameof(QuantityStr));
            }
        }

        public string PriceStr
        {
            get { return _priceStr; }
            set
            {
                _priceStr = value;
                OnPropertyChanged(nameof(PriceStr));
            }
        }

        public OrderContentModel() { }

        public OrderContentModel(OrderContent cargo)
        {
            ID = cargo.id_orderContent;
            Order = cargo.order_orderContent;
            Width = cargo.width_orderContent;
            Length = cargo.length_orderContent;
            Height = cargo.height_orderContent;
            Weight = cargo.weight_orderContent;
            Quantity = cargo.quantity_orderContent;
            CargoType = new CargoTypeModel();
            CargoType.ID = cargo.cargoType_orderContent;
        }
    }
}
