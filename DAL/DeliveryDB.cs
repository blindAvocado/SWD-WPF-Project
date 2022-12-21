using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public partial class DeliveryDB : DbContext
    {
        public DeliveryDB()
            : base("name=DBConnection")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<CargoType> CargoTypes { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Courier> Couriers { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<OrderContent> OrderContents { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Transport> Transports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CargoType>()
                .HasMany(e => e.OrderContents)
                .WithRequired(e => e.CargoType)
                .HasForeignKey(e => e.cargoType_orderContent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.client_order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Courier>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Courier)
                .HasForeignKey(e => e.courier_order);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderContents)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.order_orderContent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderStatus>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.OrderStatu)
                .HasForeignKey(e => e.status_order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transport>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Transport)
                .HasForeignKey(e => e.transport_order);
        }
    }
}
