using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD_WPF_Project.Interfaces;
using DAL;

namespace SWD_WPF_Project.Services
{
    public partial class ReportsService : IDbReportsService
    {
        IDbRepository db;

        public ReportsService(IDbRepository dbrepo)
        {
            db = dbrepo;
        }
    }
}
