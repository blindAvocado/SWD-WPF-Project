using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Entities
{
    public partial class DeliveryDBContext : DbContext
    {
        public DeliveryDBContext()
            : base("name=DeliveryDB")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<CargoType> CargoTypes { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Courier> Couriers { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<OrderContent> OrderContents { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
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
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Courier>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Courier)
                .HasForeignKey(e => e.courier_order);

            modelBuilder.Entity<District>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.District)
                .HasForeignKey(e => e.pickupDistrict_order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<District>()
                .HasMany(e => e.Orders1)
                .WithRequired(e => e.District1)
                .HasForeignKey(e => e.deliveryDistrict_order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderContents)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.order_orderContent)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<OrderStatus>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.OrderStatus)
                .HasForeignKey(e => e.status_order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transport>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Transport)
                .HasForeignKey(e => e.transport_order);
        }
    }
}
