using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CourierRepo : IRepository<Courier>
    {
        private DeliveryDB db;

        public CourierRepo(DeliveryDB db)
        {
            this.db = db;
        }

        public void Create(Courier item)
        {
            db.Couriers.Add(item);
        }

        public void Delete(int id)
        {
            Courier item = db.Couriers.Find(id);
            if (item != null)
                db.Couriers.Remove(item);
        }

        public Courier GetItem(int id)
        {
            return db.Couriers.Find(id);
        }

        public List<Courier> GetList()
        {
            return db.Couriers.ToList();
        }

        public void Update(Courier item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
