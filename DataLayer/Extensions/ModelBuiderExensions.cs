//Vo Huu Tri - 18521531 UIT
using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataLayer.Extensions
{
    public static class ModelBuiderExensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Văn học", KeyWord = "vanhoc, van hoc" },
                new Category() { Id = 2, Name = "Kinh tế", KeyWord = "kinhte, kinh te" },
                new Category() { Id = 3, Name = "Thiếu nhi", KeyWord = "thieunhi, thieu nhi" },
                new Category() { Id = 4, Name = "Ngoại ngữ", KeyWord = "ngoaingu, ngoai ngu" },
                new Category() { Id = 5, Name = "Khoa học kĩ thuật", KeyWord = "khoa hoc ki thuat, khoa hoc ky thuat, Khoa học kỹ thuật" },
                new Category() { Id = 6, Name = "Lịch sử - Địa lý - Tôn giáo", KeyWord = "lich su, dia li, dia ly, ton giao" },
                new Category() { Id = 7, Name = "Khác" }
                );

            var description = Lorem.BookDescription;

            modelBuilder.Entity<Book>().HasData(
                new Book() { Id = 1, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 0, CategoryId = 1, Description = description, KeyWord = "SachHay, SachRe", WeekScore = 10 },
                new Book() { Id = 2, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 0, CategoryId = 1, Description = description, KeyWord = "SachHay, SachRe", MonthScore = 10 },
                new Book() { Id = 3, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 10, CategoryId = 1, Description = description, KeyWord = "SachHay, SachRe", YearScore = 10 },
                new Book() { Id = 4, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 10, CategoryId = 1, Description = description, KeyWord = "SachHay, SachRe" },
                new Book() { Id = 5, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 10, CategoryId = 1, Description = description, KeyWord = "SachHay, SachRe" },
                new Book() { Id = 6, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 10, CategoryId = 1, Description = description, KeyWord = "SachHay, SachRe" },
                new Book() { Id = 7, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 10, CategoryId = 1, Description = description },
                new Book() { Id = 8, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 10, CategoryId = 1, Description = description },
                new Book() { Id = 9, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 10, CategoryId = 1, Description = description },
                new Book() { Id = 10, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 10, CategoryId = 1, Description = description }
                );

            //tai khoan admin
            var adminId = new Guid("DE8781CE-01A8-1AC1-88AD-99EF6CAF6957");
            var roleAdminId = new Guid("7D2E5394-DDC3-4BBC-9ECB-327F2F37CE6C");

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = adminId,
                    Email = "admin@gmail.com",
                    NormalizedEmail = "admin@gmail.com",
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    PasswordHash = hasher.HashPassword(null, "1"),
                    SecurityStamp = string.Empty,
                    FullName = "Administrator",
                    EmailConfirmed = true,
                    Dob = DateTime.Now,
                    PhoneNumber = "0123456788",
                    IsMale = true
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
                    IsMale = true
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
                    IsMale = true,
                    isUser = true
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