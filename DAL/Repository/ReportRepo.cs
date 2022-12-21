using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReportRepo : IReportsRepository
    {
        private DeliveryDB db;

        public ReportRepo(DeliveryDB db)
        {
            this.db = db;
        }
    }
}
