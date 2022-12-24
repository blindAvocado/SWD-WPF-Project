using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DAL;
using DAL.Entities;
using SWD_WPF_Project.Models;

namespace SWD_WPF_Project.Services
{
    public class OrderService
    {
        DeliveryDBContext db;

        public OrderService()
        {
            db = new DeliveryDBContext();
        }

        public List<OrderModel> GetAllOrders()
        {
            db = new DeliveryDBContext();
            return db.Orders.AsEnumerable().Select(o => new OrderModel(o)).ToList();

        }

        public List<OrderModel> GetAllOrdersByClientID(int id)
        {
            return db.Orders.AsEnumerable().Select(o => new OrderModel(o)).Where(c => c.Client.ID == id).ToList();
        }

        public List<OrderModel> GetAllOrdersByCourierID(int id)
        {
            return db.Orders.AsEnumerable().Select(o => new OrderModel(o)).Where(c => c.Courier == id).ToList();
        }

        public List<OrderModel> GetWaitingOrders()
        {
            return db.Orders.AsEnumerable().Select(o => new OrderModel(o)).Where(s => s.StatusID == 2).ToList();
        }

        public List<OrderModel> GetReadyOrders()
        {
            return db.Orders.AsEnumerable().Select(o => new OrderModel(o)).Where(s => s.StatusID == 3).ToList();
        }

        public string GetStatusNameByID(int id)
        {
            return db.OrderStatuses.Where(i => i.id_orderStatus == id).Select(i => i.status_orderStatus).SingleOrDefault();
        }

        public int GetLastIndex()
        {
            return db.Orders.OrderByDescending(i => i.id_order).FirstOrDefault().id_order;
        }

        public List<OrderStatusModel> GetAllStatuses()
        {
            return db.OrderStatuses.AsEnumerable().Select(s => new OrderStatusModel(s)).ToList();
        }

        public Brush GetOrderStatusBGColor(int id)
        {
            var converter = new BrushConverter();

            if (id == 1)
                return (Brush)converter.ConvertFromString("#4CAF50"); //Доставлено
            if (id == 2)
                return (Brush)converter.ConvertFromString("#607D8B"); //Ожидает забора
            if (id == 3)
                return (Brush)converter.ConvertFromString("#FFC107"); //На складе
            if (id == 4)
                return (Brush)converter.ConvertFromString("#F44336"); //Отменен

            return (Brush)converter.ConvertFromString("#757575");
        }

        public string GetDistrictNameByID(int id)
        {
            return db.Districts.Where(i => i.id_district == id).Select(i => i.name_district).SingleOrDefault();
        }

        public void AddOrder(OrderModel order)
        {
            var o = new Order()
            {
                status_order = 2,
                createdDate_order = DateTime.Now,
                client_order = order.Client.ID,
                sumPrice_order = order.SumPrice,
                pickupDistrict_order = order.Pickup.DistrictID,
                pickupAddress_order = order.Pickup.Address,
                pickupDate_order = order.Pickup.Date,
                deliveryDistrict_order = order.Delivery.DistrictID,
                deliveryAddress_order = order.Delivery.Address,
                deliveryDate_order = order.Delivery.Date,
                courier_order = order.Courier,
                transport_order = order.Transport,
                comment_order = order.Comment
            };

            db.Orders.Add(o);
            db.SaveChanges();
        }

        public void EditOrder(OrderModel order)
        {
            var o = db.Orders.Find(order.ID);

            if (o != null)
            {
                o.status_order = order.StatusID;
                o.client_order = order.Client.ID;
                o.sumPrice_order = order.SumPrice;
                o.pickupDistrict_order = order.Pickup.DistrictID;
                o.pickupAddress_order = order.Pickup.Address;
                o.pickupDate_order = order.Pickup.Date;
                o.deliveryDistrict_order = order.Delivery.DistrictID;
                o.deliveryAddress_order = order.Delivery.Address;
                o.deliveryDate_order = order.Delivery.Date;
                o.courier_order = order.Courier;
                //o.transport_order = order.Courier;
                o.comment_order = order.Comment;
                db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            db.Entry(o).Reload();
        }

        public void AddOrderCargo(OrderContentModel cargo)
        {
            var c = new OrderContent()
            {
                order_orderContent = cargo.Order,
                width_orderContent = cargo.Width,
                length_orderContent = cargo.Length,
                height_orderContent = cargo.Height,
                weight_orderContent = cargo.Weight,
                quantity_orderContent = cargo.Quantity,
                cargoType_orderContent = cargo.CargoType.ID
            };

            db.OrderContents.Add(c);
            db.SaveChanges();
        }
        
        public void DeleteOrder(OrderModel order)
        {
            if (order.ID == 0) return;
            Order o = db.Orders.Find(order.ID);
            db.Orders.Remove(o);
            db.SaveChanges();
        }

        public void DeleteOrderCargo(int id)
        {
            if (id == 0) return;
            //OrderContent c = db.OrderContents.Find(cargo.ID);
            //db.OrderContents.Remove(c);
            db.OrderContents.RemoveRange(db.OrderContents.Where(i => i.order_orderContent == id));
            db.SaveChanges();
        }

    }
}
