using DataLayer.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

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
        public string Avatar { get; set; }
        //true la nam, false la nu
        public bool IsMale { get; set; }

        public string Address { get; set; }

        private List<CartItem> cartItems;
        public virtual List<CartItem> CartItems
        {
            get => this.lazyLoader.Load(this, ref this.cartItems);
            set => this.cartItems = value;
        }

        private List<Order> orders;
        public virtual List<Order> Orders
        {
            get => this.lazyLoader.Load(this, ref this.orders);
            set => this.orders = value;
        }

        private List<BookRating> bookRatings;
        public virtual List<BookRating> BookRatings
        {
            get => this.lazyLoader.Load(this, ref this.bookRatings);
            set => this.bookRatings = value;
        }

        private List<UserRole> userRoles;
        public virtual List<UserRole> UserRoles
        {
            get => this.lazyLoader.Load(this, ref this.userRoles);
            set => this.userRoles = value;
        }

        private List<Blog> blogs;
        //chi co admin va sales moi su dung blog de dang tin
        public virtual List<Blog> Blogs
        {
            get => this.lazyLoader.Load(this, ref this.blogs);
            set => this.blogs = value;
        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.CartItems).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Orders).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.BookRatings).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.UserRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Blogs).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Avatar).HasDefaultValue(Images.AvatarDefault);
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired(false).IsUnicode(false);
            builder.Property(x => x.PhoneNumber).HasMaxLength(10).IsRequired(true).IsUnicode(false);
            builder.Property(x => x.FullName).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(x => x.IsMale).IsRequired(true);
            builder.Property(x => x.Address).HasMaxLength(200).IsRequired(true).HasDefaultValue("none");
        }
    }
}
