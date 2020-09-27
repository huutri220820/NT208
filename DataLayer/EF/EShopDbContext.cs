using DataLayer.Entities;
using DataLayer.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EF
{
    public class EShopDbContext : IdentityDbContext<User, 
                                                    Role, 
                                                    Guid, 
                                                    IdentityUserClaim<Guid>, 
                                                    UserRole, 
                                                    IdentityUserLogin<Guid>, 
                                                    IdentityRoleClaim<Guid>, 
                                                    IdentityUserToken<Guid> >
    {
        //private static string ConString = "Server=.;Database=Eshopping;Trusted_Connection=True;";
        public EShopDbContext(DbContextOptions options) : base(options)
        { 

        }

        /// <summary>
        ///khi khởi tạo ưu tiên sử dụng option này thay vì sử dụng option trong file web.startup 
        /// </summary>
        /// <param name="modelBuilder"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Filename=Eshop.db");
        ////{
        ////    optionsBuilder.UseSqlServer(ConString);
        ////}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new UserAddressConfiguration());
            modelBuilder.ApplyConfiguration(new ProductRatingConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new BillConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasKey(x => x.UserId);

            modelBuilder.Seed();
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
    }
}
