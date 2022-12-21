using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TransportRepo : IRepository<Transport>
    {
        private DeliveryDB db;

        public TransportRepo(DeliveryDB db)
        {
            this.db = db;
        }

        public void Create(Transport item)
        {
            db.Transports.Add(item);
        }

        public void Delete(int id)
        {
            Transport item = db.Transports.Find(id);
            if (item != null)
                db.Transports.Remove(item);
        }

        public Transport GetItem(int id)
        {
            return db.Transports.Find(id);
        }

        public List<Transport> GetList()
        {
            return db.Transports.ToList();
        }

        public void Update(Transport item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
