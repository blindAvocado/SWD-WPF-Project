using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace SWD_WPF_Project.Models
{
    public class CourierModel : ModelBase
    {
        private int _id;
        private string _name;
        private string _phone;

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        public CourierModel() { }

        public CourierModel(Courier courier)
        {
            ID = courier.id_courier;
            Name = courier.name_courier;
            Phone = courier.phone_courier;
        }
    }
}
