using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public class ReportRepo : IReportsRepository
    {
        private DeliveryDBContext db;

        public ReportRepo(DeliveryDBContext db)
        {
            this.db = db;
        }
    }
}
