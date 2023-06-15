using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payment.Infraesrtucture.Entities;

namespace Payment.Infraesrtucture.Persistence
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options) { }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ShipmentOrder> ShipmentOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ShipmentOrder>()
            .HasOne(i => i.Order)
            .WithMany(i => i.ShipmentOrders)
            .HasForeignKey(i => i.OrderId);

            builder.Entity<OrderDetail>()
            .HasOne(i => i.Order)
            .WithMany(i => i.OrderDetails)
            .HasForeignKey(i => i.OrderId);

            builder.Entity<ShipmentOrder>()
            .Property(i => i.CreatedDate)
            //.HasColumnType("datatime")
            .HasDefaultValueSql("getutcdate()");

            builder.Entity<Order>()
           .Property(i => i.CreatedDate)
           //.HasColumnType("datatime")
           .HasDefaultValueSql("getutcdate()");

            builder.Entity<OrderDetail>()
            .Property(i => i.CreatedDate)
            //.HasColumnType("datatime")
            .HasDefaultValueSql("getutcdate()");
        }
    }
}