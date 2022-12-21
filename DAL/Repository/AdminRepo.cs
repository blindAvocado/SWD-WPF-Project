using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdminRepo : IRepository<Admin>
    {
        private DeliveryDB db;

        public AdminRepo(DeliveryDB db)
        {
            this.db = db;
        }

        public void Create(Admin item)
        {
            db.Admins.Add(item);
        }

        public void Delete(int id)
        {
            Admin item = db.Admins.Find(id);
            if (item != null)
                db.Admins.Remove(item);
        }

        public Admin GetItem(int id)
        {
            return db.Admins.Find(id);
        }

        public List<Admin> GetList()
        {
            return db.Admins.ToList();
        }

        public void Update(Admin item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
