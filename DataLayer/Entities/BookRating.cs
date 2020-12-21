//Vo Huu Tri - 18521531 UIT
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataLayer.Entities
{
    public class BookRating
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        // tu 1 den 5 sao
        public int Rating { get; set; }

        public string Comment { get; set; }
    }

    public class BookRatingConfiguration : IEntityTypeConfiguration<BookRating>
    {
        public void Configure(EntityTypeBuilder<BookRating> builder)
        {
            builder.Property(x => x.Rating).IsRequired(true).HasDefaultValue(5);
            builder.Property(x => x.Comment).IsRequired(false);
        }
    }
}