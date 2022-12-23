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

        public List<OrderContentModel> GetAllCargoForOrder(int id)
        {
            return db.OrderContents.AsEnumerable().Where(i => i.order_orderContent == id).Select(i => new OrderContentModel(i)).ToList();
        }

        public void AddCargo(OrderContentModel cargo)
        {
            var c = new OrderContent
            {
                order_orderContent = cargo.Order,
                width_orderContent = Double.Parse(cargo.WidthStr, System.Globalization.NumberStyles.Float),
                length_orderContent = Double.Parse(cargo.LengthStr, System.Globalization.NumberStyles.Float),
                height_orderContent = Double.Parse(cargo.HeightStr, System.Globalization.NumberStyles.Float),
                weight_orderContent = Double.Parse(cargo.WeightStr, System.Globalization.NumberStyles.Float),
                price_orderContent = Decimal.Parse(cargo.PriceStr, System.Globalization.NumberStyles.Float),
                quantity_orderContent = Int32.Parse(cargo.QuantityStr, System.Globalization.NumberStyles.Integer),
                cargoType_orderContent = cargo.CargoType.ID
            };

            db.OrderContents.Add(c);
            db.SaveChanges();
        }

        public void EditCargo(OrderContentModel cargo)
        {
            var o = db.OrderContents.FirstOrDefault(i => i.id_orderContent == cargo.ID);
            o.width_orderContent  = Double.Parse(cargo.WidthStr, System.Globalization.NumberStyles.Float);
            o.length_orderContent = Double.Parse(cargo.LengthStr, System.Globalization.NumberStyles.Float);
            o.height_orderContent = Double.Parse(cargo.HeightStr, System.Globalization.NumberStyles.Float);
            o.weight_orderContent = Double.Parse(cargo.WeightStr, System.Globalization.NumberStyles.Float);
            o.price_orderContent = Decimal.Parse(cargo.PriceStr, System.Globalization.NumberStyles.Float);
            o.quantity_orderContent = Int32.Parse(cargo.QuantityStr, System.Globalization.NumberStyles.Integer);
            o.cargoType_orderContent = cargo.CargoType.ID;
            db.SaveChanges();
        }

        public void DeleteCargo(OrderContentModel cargo)
        {
            if (cargo.ID == 0) return;
            OrderContent c = db.OrderContents.Find(cargo.ID);
            db.OrderContents.Remove(c);
            db.SaveChanges();
        }

        public void SetCargoProperties(OrderContentModel cargo)
        {
            var c = db.OrderContents.FirstOrDefault(i => i.id_orderContent == cargo.ID);
            cargo.Width = c.width_orderContent;
            cargo.Length = c.length_orderContent;
            cargo.Height = c.height_orderContent;
            cargo.Weight = c.weight_orderContent;
            cargo.Price = c.price_orderContent;
            cargo.Quantity = c.quantity_orderContent;
            cargo.CargoType.ID = c.cargoType_orderContent;
        }
    }
}
