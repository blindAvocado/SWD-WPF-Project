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
    public class OrderService
    {
        DeliveryDBContext db;

        public OrderService()
        {
            db = new DeliveryDBContext();
        }

        public List<OrderModel> GetAllOrders()
        {
            return db.Orders.AsEnumerable().Select(o => new OrderModel(o)).ToList();
        }

        public List<OrderModel> GetAllOrdersByClientID(int id)
        {
            return db.Orders.AsEnumerable().Select(o => new OrderModel(o)).Where(c => c.ClientID == id).ToList();
        }

        public List<OrderModel> GetWaitingOrders()
        {
            return db.Orders.AsEnumerable().Select(o => new OrderModel(o)).Where(s => s.Status == 2).ToList();
        }

        public List<OrderModel> GetReadyOrders()
        {
            return db.Orders.AsEnumerable().Select(o => new OrderModel(o)).Where(s => s.Status == 3).ToList();
        }

        public string GetClientNameByID(int id)
        {
            return db.Clients.Where(i => i.id_client == id).Select(i => i.name_client).SingleOrDefault();
        }

        public string GetStatusNameByID(int id)
        {
            return db.OrderStatuses.Where(i => i.id_orderStatus == id).Select(i => i.status_orderStatus).SingleOrDefault();
        }

        public void AddOrder(OrderModel order)
        {
            var o = new Order()
            {
                status_order = order.Status,
                createdDate_order = DateTime.Now,
                client_order = order.ClientID,
                sumPrice_order = order.SumPrice,
                pickupAddress_order = order.PickupAddress,
                pickupDate_order = order.PickupDate,
                deliveryAddress_order = order.DeliveryAddress,
                deliveryDate_order = order.DeliveryDate,
                courier_order = order.Courier,
                transport_order = order.Transport,
                comment_order = order.Comment
            };

            db.Orders.Add(o);
            db.SaveChanges();
        }

        public void EditOrder(OrderModel order)
        {
            var o = db.Orders.FirstOrDefault(i => i.id_order == order.ID);
            o.status_order = order.Status;
            o.pickupAddress_order = order.PickupAddress;
            o.pickupDate_order = order.PickupDate;
            o.deliveryAddress_order = order.DeliveryAddress;
            o.deliveryDate_order = order.DeliveryDate;
            o.courier_order = order.Courier;
            o.transport_order = order.Courier;
            o.comment_order = order.Comment;
            db.SaveChanges();
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
                cargoType_orderContent = cargo.CargoType
            };

            db.OrderContents.Add(c);
            db.SaveChanges();
        }
        
        public void DeleteOrder(OrderModel order)
        {
            if (order.ID == 0) return;
            Order o = db.Orders.Where(i => i.id_order == order.ID).First();
            db.Orders.Remove(o);
            db.SaveChanges();
        }

        public void DeleteOrderCargo(OrderContentModel cargo)
        {
            if (cargo.ID == 0) return;
            OrderContent c = db.OrderContents.Where(i => i.id_orderContent == cargo.ID).First();
            db.OrderContents.Remove(c);
            db.SaveChanges();
        }

    }
}
