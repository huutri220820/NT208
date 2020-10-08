using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Product
    {
        private readonly ILazyLoader lazyLoader;

        public Product()
        {

        }
        public Product(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Description { get; set; }
        // dong vi: dong
        public decimal Price { get; set; }
        //path
        public string ProductImage { get; set; }
        // so luong san co
        public int Available { get; set; }

        private List<ProductRating> productRatings;
        public virtual List<ProductRating> ProductRatings
        {
            get => this.lazyLoader.Load(this, ref this.productRatings);
            set => this.productRatings = value;
        }
        //giam gia
        public double Sale { get; set; }



    }

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(x => x.ProductRatings).WithOne(x => x.Product).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Name).IsUnicode().IsRequired(true).HasMaxLength(50).HasDefaultValue("Product");
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.ProductImage).HasDefaultValue(Images.ProductImageDefault).IsRequired(true);
            builder.Property(x => x.Available).IsRequired(true).HasDefaultValue(0);
            builder.Property(x => x.Price).IsRequired(true).HasDefaultValue(0);
            builder.Property(x => x.Sale).IsRequired(false);
        }
    }
}
