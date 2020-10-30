using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;

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
        private List<Book> books;
        public virtual List<Book> Books
        {
            get => this.lazyLoader.Load(this, ref this.books);
            set => this.books = value;
        }
    }

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(x => x.Books).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.Name).IsRequired(true);
        }
    }
}
