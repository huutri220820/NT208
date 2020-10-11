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
                new Category() { Id = 1, Name = "Văn học" },
                new Category() { Id = 2, Name = "Kinh tế" },
                new Category() { Id = 3, Name = "Thiếu nhi" },
                new Category() { Id = 4, Name = "Ngoại ngữ" },
                new Category() { Id = 5, Name = "Khoa học kĩ thuật" },
                new Category() { Id = 6, Name = "Lịch sử - Địa lý - Tôn giáo" },
                new Category() { Id = 7, Name = "Khoa học kĩ thuật" },
                new Category() { Id = 8, Name = "Khác" }
                );
            var description = "<strong style=\"margin: 0px; padding: 0px; color: rgb(0, 0, 0); font - family: &quot; Open Sans&quot;, Arial, sans - serif; text - align: justify; \">Lorem Ipsum</strong><span style=\"color: rgb(0, 0, 0); font - family: &quot; Open Sans&quot;, Arial, sans - serif; text - align: justify; \">&nbsp;is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum</span>";

            modelBuilder.Entity<Book>().HasData(
                new Book() { Id = 1, Name = "SP1", Price = 10000, Available = 10, CategoryId = 1, Description = description },
                new Book() { Id = 2, Name = "SP2", Price = 10000, Available = 10, CategoryId = 1, Description = description },
                new Book() { Id = 3, Name = "SP3", Price = 10000, Available = 10, CategoryId = 2, Description = description },
                new Book() { Id = 4, Name = "SP4", Price = 10000, Available = 10, CategoryId = 2, Description = description },
                new Book() { Id = 5, Name = "SP5", Price = 10000, Available = 10, CategoryId = 2, Description = description },
                new Book() { Id = 6, Name = "SP6", Price = 10000, Available = 10, CategoryId = 3, Description = description },
                new Book() { Id = 7, Name = "SP7", Price = 10000, Available = 10, CategoryId = 3, Description = description },
                new Book() { Id = 8, Name = "SP8", Price = 10000, Available = 10, CategoryId = 4, Description = description },
                new Book() { Id = 9, Name = "SP9", Price = 10000, Available = 10, CategoryId = 4, Description = description },
                new Book() { Id = 10, Name = "SP10", Price = 10000, Available = 10, CategoryId = 5, Description = description }
                );

            //tai khoan admin
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
                    PhoneNumber = "0123456788",
                    Gender = true
                }
                );

            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = roleAdminId,
                    Name = "Administrator",
                    NormalizedName = "Administrator",
                }
                );
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole()
                {
                    UserId = adminId,
                    RoleId = roleAdminId
                }
                );

            //tai khoan sales
            var salesId = new Guid("DEFAAC82-A5DF-4F59-8B28-F2674CB44F05");
            var roleSalesId = new Guid("61E1C8DC-A9AE-411E-98D9-110AE7AFE2CB");

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = salesId,
                    Email = "sales@gmail.com",
                    NormalizedEmail = "sales@gmail.com",
                    UserName = "sales",
                    NormalizedUserName = "sales",
                    PasswordHash = hasher.HashPassword(null, "1"),
                    SecurityStamp = string.Empty,
                    FullName = "Sales 1",
                    EmailConfirmed = true,
                    Dob = DateTime.Now,
                    PhoneNumber = "0123456789",
                    Gender = true
                }
                );

            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = roleSalesId,
                    Name = "Sales",
                    NormalizedName = "Sales",
                }
                );
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole()
                {
                    UserId = salesId,
                    RoleId = roleSalesId
                }
                );

            //Tai khoan nguoi dung
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
                    FullName = "User 1",
                    EmailConfirmed = true,
                    Dob = DateTime.Now,
                    PhoneNumber = "0123456787",
                    Gender = true
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
