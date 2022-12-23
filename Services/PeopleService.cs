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
    public class PeopleService
    {
        DeliveryDBContext db;

        public PeopleService()
        {
            db = new DeliveryDBContext();
        }

        public List<ClientModel> GetAllClients()
        {
            db = new DeliveryDBContext();
            return db.Clients.AsEnumerable().Select(c => new ClientModel(c)).ToList();
        }

        public string GetClientNameByID(int id)
        {
            return db.Clients.Where(i => i.id_client == id).Select(i => i.name_client).SingleOrDefault();
        }

        public ClientModel GetClientModelByID(int id)
        {
            ClientModel client = new ClientModel();
            client.Name = db.Clients.Where(i => i.id_client == id).Select(i => i.name_client).SingleOrDefault();
            client.Email = db.Clients.Where(i => i.id_client == id).Select(i => i.email_client).SingleOrDefault();
            client.Phone = db.Clients.Where(i => i.id_client == id).Select(i => i.phone_client).SingleOrDefault();
            client.ID = id;

            return client;
        }
        public List<CourierModel> GetAllCouriers()
        {
            db = new DeliveryDBContext();
            return db.Couriers.AsEnumerable().Select(c => new CourierModel(c)).ToList();
        }

        public string GetCourierNameById(int? id)
        {
            if (id == 0) return "Не задан";
            return db.Couriers.Where(i => i.id_courier == id).Select(i => i.name_courier).SingleOrDefault();
        }

        public void AddClient(ClientModel client)
        {
            var c = new Client()
            {
                name_client = client.Name,
                email_client = client.Email,
                phone_client = client.Phone
            };

            db.Clients.Add(c);
            db.SaveChanges();
        }

        public void EditClient(ClientModel client)
        {
            var c = db.Clients.Find(client.ID);

            if (c != null)
            {
                c.name_client = client.Name;
                c.email_client = client.Email;
                c.phone_client = client.Phone;
                db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            db.Entry(c).Reload();
        }

        public void AddCourier(CourierModel courier)
        {
            var c = new Courier()
            {
                name_courier = courier.Name,
                phone_courier = courier.Phone,
            };

            db.Couriers.Add(c);
            db.SaveChanges();
        }

        public void EditCourier(CourierModel courier)
        {
            var c = db.Couriers.Find(courier.ID);

            if (c != null)
            {
                c.name_courier = courier.Name;
                c.phone_courier = courier.Phone;
                db.Entry(c).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            db.Entry(c).Reload();
        }

        public string GetRandomBGColor()
        {
            Random rnd = new Random();
            int color = rnd.Next(1, 5);

            switch(color)
            {
                case 1:
                    return "#D32F2F"; // Red

                case 2:
                    return "#FF5722"; // Deep Orange

                case 3:
                    return "#4CAF50"; // Green

                case 4:
                    return "#673AB7"; // Deep Purple
            }

            return "#000000";
        }
    }
}
