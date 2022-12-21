using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CargoTypeRepo : IRepository<CargoType>
    {
        private DeliveryDB db;

        public CargoTypeRepo(DeliveryDB db)
        {
            this.db = db;
        }

        public void Create(CargoType item)
        {
            db.CargoTypes.Add(item);
        }

        public void Delete(int id)
        {
            CargoType item = db.CargoTypes.Find(id);
            if (item != null)
                db.CargoTypes.Remove(item);
        }

        public CargoType GetItem(int id)
        {
            return db.CargoTypes.Find(id);
        }

        public List<CargoType> GetList()
        {
            return db.CargoTypes.ToList();
        }

        public void Update(CargoType item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public bool Save()
        {
            return db.SaveChanges() > 0;
        }
    }
}
