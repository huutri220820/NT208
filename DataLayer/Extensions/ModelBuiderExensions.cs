using DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Extensions
{
    public static class ModelBuiderExensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Điện tử" },
                new Category() { Id = 2, Name = "Phụ kiện" },
                new Category() { Id = 3, Name = "Điện gia dụng" },
                new Category() { Id = 4, Name = "Nhà cửa đời sống" },
                new Category() { Id = 5, Name = "Điện gia dụng" },
                new Category() { Id = 6, Name = "Đồ chơi" },
                new Category() { Id = 7, Name = "Sách - VPP" },
                new Category() { Id = 8, Name = "Quà Tặng" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, Name = "SP1", Price = 10000, SoLuongConLai = 10, CategoryId = 1 },
                new Product() { Id = 2, Name = "SP2", Price = 10000, SoLuongConLai = 10, CategoryId = 1 },
                new Product() { Id = 3, Name = "SP3", Price = 10000, SoLuongConLai = 10, CategoryId = 2 },
                new Product() { Id = 4, Name = "SP4", Price = 10000, SoLuongConLai = 10, CategoryId = 2 },
                new Product() { Id = 5, Name = "SP5", Price = 10000, SoLuongConLai = 10, CategoryId = 2 },
                new Product() { Id = 6, Name = "SP6", Price = 10000, SoLuongConLai = 10, CategoryId = 3 },
                new Product() { Id = 7, Name = "SP7", Price = 10000, SoLuongConLai = 10, CategoryId = 3 },
                new Product() { Id = 8, Name = "SP8", Price = 10000, SoLuongConLai = 10, CategoryId = 4 },
                new Product() { Id = 9, Name = "SP9", Price = 10000, SoLuongConLai = 10, CategoryId = 4 },
                new Product() { Id = 10, Name = "SP10", Price = 10000, SoLuongConLai = 10, CategoryId = 5 }
                );

            var adminId = new Guid("DE8783CE-05A8-4AC2-88AD-99EF6CAF6957");
            var roleAdminId = new Guid("7D2E5394-DDC3-4BBC-9ECB-327F2F37CE6C");

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = adminId,
                    Email = "admin@gmail.com",
                    NormalizedEmail = "admin@gmail.com",
                    UserName ="admin",
                    NormalizedUserName = "admin",
                    PasswordHash = hasher.HashPassword(null, "1"),
                    SecurityStamp = string.Empty,
                    FullName = "Administrator",
                    EmailConfirmed =true,
                    Dob = DateTime.Now,
                    PhoneNumber = "84123456789",
                    GioiTinh = true
                }
                );


            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = roleAdminId,
                    NormalizedName = "AdminRole",
                    Name = "Administrator",
                }
                );
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole()
                {
                    UserId = adminId,
                    RoleId = roleAdminId
                }
                );

            var userId = new Guid("5E814BD0-7504-4E1F-8DBA-FDF01031CAE6");
            var roleUserId = new Guid("D5388079-D681-444E-8291-99CDF0C71973");

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = userId,
                    Email = "user@gmail.com",
                    NormalizedEmail = "user@gmail.com",
                    UserName = "user",
                    NormalizedUserName = "user",
                    PasswordHash = hasher.HashPassword(null, "1"),
                    SecurityStamp = string.Empty,
                    FullName = "Sales 1",
                    EmailConfirmed = true,
                    Dob = DateTime.Now,
                    PhoneNumber = "84123456788",
                    GioiTinh = true
                }
                );

            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = roleUserId,
                    NormalizedName = "User",
                    Name = "User",
                }
                );
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole()
                {
                    UserId = userId,
                    RoleId = roleUserId
                }
                );

        }
    }
}
