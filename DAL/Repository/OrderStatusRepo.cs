using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderStatusRepo : IRepository<OrderStatus>
    {
        private DeliveryDB db;

        public OrderStatusRepo(DeliveryDB db)
        {
            this.db = db;
        }

        public void Create(OrderStatus item)
        {
            db.OrderStatus.Add(item);
        }

        public void Delete(int id)
        {
            OrderStatus item = db.OrderStatus.Find(id);
            if (item != null)
                db.OrderStatus.Remove(item);
        }

        public OrderStatus GetItem(int id)
        {
            return db.OrderStatus.Find(id);
        }

        public List<OrderStatus> GetList()
        {
            return db.OrderStatus.ToList();
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
