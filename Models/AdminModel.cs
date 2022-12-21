using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace SWD_WPF_Project.Models
{
    public class AdminModel : ModelBase
    {
        private int _id;
        private string _name;
        private string _email;
        private string _login;
        private string _password;

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

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public AdminModel() { }

        public AdminModel(Admin admin)
        {
            ID = admin.id_admin;
            Name = admin.name_admin;
            Email = admin.email_admin;
            Login = admin.login_admin;
            Password = admin.password_admin;
        }
    }
}
