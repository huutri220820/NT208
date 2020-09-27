using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Address
    {
        private readonly ILazyLoader lazyLoader;
        public Address()
        {

        }
        public Address(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }
        public int Id { get; set; }

        private List<UserAddress> userAddress;
   
        public virtual List<UserAddress> UserAddress
        {
            get => this.lazyLoader.Load(this, ref this.userAddress);
            set => this.userAddress = value;
        }

        public string City { get; set; }
        public string District { get; set; }
        //so nha ten duong ...
        public string AddressDetail { get; set; }
        public string PhoneNumber { get; set; }

        private List<Order> orders;
        public virtual List<Order> Orders
        {
            get => this.lazyLoader.Load(this, ref this.orders);
            set => this.orders = value;
        }

    }

    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasMany(x => x.UserAddress).WithOne(x => x.Address).HasForeignKey(x => x.AddressId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Orders).WithOne(x => x.Address).HasForeignKey(x => x.AddressId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
