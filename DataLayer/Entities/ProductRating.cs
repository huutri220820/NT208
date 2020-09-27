using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataLayer.Entities
{
    public class ProductRating
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        // tu 1 den 5 sao
        public int Rating { get; set; }
        public string Comment { get; set; }
    }

    public class ProductRatingConfiguration : IEntityTypeConfiguration<ProductRating>
    {
        public void Configure(EntityTypeBuilder<ProductRating> builder)
        {
            builder.Property(x => x.Rating).IsRequired(true).HasDefaultValue(5);
            builder.Property(x => x.Comment).IsRequired(false);
        }
    }
}
