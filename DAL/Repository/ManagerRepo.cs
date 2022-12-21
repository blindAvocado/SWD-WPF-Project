using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public class ManagerRepo : IRepository<Manager>
    {
        private DeliveryDBContext db;

        public ManagerRepo(DeliveryDBContext db)
        {
            this.db = db;
        }

        public void Create(Manager item)
        {
            db.Managers.Add(item);
        }

        public void Delete(int id)
        {
            Manager item = db.Managers.Find(id);
            if (item != null)
                db.Managers.Remove(item);
        }

        public Manager GetItem(int id)
        {
            return db.Managers.Find(id);
        }

        public List<Manager> GetList()
        {
            return db.Managers.ToList();
        }

        public void Update(Manager item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
