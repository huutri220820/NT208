using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
        public Guid  UserId { get; set; }
        public virtual User User { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateModify { get; set; }
        public DateTime? DateReceive { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public decimal TriGia { get; set; }
        public decimal Ship { get; set; }

        private List<OrderDetail> orderDetails;
        public virtual List<OrderDetail>  OrderDetails
        {
            get => this.lazyLoader.Load(this, ref this.orderDetails);
            set => this.orderDetails = value;
        }
        public virtual Bill Bill { get; set; }
        public string GhiChu { get; set; }
    }

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Order).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Bill).WithOne(x => x.Order).HasForeignKey<Bill>(x => x.OrderRef).OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.DateReceive).IsRequired(false);
            builder.Property(x => x.DateModify).IsRequired(false);
            builder.Property(x => x.GhiChu).IsRequired(false);
        }
    }
}
