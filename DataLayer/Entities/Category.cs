using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Category
    {
        private readonly ILazyLoader lazyLoader;

        public Category()
        {

        }
        public Category(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        private List<Product> products;
        public virtual List<Product> Products
        {
            get => this.lazyLoader.Load(this, ref this.products);
            set => this.products = value;
        }
    }

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.Description).IsRequired(false);
        }
    }
}
