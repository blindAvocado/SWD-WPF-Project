using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using DAL;

namespace SWD_WPF_Project.Models
{
    public class ClientModel : ModelBase
    {
        private int _id;
        private string _name;
        private string _phone;
        private string _email;
        private decimal? _discount;

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

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public decimal? Discount
        {
            get { return _discount; }
            set
            {
                _discount = value;
                OnPropertyChanged(nameof(Discount));
            }
        }

        public ClientModel() { }

        public ClientModel(Client client)
        {
            ID = client.id_client;
            Name = client.name_client;
            Phone = client.phone_client;
            Email = client.email_client;
            Discount = client.discount_client;
        }
    }
}
