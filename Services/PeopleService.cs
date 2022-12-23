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
            return db.Clients.AsEnumerable().Select(c => new ClientModel(c)).ToList();
        }

        public string GetClientNameByID(int id)
        {
            return db.Clients.Where(i => i.id_client == id).Select(i => i.name_client).SingleOrDefault();
        }

        public List<CourierModel> GetAllCouriers()
        {
            return db.Couriers.AsEnumerable().Select(c => new CourierModel(c)).ToList();
        }
    }
}
