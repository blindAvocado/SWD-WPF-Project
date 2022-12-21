using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace SWD_WPF_Project.Models
{
    public class OrderModel : ModelBase
    {
        private int _id;
        private DateTime _date;
        private int _client;
        private string _address;
        private string _password;
    }
}
