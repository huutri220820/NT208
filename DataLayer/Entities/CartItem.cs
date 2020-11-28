using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataLayer.Entities
{
    public class CartItem
    {
        //public int Id { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        // so luong
        public int Quantity { get; set; }
    }

    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(x => new { x.UserId, x.BookId });
            builder.Property(x => x.UserId).IsRequired(true);
            builder.Property(x => x.BookId).IsRequired(true);
            builder.Property(x => x.Quantity).IsRequired(true).HasDefaultValue(1);
        }

    }
}
