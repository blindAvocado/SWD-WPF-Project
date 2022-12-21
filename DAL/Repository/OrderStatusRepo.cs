using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public class OrderStatusRepo : IRepository<OrderStatus>
    {
        private DeliveryDBContext db;

        public OrderStatusRepo(DeliveryDBContext db)
        {
            this.db = db;
        }

        public void Create(OrderStatus item)
        {
            db.OrderStatuses.Add(item);
        }

        public void Delete(int id)
        {
            OrderStatus item = db.OrderStatuses.Find(id);
            if (item != null)
                db.OrderStatuses.Remove(item);
        }

        public OrderStatus GetItem(int id)
        {
            return db.OrderStatuses.Find(id);
        }

        public List<OrderStatus> GetList()
        {
            return db.OrderStatuses.ToList();
        }

        public void Update(OrderStatus item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
