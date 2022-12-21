using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using SWD_WPF_Project.Models;

namespace SWD_WPF_Project.Services
{
    public class CargoService
    {
        DeliveryDBContext db;

        public CargoService()
        {
            db = new DeliveryDBContext();
        }

        public List<CargoTypeModel> GetAllCargoTypes()
        {
            return db.CargoTypes.AsEnumerable().Select(c => new CargoTypeModel(c)).ToList();
        }

        public string GetCargoTypeNameByID(int id)
        {
            return db.CargoTypes.Where(i => i.id_cargoType == id).Select(i => i.type_cargoType).SingleOrDefault();
        }

        public void AddCargo(OrderContentModel cargo)
        {
            var c = new OrderContent
            {

            };

            db.OrderContents.Add(c);
            db.SaveChanges();
        }
    }
}
