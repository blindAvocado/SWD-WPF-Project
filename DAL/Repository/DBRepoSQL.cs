using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public class DBRepoSQL : IDbRepository
    {
        private DeliveryDBContext db;
        private OrderRepo orderRepository;
        private OrderStatusRepo orderStatusRepository;
        private OrderContentRepo orderContentRepository;
        private CargoTypeRepo cargoTypeRepository;
        private TransportRepo transportRepository;
        private AdminRepo adminRepository;
        private ManagerRepo managerRepository;
        private CourierRepo courierRepository;
        private ClientRepo clientRepository;

        public DBRepoSQL()
        {
            db = new DeliveryDBContext();
        }

        public IRepository<Order> orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepo(db);
                return orderRepository;
            }
        }

        public IRepository<OrderStatus> orderStatus
        {
            get
            {
                if (orderStatusRepository == null)
                    orderStatusRepository = new OrderStatusRepo(db);
                return orderStatusRepository;
            }
        }

        public IRepository<OrderContent> orderContent
        {
            get
            {
                if (orderContentRepository == null)
                    orderContentRepository = new OrderContentRepo(db);
                return orderContentRepository;
            }
        }

        public IRepository<CargoType> cargoType
        {
            get
            {
                if (cargoTypeRepository == null)
                    cargoTypeRepository = new CargoTypeRepo(db);
                return cargoTypeRepository;
            }
        }

        public IRepository<Transport> transport
        {
            get
            {
                if (transportRepository == null)
                    transportRepository = new TransportRepo(db);
                return transportRepository;
            }
        }

        public IRepository<Admin> admins
        {
            get
            {
                if (adminRepository == null)
                    adminRepository = new AdminRepo(db);
                return adminRepository;
            }
        }

        public IRepository<Manager> managers
        {
            get
            {
                if (managerRepository == null)
                    managerRepository = new ManagerRepo(db);
                return managerRepository;
            }
        }

        public IRepository<Courier> couriers
        {
            get
            {
                if (courierRepository == null)
                    courierRepository = new CourierRepo(db);
                return courierRepository;
            }
        }

        public IRepository<Client> clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepo(db);
                return clientRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
