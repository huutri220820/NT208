using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataLayer.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        // so luong
        public int Quantity { get; set; }
        public DateTime DateCreate { get; set; }
        // dat hang true, chua dat hang false
        public bool IsOrder { get; set; }
    }

    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
        }
    }
}
