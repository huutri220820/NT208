using DataLayer.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class User : IdentityUser<Guid>
    {
        private readonly ILazyLoader lazyLoader;

        public User()
        {

        }
        public User(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public string Avata { get; set; }
        //true la nam, false la nu
        public bool GioiTinh { get; set; }

        private List<CartItem> cartItems;
        public virtual List<CartItem> CartItems
        {
            get => this.lazyLoader.Load(this, ref this.cartItems);
            set => this.cartItems = value;
        }

        private List<UserAddress> userAddresses;
        public virtual List<UserAddress> UserAddresses
        {
            get => this.lazyLoader.Load(this, ref this.userAddresses);
            set => this.userAddresses = value;
        }

        private List<Order> orders;
        public virtual List<Order> Orders
        {
            get => this.lazyLoader.Load(this, ref this.orders);
            set => this.orders = value;
        }

        private List<ProductRating> productRatings;
        public virtual List<ProductRating> ProductRatings
        {
            get => this.lazyLoader.Load(this, ref this.productRatings);
            set => this.productRatings = value;
        }

        private List<UserRole> userRoles;
        public virtual List<UserRole> UserRoles
        {
            get => this.lazyLoader.Load(this, ref this.userRoles);
            set => this.userRoles = value;
        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.CartItems).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.UserAddresses).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Orders).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.ProductRatings).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.UserRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Avata).HasDefaultValue(Images.AvatarDefault);

        }
    }
}
