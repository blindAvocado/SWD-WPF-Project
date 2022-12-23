using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_WPF_Project.Models
{
    public class LogisticsModel : ModelBase
    {
        private int _districtId;
        private string _districtName;
        private string _address;
        private DateTime _date;

        public int DistrictID
        {
            get { return _districtId; }
            set
            {
                _districtId = value;
                OnPropertyChanged(nameof(DistrictID));
            }
        }

        public string DistrictName
        {
            get { return _districtName; }
            set
            {
                _districtName = value;
                OnPropertyChanged(nameof(DistrictName));
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
    }
}
