using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class UserAddress
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
    }

    public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.HasKey(x => new { x.UserId, x.AddressId });
        }
    }
}
