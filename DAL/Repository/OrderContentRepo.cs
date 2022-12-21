using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public class OrderContentRepo : IRepository<OrderContent>
    {
        private DeliveryDBContext db;

        public OrderContentRepo(DeliveryDBContext db)
        {
            this.db = db;
        }

        public void Create(OrderContent item)
        {
            db.OrderContents.Add(item);
        }

        public void Delete(int id)
        {
            OrderContent item = db.OrderContents.Find(id);
            if (item != null)
                db.OrderContents.Remove(item);
        }

        public OrderContent GetItem(int id)
        {
            return db.OrderContents.Find(id);
        }

        public List<OrderContent> GetList()
        {
            return db.OrderContents.ToList();
        }

        public void Update(OrderContent item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
