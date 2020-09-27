using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataLayer.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public int OrderRef { get; set; }
        public virtual Order Order { get; set; }
        public virtual HinhThucTT HinhThucTT { get; set; }
        // phi van chuyen
        public decimal Ship { get; set; }
        //ngay tao la ngay thanh toan
        public DateTime DateCreate { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.Property(x => x.Ship).IsRequired(true).HasDefaultValue(0);
            builder.Property(x => x.HinhThucTT).IsRequired(true).HasDefaultValue(HinhThucTT.COD);
            builder.Property(x => x.TotalPrice).IsRequired(true).HasDefaultValue(0);
            builder.Property(x => x.DateCreate).IsRequired(true).HasDefaultValue(DateTime.Now);
        }
    }
}
