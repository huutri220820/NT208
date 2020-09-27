using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Entities
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        // totalprice = priceProduct * Quantity
        public decimal TotalPrice { get; set; }
    }

    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => new { x.OrderId, x.ProductId });
            builder.Property(x => x.Quantity).IsRequired(true).HasDefaultValue(0);
            builder.Property(x => x.TotalPrice).IsRequired(true).HasDefaultValue(0);
        }
    }
}
