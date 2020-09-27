using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public decimal Price { get; set; }
        //path
        public string ProductImage { get; set; }
        public int SoLuongConLai { get; set; }

        private List<ProductRating> productRatings;
        public virtual List<ProductRating> ProductRatings
        {
            get => this.lazyLoader.Load(this, ref this.productRatings);
            set => this.productRatings = value;
        }



    }

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(x => x.ProductRatings).WithOne(x => x.Product).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Name).IsUnicode().IsRequired();
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.ProductImage).HasDefaultValue(Images.ProductImageDefault);
        }
    }
}
