using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    KeyWord = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    Dob = table.Column<DateTime>(nullable: false),
                    Avatar = table.Column<string>(nullable: true, defaultValue: "https://www.pavilionweb.com/wp-content/uploads/2017/03/man-300x300.png"),
                    IsMale = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: false, defaultValue: "none"),
                    isUser = table.Column<bool>(nullable: false, defaultValue: false),
                    isDelete = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false, defaultValue: "Product"),
                    Author = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    BookImage = table.Column<string>(nullable: false, defaultValue: "https://www.vinabook.com/images/thumbnails/product/240x/361208_p92078mnxbtremattroilucnuadembia1.jpg"),
                    Available = table.Column<int>(nullable: false, defaultValue: 0),
                    Sale = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    KeyWord = table.Column<string>(nullable: true),
                    WeekScore = table.Column<int>(nullable: false, defaultValue: 0),
                    MonthScore = table.Column<int>(nullable: false, defaultValue: 0),
                    YearScore = table.Column<int>(nullable: false, defaultValue: 0),
                    isDelete = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    DateCreate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blog_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: false),
                    DateCreate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 12, 22, 21, 8, 43, 157, DateTimeKind.Local).AddTicks(6748)),
                    DateModify = table.Column<DateTime>(nullable: true),
                    DateReceive = table.Column<DateTime>(nullable: true),
                    DateReturn = table.Column<DateTime>(nullable: true),
                    OrderStatus = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    isDelete = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookRatings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false, defaultValue: 5),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookRatings_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookRatings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.UserId, x.BookId });
                    table.ForeignKey(
                        name: "FK_CartItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false, defaultValue: 0),
                    TotalPrice = table.Column<decimal>(nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.BookId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "KeyWord", "Name" },
                values: new object[,]
                {
                    { 1, "vanhoc, van hoc", "Văn học" },
                    { 2, "kinhte, kinh te", "Kinh tế" },
                    { 3, "thieunhi, thieu nhi", "Thiếu nhi" },
                    { 4, "ngoaingu, ngoai ngu", "Ngoại ngữ" },
                    { 5, "khoa hoc ki thuat, khoa hoc ky thuat, Khoa học kỹ thuật", "Khoa học kĩ thuật" },
                    { 6, "lich su, dia li, dia ly, ton giao", "Lịch sử - Địa lý - Tôn giáo" },
                    { 7, null, "Khác" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("7d2e5394-ddc3-4bbc-9ecb-327f2f37ce6c"), "3f371af9-ae54-494d-b1a5-5ee3154e1395", "Administrator", "Administrator" },
                    { new Guid("61e1c8dc-a9ae-411e-98d9-110ae7afe2cb"), "e2156f0a-672f-4236-845a-8eb6e4057839", "Sales", "Sales" },
                    { new Guid("d5388079-d681-444e-8291-99cdf0c71973"), "cb3458d3-4f09-457a-9dd5-16844d0e7596", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FullName", "IsMale", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("de8781ce-01a8-1ac1-88ad-99ef6caf6957"), 0, "339fcdce-e3b0-4dcb-8d15-dc94ca600b62", new DateTime(2020, 12, 22, 21, 8, 43, 187, DateTimeKind.Local).AddTicks(7970), "admin@gmail.com", true, "Administrator", true, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEGsvIH5nQEJP+zli8NbLlNjPn5MJdJWuNt0lCNk2BIUqFJ/nwxzCEY+QEkzOLg+4+A==", "0123456788", false, "", false, "admin" },
                    { new Guid("defaac82-a5df-4f59-8b28-f2674cb44f05"), 0, "ff96f297-18c9-45e9-a4b9-e5c0d0d83fba", new DateTime(2020, 12, 22, 21, 8, 43, 197, DateTimeKind.Local).AddTicks(4441), "sales@gmail.com", true, "Sales 1", true, false, null, "sales@gmail.com", "sales", "AQAAAAEAACcQAAAAEO2mM62PeZKYlAunOiZGUrudh8Gz5GjLaHFyKK33rXV0fjo7eaDTNpMBxkKZIj0QMQ==", "0123456789", false, "", false, "sales" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FullName", "IsMale", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isUser" },
                values: new object[] { new Guid("5e814bd0-7504-4e1f-8dba-fdf01031cae6"), 0, "19a21dbd-4373-4222-b524-edcb378813aa", new DateTime(2020, 12, 22, 21, 8, 43, 206, DateTimeKind.Local).AddTicks(965), "user@gmail.com", true, "User 1", true, false, null, "user@gmail.com", "user", "AQAAAAEAACcQAAAAENyGYwCYv4VMAv78N5ZD+PJAnEJhVrQpEzEWyi3AZ7pscQZ2VvdZt33YGrSv5CM/8A==", "0123456787", false, "", false, "user", true });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "KeyWord", "Name", "Price", "WeekScore" },
                values: new object[] { 1, "Eren Yeager", 1, @"Nhà xuất bản Trẻ giới thiệu đến Quý vị tập sách mới trong bộ sách Chạng vạng của tác giả Stephanie Mayer là Mặt trời lúc nửa đêm. Bộ tiểu thuyết Chạng vạng gồm 4 tập là Chạng vạng, Trăng non, Nhật thực, Hừng đông đã thu hút hàng triệu độc giả trên toàn thế giới, trở thành tác phẩm kinh điển định hình lại dòng văn học dành cho bạn đọc trẻ và dấy lên một hiện tượng lạ khiến độc giả khao khát chờ đợi phần tiếp theo. Loạt truyện đã bán được 160 triệu bản ở nhiều quốc gia và dựng thành năm bộ phim bom tấn. Ở Việt Nam, bộ sách cũng đã tạo nên cơn sốt ngay khi phát hành và liên tục bán chạy qua nhiều năm.

Mặt trời lúc nửa đêm (tựa gốc: Midnight Sun), tập sách mới nhất trong bộ Chạng vạng, cũng đã nối tiếp thành công của các tựa sách trước đó. Chỉ trong tuần đầu phát hành, cuốn sách đã bán ngay được 1 triệu bản ở thị trường Âu – Mỹ.

Khi Edward Cullen và Bella Swan gặp nhau trong Chạng vạng, một chuyện tình yêu mang tính biểu tượng đã ra đời. Nhưng cho đến bây giờ, người hâm mộ chỉ nghe thấy câu chuyện từ góc nhìn của Bella. Cuối cùng, độc giả đã có thể trải nghiệm phiên bản của Edward trong cuốn tiểu thuyết đồng hành đã được chờ đợi từ lâu, Mặt trời lúc nửa đêm.

Câu chuyện đen tối này được kể qua đôi mắt của Edward với nhiều mới mẻ và những bước ngoặt quyết định. Gặp gỡ Bella vừa là sự kiện hấp dẫn nhất, cũng là điều đáng sợ nhất mà anh đã trải qua trong suốt những năm tháng làm ma cà rồng. Khi tìm hiểu thêm các chi tiết lạ lùng trong quá khứ Edward cũng như nội tâm phức tạp của anh, chúng ta sẽ hiểu tại sao đây là cuộc chiến quyết định trong đời Edward. Anh sẽ biện minh cho trái tim mình thế nào nếu yêu Bella cũng đồng nghĩa với việc dẫn cô đến với nguy hiểm?

Trong Mặt trời lúc nửa đêm, Stephenie Meyer đưa chúng ta trở lại một thế giới đã thu hút hàng triệu độc giả, và mang đến một tiểu thuyết gay cấn về niềm vui và hậu quả tàn khốc của tình yêu bất tử.

Giá sản phẩm trên Tiki đã bao gồm thuế theo luật hiện hành. Tuy nhiên tuỳ vào từng loại sản phẩm hoặc phương thức, địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như phí vận chuyển, phụ phí hàng cồng kềnh, ...", "SachHay, SachRe", "Mặt Trời Lúc Nửa Đêm", 10000m, 10 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "KeyWord", "MonthScore", "Name", "Price" },
                values: new object[] { 2, "Eren Yeager", 1, @"Nhà xuất bản Trẻ giới thiệu đến Quý vị tập sách mới trong bộ sách Chạng vạng của tác giả Stephanie Mayer là Mặt trời lúc nửa đêm. Bộ tiểu thuyết Chạng vạng gồm 4 tập là Chạng vạng, Trăng non, Nhật thực, Hừng đông đã thu hút hàng triệu độc giả trên toàn thế giới, trở thành tác phẩm kinh điển định hình lại dòng văn học dành cho bạn đọc trẻ và dấy lên một hiện tượng lạ khiến độc giả khao khát chờ đợi phần tiếp theo. Loạt truyện đã bán được 160 triệu bản ở nhiều quốc gia và dựng thành năm bộ phim bom tấn. Ở Việt Nam, bộ sách cũng đã tạo nên cơn sốt ngay khi phát hành và liên tục bán chạy qua nhiều năm.

Mặt trời lúc nửa đêm (tựa gốc: Midnight Sun), tập sách mới nhất trong bộ Chạng vạng, cũng đã nối tiếp thành công của các tựa sách trước đó. Chỉ trong tuần đầu phát hành, cuốn sách đã bán ngay được 1 triệu bản ở thị trường Âu – Mỹ.

Khi Edward Cullen và Bella Swan gặp nhau trong Chạng vạng, một chuyện tình yêu mang tính biểu tượng đã ra đời. Nhưng cho đến bây giờ, người hâm mộ chỉ nghe thấy câu chuyện từ góc nhìn của Bella. Cuối cùng, độc giả đã có thể trải nghiệm phiên bản của Edward trong cuốn tiểu thuyết đồng hành đã được chờ đợi từ lâu, Mặt trời lúc nửa đêm.

Câu chuyện đen tối này được kể qua đôi mắt của Edward với nhiều mới mẻ và những bước ngoặt quyết định. Gặp gỡ Bella vừa là sự kiện hấp dẫn nhất, cũng là điều đáng sợ nhất mà anh đã trải qua trong suốt những năm tháng làm ma cà rồng. Khi tìm hiểu thêm các chi tiết lạ lùng trong quá khứ Edward cũng như nội tâm phức tạp của anh, chúng ta sẽ hiểu tại sao đây là cuộc chiến quyết định trong đời Edward. Anh sẽ biện minh cho trái tim mình thế nào nếu yêu Bella cũng đồng nghĩa với việc dẫn cô đến với nguy hiểm?

Trong Mặt trời lúc nửa đêm, Stephenie Meyer đưa chúng ta trở lại một thế giới đã thu hút hàng triệu độc giả, và mang đến một tiểu thuyết gay cấn về niềm vui và hậu quả tàn khốc của tình yêu bất tử.

Giá sản phẩm trên Tiki đã bao gồm thuế theo luật hiện hành. Tuy nhiên tuỳ vào từng loại sản phẩm hoặc phương thức, địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như phí vận chuyển, phụ phí hàng cồng kềnh, ...", "SachHay, SachRe", 10, "Mặt Trời Lúc Nửa Đêm", 10000m });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Available", "CategoryId", "Description", "KeyWord", "Name", "Price", "YearScore" },
                values: new object[] { 3, "Eren Yeager", 10, 1, @"Nhà xuất bản Trẻ giới thiệu đến Quý vị tập sách mới trong bộ sách Chạng vạng của tác giả Stephanie Mayer là Mặt trời lúc nửa đêm. Bộ tiểu thuyết Chạng vạng gồm 4 tập là Chạng vạng, Trăng non, Nhật thực, Hừng đông đã thu hút hàng triệu độc giả trên toàn thế giới, trở thành tác phẩm kinh điển định hình lại dòng văn học dành cho bạn đọc trẻ và dấy lên một hiện tượng lạ khiến độc giả khao khát chờ đợi phần tiếp theo. Loạt truyện đã bán được 160 triệu bản ở nhiều quốc gia và dựng thành năm bộ phim bom tấn. Ở Việt Nam, bộ sách cũng đã tạo nên cơn sốt ngay khi phát hành và liên tục bán chạy qua nhiều năm.

Mặt trời lúc nửa đêm (tựa gốc: Midnight Sun), tập sách mới nhất trong bộ Chạng vạng, cũng đã nối tiếp thành công của các tựa sách trước đó. Chỉ trong tuần đầu phát hành, cuốn sách đã bán ngay được 1 triệu bản ở thị trường Âu – Mỹ.

Khi Edward Cullen và Bella Swan gặp nhau trong Chạng vạng, một chuyện tình yêu mang tính biểu tượng đã ra đời. Nhưng cho đến bây giờ, người hâm mộ chỉ nghe thấy câu chuyện từ góc nhìn của Bella. Cuối cùng, độc giả đã có thể trải nghiệm phiên bản của Edward trong cuốn tiểu thuyết đồng hành đã được chờ đợi từ lâu, Mặt trời lúc nửa đêm.

Câu chuyện đen tối này được kể qua đôi mắt của Edward với nhiều mới mẻ và những bước ngoặt quyết định. Gặp gỡ Bella vừa là sự kiện hấp dẫn nhất, cũng là điều đáng sợ nhất mà anh đã trải qua trong suốt những năm tháng làm ma cà rồng. Khi tìm hiểu thêm các chi tiết lạ lùng trong quá khứ Edward cũng như nội tâm phức tạp của anh, chúng ta sẽ hiểu tại sao đây là cuộc chiến quyết định trong đời Edward. Anh sẽ biện minh cho trái tim mình thế nào nếu yêu Bella cũng đồng nghĩa với việc dẫn cô đến với nguy hiểm?

Trong Mặt trời lúc nửa đêm, Stephenie Meyer đưa chúng ta trở lại một thế giới đã thu hút hàng triệu độc giả, và mang đến một tiểu thuyết gay cấn về niềm vui và hậu quả tàn khốc của tình yêu bất tử.

Giá sản phẩm trên Tiki đã bao gồm thuế theo luật hiện hành. Tuy nhiên tuỳ vào từng loại sản phẩm hoặc phương thức, địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như phí vận chuyển, phụ phí hàng cồng kềnh, ...", "SachHay, SachRe", "Mặt Trời Lúc Nửa Đêm", 10000m, 10 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Available", "CategoryId", "Description", "KeyWord", "Name", "Price" },
                values: new object[,]
                {
                    { 4, "Eren Yeager", 10, 1, @"Nhà xuất bản Trẻ giới thiệu đến Quý vị tập sách mới trong bộ sách Chạng vạng của tác giả Stephanie Mayer là Mặt trời lúc nửa đêm. Bộ tiểu thuyết Chạng vạng gồm 4 tập là Chạng vạng, Trăng non, Nhật thực, Hừng đông đã thu hút hàng triệu độc giả trên toàn thế giới, trở thành tác phẩm kinh điển định hình lại dòng văn học dành cho bạn đọc trẻ và dấy lên một hiện tượng lạ khiến độc giả khao khát chờ đợi phần tiếp theo. Loạt truyện đã bán được 160 triệu bản ở nhiều quốc gia và dựng thành năm bộ phim bom tấn. Ở Việt Nam, bộ sách cũng đã tạo nên cơn sốt ngay khi phát hành và liên tục bán chạy qua nhiều năm.

                Mặt trời lúc nửa đêm (tựa gốc: Midnight Sun), tập sách mới nhất trong bộ Chạng vạng, cũng đã nối tiếp thành công của các tựa sách trước đó. Chỉ trong tuần đầu phát hành, cuốn sách đã bán ngay được 1 triệu bản ở thị trường Âu – Mỹ.

                Khi Edward Cullen và Bella Swan gặp nhau trong Chạng vạng, một chuyện tình yêu mang tính biểu tượng đã ra đời. Nhưng cho đến bây giờ, người hâm mộ chỉ nghe thấy câu chuyện từ góc nhìn của Bella. Cuối cùng, độc giả đã có thể trải nghiệm phiên bản của Edward trong cuốn tiểu thuyết đồng hành đã được chờ đợi từ lâu, Mặt trời lúc nửa đêm.

                Câu chuyện đen tối này được kể qua đôi mắt của Edward với nhiều mới mẻ và những bước ngoặt quyết định. Gặp gỡ Bella vừa là sự kiện hấp dẫn nhất, cũng là điều đáng sợ nhất mà anh đã trải qua trong suốt những năm tháng làm ma cà rồng. Khi tìm hiểu thêm các chi tiết lạ lùng trong quá khứ Edward cũng như nội tâm phức tạp của anh, chúng ta sẽ hiểu tại sao đây là cuộc chiến quyết định trong đời Edward. Anh sẽ biện minh cho trái tim mình thế nào nếu yêu Bella cũng đồng nghĩa với việc dẫn cô đến với nguy hiểm?

                Trong Mặt trời lúc nửa đêm, Stephenie Meyer đưa chúng ta trở lại một thế giới đã thu hút hàng triệu độc giả, và mang đến một tiểu thuyết gay cấn về niềm vui và hậu quả tàn khốc của tình yêu bất tử.

                Giá sản phẩm trên Tiki đã bao gồm thuế theo luật hiện hành. Tuy nhiên tuỳ vào từng loại sản phẩm hoặc phương thức, địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như phí vận chuyển, phụ phí hàng cồng kềnh, ...", "SachHay, SachRe", "Mặt Trời Lúc Nửa Đêm", 10000m },
                    { 5, "Eren Yeager", 10, 1, @"Nhà xuất bản Trẻ giới thiệu đến Quý vị tập sách mới trong bộ sách Chạng vạng của tác giả Stephanie Mayer là Mặt trời lúc nửa đêm. Bộ tiểu thuyết Chạng vạng gồm 4 tập là Chạng vạng, Trăng non, Nhật thực, Hừng đông đã thu hút hàng triệu độc giả trên toàn thế giới, trở thành tác phẩm kinh điển định hình lại dòng văn học dành cho bạn đọc trẻ và dấy lên một hiện tượng lạ khiến độc giả khao khát chờ đợi phần tiếp theo. Loạt truyện đã bán được 160 triệu bản ở nhiều quốc gia và dựng thành năm bộ phim bom tấn. Ở Việt Nam, bộ sách cũng đã tạo nên cơn sốt ngay khi phát hành và liên tục bán chạy qua nhiều năm.

                Mặt trời lúc nửa đêm (tựa gốc: Midnight Sun), tập sách mới nhất trong bộ Chạng vạng, cũng đã nối tiếp thành công của các tựa sách trước đó. Chỉ trong tuần đầu phát hành, cuốn sách đã bán ngay được 1 triệu bản ở thị trường Âu – Mỹ.

                Khi Edward Cullen và Bella Swan gặp nhau trong Chạng vạng, một chuyện tình yêu mang tính biểu tượng đã ra đời. Nhưng cho đến bây giờ, người hâm mộ chỉ nghe thấy câu chuyện từ góc nhìn của Bella. Cuối cùng, độc giả đã có thể trải nghiệm phiên bản của Edward trong cuốn tiểu thuyết đồng hành đã được chờ đợi từ lâu, Mặt trời lúc nửa đêm.

                Câu chuyện đen tối này được kể qua đôi mắt của Edward với nhiều mới mẻ và những bước ngoặt quyết định. Gặp gỡ Bella vừa là sự kiện hấp dẫn nhất, cũng là điều đáng sợ nhất mà anh đã trải qua trong suốt những năm tháng làm ma cà rồng. Khi tìm hiểu thêm các chi tiết lạ lùng trong quá khứ Edward cũng như nội tâm phức tạp của anh, chúng ta sẽ hiểu tại sao đây là cuộc chiến quyết định trong đời Edward. Anh sẽ biện minh cho trái tim mình thế nào nếu yêu Bella cũng đồng nghĩa với việc dẫn cô đến với nguy hiểm?

                Trong Mặt trời lúc nửa đêm, Stephenie Meyer đưa chúng ta trở lại một thế giới đã thu hút hàng triệu độc giả, và mang đến một tiểu thuyết gay cấn về niềm vui và hậu quả tàn khốc của tình yêu bất tử.

                Giá sản phẩm trên Tiki đã bao gồm thuế theo luật hiện hành. Tuy nhiên tuỳ vào từng loại sản phẩm hoặc phương thức, địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như phí vận chuyển, phụ phí hàng cồng kềnh, ...", "SachHay, SachRe", "Mặt Trời Lúc Nửa Đêm", 10000m },
                    { 6, "Eren Yeager", 10, 1, @"Nhà xuất bản Trẻ giới thiệu đến Quý vị tập sách mới trong bộ sách Chạng vạng của tác giả Stephanie Mayer là Mặt trời lúc nửa đêm. Bộ tiểu thuyết Chạng vạng gồm 4 tập là Chạng vạng, Trăng non, Nhật thực, Hừng đông đã thu hút hàng triệu độc giả trên toàn thế giới, trở thành tác phẩm kinh điển định hình lại dòng văn học dành cho bạn đọc trẻ và dấy lên một hiện tượng lạ khiến độc giả khao khát chờ đợi phần tiếp theo. Loạt truyện đã bán được 160 triệu bản ở nhiều quốc gia và dựng thành năm bộ phim bom tấn. Ở Việt Nam, bộ sách cũng đã tạo nên cơn sốt ngay khi phát hành và liên tục bán chạy qua nhiều năm.

                Mặt trời lúc nửa đêm (tựa gốc: Midnight Sun), tập sách mới nhất trong bộ Chạng vạng, cũng đã nối tiếp thành công của các tựa sách trước đó. Chỉ trong tuần đầu phát hành, cuốn sách đã bán ngay được 1 triệu bản ở thị trường Âu – Mỹ.

                Khi Edward Cullen và Bella Swan gặp nhau trong Chạng vạng, một chuyện tình yêu mang tính biểu tượng đã ra đời. Nhưng cho đến bây giờ, người hâm mộ chỉ nghe thấy câu chuyện từ góc nhìn của Bella. Cuối cùng, độc giả đã có thể trải nghiệm phiên bản của Edward trong cuốn tiểu thuyết đồng hành đã được chờ đợi từ lâu, Mặt trời lúc nửa đêm.

                Câu chuyện đen tối này được kể qua đôi mắt của Edward với nhiều mới mẻ và những bước ngoặt quyết định. Gặp gỡ Bella vừa là sự kiện hấp dẫn nhất, cũng là điều đáng sợ nhất mà anh đã trải qua trong suốt những năm tháng làm ma cà rồng. Khi tìm hiểu thêm các chi tiết lạ lùng trong quá khứ Edward cũng như nội tâm phức tạp của anh, chúng ta sẽ hiểu tại sao đây là cuộc chiến quyết định trong đời Edward. Anh sẽ biện minh cho trái tim mình thế nào nếu yêu Bella cũng đồng nghĩa với việc dẫn cô đến với nguy hiểm?

                Trong Mặt trời lúc nửa đêm, Stephenie Meyer đưa chúng ta trở lại một thế giới đã thu hút hàng triệu độc giả, và mang đến một tiểu thuyết gay cấn về niềm vui và hậu quả tàn khốc của tình yêu bất tử.

                Giá sản phẩm trên Tiki đã bao gồm thuế theo luật hiện hành. Tuy nhiên tuỳ vào từng loại sản phẩm hoặc phương thức, địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như phí vận chuyển, phụ phí hàng cồng kềnh, ...", "SachHay, SachRe", "Mặt Trời Lúc Nửa Đêm", 10000m },
                    { 7, "Eren Yeager", 10, 1, @"Nhà xuất bản Trẻ giới thiệu đến Quý vị tập sách mới trong bộ sách Chạng vạng của tác giả Stephanie Mayer là Mặt trời lúc nửa đêm. Bộ tiểu thuyết Chạng vạng gồm 4 tập là Chạng vạng, Trăng non, Nhật thực, Hừng đông đã thu hút hàng triệu độc giả trên toàn thế giới, trở thành tác phẩm kinh điển định hình lại dòng văn học dành cho bạn đọc trẻ và dấy lên một hiện tượng lạ khiến độc giả khao khát chờ đợi phần tiếp theo. Loạt truyện đã bán được 160 triệu bản ở nhiều quốc gia và dựng thành năm bộ phim bom tấn. Ở Việt Nam, bộ sách cũng đã tạo nên cơn sốt ngay khi phát hành và liên tục bán chạy qua nhiều năm.

                Mặt trời lúc nửa đêm (tựa gốc: Midnight Sun), tập sách mới nhất trong bộ Chạng vạng, cũng đã nối tiếp thành công của các tựa sách trước đó. Chỉ trong tuần đầu phát hành, cuốn sách đã bán ngay được 1 triệu bản ở thị trường Âu – Mỹ.

                Khi Edward Cullen và Bella Swan gặp nhau trong Chạng vạng, một chuyện tình yêu mang tính biểu tượng đã ra đời. Nhưng cho đến bây giờ, người hâm mộ chỉ nghe thấy câu chuyện từ góc nhìn của Bella. Cuối cùng, độc giả đã có thể trải nghiệm phiên bản của Edward trong cuốn tiểu thuyết đồng hành đã được chờ đợi từ lâu, Mặt trời lúc nửa đêm.

                Câu chuyện đen tối này được kể qua đôi mắt của Edward với nhiều mới mẻ và những bước ngoặt quyết định. Gặp gỡ Bella vừa là sự kiện hấp dẫn nhất, cũng là điều đáng sợ nhất mà anh đã trải qua trong suốt những năm tháng làm ma cà rồng. Khi tìm hiểu thêm các chi tiết lạ lùng trong quá khứ Edward cũng như nội tâm phức tạp của anh, chúng ta sẽ hiểu tại sao đây là cuộc chiến quyết định trong đời Edward. Anh sẽ biện minh cho trái tim mình thế nào nếu yêu Bella cũng đồng nghĩa với việc dẫn cô đến với nguy hiểm?

                Trong Mặt trời lúc nửa đêm, Stephenie Meyer đưa chúng ta trở lại một thế giới đã thu hút hàng triệu độc giả, và mang đến một tiểu thuyết gay cấn về niềm vui và hậu quả tàn khốc của tình yêu bất tử.

                Giá sản phẩm trên Tiki đã bao gồm thuế theo luật hiện hành. Tuy nhiên tuỳ vào từng loại sản phẩm hoặc phương thức, địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như phí vận chuyển, phụ phí hàng cồng kềnh, ...", null, "Mặt Trời Lúc Nửa Đêm", 10000m },
                    { 8, "Eren Yeager", 10, 1, @"Nhà xuất bản Trẻ giới thiệu đến Quý vị tập sách mới trong bộ sách Chạng vạng của tác giả Stephanie Mayer là Mặt trời lúc nửa đêm. Bộ tiểu thuyết Chạng vạng gồm 4 tập là Chạng vạng, Trăng non, Nhật thực, Hừng đông đã thu hút hàng triệu độc giả trên toàn thế giới, trở thành tác phẩm kinh điển định hình lại dòng văn học dành cho bạn đọc trẻ và dấy lên một hiện tượng lạ khiến độc giả khao khát chờ đợi phần tiếp theo. Loạt truyện đã bán được 160 triệu bản ở nhiều quốc gia và dựng thành năm bộ phim bom tấn. Ở Việt Nam, bộ sách cũng đã tạo nên cơn sốt ngay khi phát hành và liên tục bán chạy qua nhiều năm.

                Mặt trời lúc nửa đêm (tựa gốc: Midnight Sun), tập sách mới nhất trong bộ Chạng vạng, cũng đã nối tiếp thành công của các tựa sách trước đó. Chỉ trong tuần đầu phát hành, cuốn sách đã bán ngay được 1 triệu bản ở thị trường Âu – Mỹ.

                Khi Edward Cullen và Bella Swan gặp nhau trong Chạng vạng, một chuyện tình yêu mang tính biểu tượng đã ra đời. Nhưng cho đến bây giờ, người hâm mộ chỉ nghe thấy câu chuyện từ góc nhìn của Bella. Cuối cùng, độc giả đã có thể trải nghiệm phiên bản của Edward trong cuốn tiểu thuyết đồng hành đã được chờ đợi từ lâu, Mặt trời lúc nửa đêm.

                Câu chuyện đen tối này được kể qua đôi mắt của Edward với nhiều mới mẻ và những bước ngoặt quyết định. Gặp gỡ Bella vừa là sự kiện hấp dẫn nhất, cũng là điều đáng sợ nhất mà anh đã trải qua trong suốt những năm tháng làm ma cà rồng. Khi tìm hiểu thêm các chi tiết lạ lùng trong quá khứ Edward cũng như nội tâm phức tạp của anh, chúng ta sẽ hiểu tại sao đây là cuộc chiến quyết định trong đời Edward. Anh sẽ biện minh cho trái tim mình thế nào nếu yêu Bella cũng đồng nghĩa với việc dẫn cô đến với nguy hiểm?

                Trong Mặt trời lúc nửa đêm, Stephenie Meyer đưa chúng ta trở lại một thế giới đã thu hút hàng triệu độc giả, và mang đến một tiểu thuyết gay cấn về niềm vui và hậu quả tàn khốc của tình yêu bất tử.

                Giá sản phẩm trên Tiki đã bao gồm thuế theo luật hiện hành. Tuy nhiên tuỳ vào từng loại sản phẩm hoặc phương thức, địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như phí vận chuyển, phụ phí hàng cồng kềnh, ...", null, "Mặt Trời Lúc Nửa Đêm", 10000m },
                    { 9, "Eren Yeager", 10, 1, @"Nhà xuất bản Trẻ giới thiệu đến Quý vị tập sách mới trong bộ sách Chạng vạng của tác giả Stephanie Mayer là Mặt trời lúc nửa đêm. Bộ tiểu thuyết Chạng vạng gồm 4 tập là Chạng vạng, Trăng non, Nhật thực, Hừng đông đã thu hút hàng triệu độc giả trên toàn thế giới, trở thành tác phẩm kinh điển định hình lại dòng văn học dành cho bạn đọc trẻ và dấy lên một hiện tượng lạ khiến độc giả khao khát chờ đợi phần tiếp theo. Loạt truyện đã bán được 160 triệu bản ở nhiều quốc gia và dựng thành năm bộ phim bom tấn. Ở Việt Nam, bộ sách cũng đã tạo nên cơn sốt ngay khi phát hành và liên tục bán chạy qua nhiều năm.

                Mặt trời lúc nửa đêm (tựa gốc: Midnight Sun), tập sách mới nhất trong bộ Chạng vạng, cũng đã nối tiếp thành công của các tựa sách trước đó. Chỉ trong tuần đầu phát hành, cuốn sách đã bán ngay được 1 triệu bản ở thị trường Âu – Mỹ.

                Khi Edward Cullen và Bella Swan gặp nhau trong Chạng vạng, một chuyện tình yêu mang tính biểu tượng đã ra đời. Nhưng cho đến bây giờ, người hâm mộ chỉ nghe thấy câu chuyện từ góc nhìn của Bella. Cuối cùng, độc giả đã có thể trải nghiệm phiên bản của Edward trong cuốn tiểu thuyết đồng hành đã được chờ đợi từ lâu, Mặt trời lúc nửa đêm.

                Câu chuyện đen tối này được kể qua đôi mắt của Edward với nhiều mới mẻ và những bước ngoặt quyết định. Gặp gỡ Bella vừa là sự kiện hấp dẫn nhất, cũng là điều đáng sợ nhất mà anh đã trải qua trong suốt những năm tháng làm ma cà rồng. Khi tìm hiểu thêm các chi tiết lạ lùng trong quá khứ Edward cũng như nội tâm phức tạp của anh, chúng ta sẽ hiểu tại sao đây là cuộc chiến quyết định trong đời Edward. Anh sẽ biện minh cho trái tim mình thế nào nếu yêu Bella cũng đồng nghĩa với việc dẫn cô đến với nguy hiểm?

                Trong Mặt trời lúc nửa đêm, Stephenie Meyer đưa chúng ta trở lại một thế giới đã thu hút hàng triệu độc giả, và mang đến một tiểu thuyết gay cấn về niềm vui và hậu quả tàn khốc của tình yêu bất tử.

                Giá sản phẩm trên Tiki đã bao gồm thuế theo luật hiện hành. Tuy nhiên tuỳ vào từng loại sản phẩm hoặc phương thức, địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như phí vận chuyển, phụ phí hàng cồng kềnh, ...", null, "Mặt Trời Lúc Nửa Đêm", 10000m },
                    { 10, "Eren Yeager", 10, 1, @"Nhà xuất bản Trẻ giới thiệu đến Quý vị tập sách mới trong bộ sách Chạng vạng của tác giả Stephanie Mayer là Mặt trời lúc nửa đêm. Bộ tiểu thuyết Chạng vạng gồm 4 tập là Chạng vạng, Trăng non, Nhật thực, Hừng đông đã thu hút hàng triệu độc giả trên toàn thế giới, trở thành tác phẩm kinh điển định hình lại dòng văn học dành cho bạn đọc trẻ và dấy lên một hiện tượng lạ khiến độc giả khao khát chờ đợi phần tiếp theo. Loạt truyện đã bán được 160 triệu bản ở nhiều quốc gia và dựng thành năm bộ phim bom tấn. Ở Việt Nam, bộ sách cũng đã tạo nên cơn sốt ngay khi phát hành và liên tục bán chạy qua nhiều năm.

                Mặt trời lúc nửa đêm (tựa gốc: Midnight Sun), tập sách mới nhất trong bộ Chạng vạng, cũng đã nối tiếp thành công của các tựa sách trước đó. Chỉ trong tuần đầu phát hành, cuốn sách đã bán ngay được 1 triệu bản ở thị trường Âu – Mỹ.

                Khi Edward Cullen và Bella Swan gặp nhau trong Chạng vạng, một chuyện tình yêu mang tính biểu tượng đã ra đời. Nhưng cho đến bây giờ, người hâm mộ chỉ nghe thấy câu chuyện từ góc nhìn của Bella. Cuối cùng, độc giả đã có thể trải nghiệm phiên bản của Edward trong cuốn tiểu thuyết đồng hành đã được chờ đợi từ lâu, Mặt trời lúc nửa đêm.

                Câu chuyện đen tối này được kể qua đôi mắt của Edward với nhiều mới mẻ và những bước ngoặt quyết định. Gặp gỡ Bella vừa là sự kiện hấp dẫn nhất, cũng là điều đáng sợ nhất mà anh đã trải qua trong suốt những năm tháng làm ma cà rồng. Khi tìm hiểu thêm các chi tiết lạ lùng trong quá khứ Edward cũng như nội tâm phức tạp của anh, chúng ta sẽ hiểu tại sao đây là cuộc chiến quyết định trong đời Edward. Anh sẽ biện minh cho trái tim mình thế nào nếu yêu Bella cũng đồng nghĩa với việc dẫn cô đến với nguy hiểm?

                Trong Mặt trời lúc nửa đêm, Stephenie Meyer đưa chúng ta trở lại một thế giới đã thu hút hàng triệu độc giả, và mang đến một tiểu thuyết gay cấn về niềm vui và hậu quả tàn khốc của tình yêu bất tử.

                Giá sản phẩm trên Tiki đã bao gồm thuế theo luật hiện hành. Tuy nhiên tuỳ vào từng loại sản phẩm hoặc phương thức, địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như phí vận chuyển, phụ phí hàng cồng kềnh, ...", null, "Mặt Trời Lúc Nửa Đêm", 10000m }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("7d2e5394-ddc3-4bbc-9ecb-327f2f37ce6c"), new Guid("de8781ce-01a8-1ac1-88ad-99ef6caf6957") },
                    { new Guid("61e1c8dc-a9ae-411e-98d9-110ae7afe2cb"), new Guid("defaac82-a5df-4f59-8b28-f2674cb44f05") },
                    { new Guid("d5388079-d681-444e-8291-99cdf0c71973"), new Guid("5e814bd0-7504-4e1f-8dba-fdf01031cae6") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_UserId",
                table: "Blog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRatings_BookId",
                table: "BookRatings",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRatings_UserId",
                table: "BookRatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BookId",
                table: "CartItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_BookId",
                table: "OrderDetails",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "BookRatings");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
