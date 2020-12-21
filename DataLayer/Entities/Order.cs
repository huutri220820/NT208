//Vo Huu Tri - 18521531 UIT
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Order
    {
        private readonly ILazyLoader lazyLoader;

        public Order()
        {
        }

        public Order(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        public int Id { get; set; }
        public Guid UserId { get; set; }

        // dia chi giao hang co the la dia chi user hoac khac
        public string Address { get; set; }

        public virtual User User { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateModify { get; set; }
        public DateTime? DateReceive { get; set; }
        public DateTime? DateReturn { get; set; }
        public OrderStatus OrderStatus { get; set; }
        private List<OrderDetail> orderDetails;

        public virtual List<OrderDetail> OrderDetails
        {
            get => this.lazyLoader.Load(this, ref this.orderDetails);
            set => this.orderDetails = value;
        }

        public decimal TotalPrice { get; set; }

        public bool isDelete { get; set; }
    }

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Order).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.DateCreate).IsRequired(true).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.DateModify).IsRequired(false);
            builder.Property(x => x.DateReceive).IsRequired(false);
            builder.Property(x => x.Address).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.OrderStatus).IsRequired(true);
            builder.Property(x => x.TotalPrice).IsRequired(true).HasDefaultValue(0);
            builder.Property(x => x.isDelete).HasDefaultValue(false);
        }
    }
}