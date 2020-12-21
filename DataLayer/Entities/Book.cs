//Vo Huu Tri - 18521531 UIT
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Book
    {
        private readonly ILazyLoader lazyLoader;

        public Book()
        {
        }

        public Book(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Description { get; set; }

        // dong vi: dong
        public decimal Price { get; set; }

        //path
        public string BookImage { get; set; }

        // so luong san co
        public int Available { get; set; }

        private List<BookRating> bookRatings;

        public virtual List<BookRating> BookRatings
        {
            get => this.lazyLoader.Load(this, ref this.bookRatings);
            set => this.bookRatings = value;
        }

        //giam gia : % so tien se giam di
        public decimal Sale { get; set; }

        //dung cho tim kiem va sap xep
        public string KeyWord { get; set; }

        public int WeekScore { get; set; }
        public int MonthScore { get; set; }
        public int YearScore { get; set; }

        public bool isDelete { get; set; }
    }

    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasMany(x => x.BookRatings).WithOne(x => x.Book).HasForeignKey(x => x.BookId).OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Name).IsUnicode().IsRequired(true).HasMaxLength(50).HasDefaultValue("Product");
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.BookImage).HasDefaultValue(Lorem.BookImage).IsRequired(true);
            builder.Property(x => x.Available).IsRequired(true).HasDefaultValue(0);
            builder.Property(x => x.Price).IsRequired(true).HasDefaultValue(0);
            builder.Property(x => x.Sale).HasDefaultValue(0);
            builder.Property(x => x.WeekScore).HasDefaultValue(0);
            builder.Property(x => x.MonthScore).HasDefaultValue(0);
            builder.Property(x => x.YearScore).HasDefaultValue(0);
            builder.Property(x => x.isDelete).HasDefaultValue(false);
        }
    }
}