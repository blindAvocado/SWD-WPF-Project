using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace SWD_WPF_Project.Models
{
    public class OrderStatusModel : ModelBase
    {
        private int _id;
        private string _name;

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

        public OrderStatusModel() { }

        public OrderStatusModel(OrderStatus type)
        {
            ID = type.id_orderStatus;
            Name = type.status_orderStatus;
        }
    }
}
