using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Bill
    {
        public int Id { get; set; }
        public int OrderRef { get; set; }
        public virtual Order Order { get; set; }
        public virtual HinhThucTT HinhThucTT { get; set; }
        public bool DaTT { get; set; }
        public decimal SoTien { get; set; }
    }

    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
        }
    }
}
