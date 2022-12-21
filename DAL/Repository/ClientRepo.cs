using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public class ClientRepo : IRepository<Client>
    {
        private DeliveryDBContext db;

        public ClientRepo(DeliveryDBContext db)
        {
            this.db = db;
        }

        public void Create(Client item)
        {
            db.Clients.Add(item);
        }

        public void Delete(int id)
        {
            Client item = db.Clients.Find(id);
            if (item != null)
                db.Clients.Remove(item);
        }

        public Client GetItem(int id)
        {
            return db.Clients.Find(id);
        }

        public List<Client> GetList()
        {
            return db.Clients.ToList();
        }

        public void Update(Client item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
