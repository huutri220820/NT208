using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataLayer.Entities
{
    public class Receipt
    {
        public int Id { get; set; }
        public int OrderRef { get; set; }
        public virtual Order Order { get; set; }
        public virtual PayMethod PayMethod { get; set; }
        // phi van chuyen
        public decimal Ship { get; set; }
        //ngay tao la ngay thanh toan
        public DateTime DateCreate { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.Property(x => x.Ship).IsRequired(true).HasDefaultValue(0);
            builder.Property(x => x.PayMethod).IsRequired(true).HasDefaultValue(PayMethod.COD);
            builder.Property(x => x.TotalPrice).IsRequired(true).HasDefaultValue(0);
            builder.Property(x => x.DateCreate).IsRequired(true).HasDefaultValue(DateTime.Now);
        }
    }
}
