using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDbRepository
    {
        IRepository<Order> orders { get; }
        IRepository<OrderStatus> orderStatus { get; }
        IRepository<OrderContent> orderContent { get; }
        IRepository<CargoType> cargoType { get; }
        IRepository<Transport> transport { get; }
        IRepository<Admin> admins { get; }
        IRepository<Manager> managers { get; }
        IRepository<Courier> couriers { get; }
        IRepository<Client> clients { get; }
        int Save();

    }
}
