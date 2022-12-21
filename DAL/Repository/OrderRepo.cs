using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public class OrderRepo : IRepository<Order>
    {
        private DeliveryDBContext db;

        public OrderRepo(DeliveryDBContext db)
        {
            this.db = db;
        }

        public void Create(Order item)
        {
            db.Orders.Add(item);
        }

        public void Delete(int id)
        {
            Order item = db.Orders.Find(id);
            if (item != null)
                db.Orders.Remove(item);
        }

        public Order GetItem(int id)
        {
            return db.Orders.Find(id);
        }

        public List<Order> GetList()
        {
            return db.Orders.ToList();
        }

        public void Update(Order item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
