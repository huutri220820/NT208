###### Reponsitories BackEnd : https://github.com/huutri220820/NT208

###### Reponsitories FrontEnd : https://github.com/HrqstnElq/my-book-store

### A. Giới thiệu:

Đây là đồ án môn NT208 - Lập trình ứng dụng web

**Các công nghệ sử dụng **

1. ASP.net core: Dùng để tạo ứng dụng web.

   Xem thêm tại : https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-5.0

2. Entity Framework: dùng để xây dựng model giao tiếp với database

   Xem thêm tại : https://entityframeworkcore.com/

3. Swagger: dùng để tạo giao diện nhằm mục đích kiểm thử API

   xem thêm tại : https://swagger.io/

4. Fluentvalidation : dùng để kiểm tra dữ liệu đầu vào

   Xem thêm tại : https://fluentvalidation.net/

### B. Hướng dẫn cài đặt 

**Yêu cầu hệ thống**

1. Hệ điều hành : Windows, Ubuntu, MacOS 
2. Môi trường .net core 3.1: cài đặt tại : https://dotnet.microsoft.com/download/dotnet-core/3.1
3. Microsoft SQL Server 
4. Git

**Các bước cài đặt**

Mở terminal đối với ubuntu, macos; cmd hoặc powershell đối với window 

1. Clone repo 

   > git clone  https://github.com/huutri220820/NT208.git

2. Cài đặt các pakage, nuget cần thiết

   > cd NT208 
   >
   > dotnet restore

3. Khởi chạy 

   - đầu tiên cần phải cài đặt và khởi chạy Microsoft SQL Server
   - sau đó tiến hành chạy các lệnh sau

   > cd WebAPI
   >
   > dotnet run

   Truy cập vào : http://localhost:5000/swagger/index.html

**Chú ý**: Nếu database không được khởi tạo 

Mở Sql Server Configuration Manager --> 

**Nếu bạn muốn đăng nhập vui lòng sử dụng những tài khoản sau :** 

username : user, password : 1 (role user)

username : admin, password : 1 (role admin)

username : sales, password : 1 (role sales)

### C. Cấu trúc thư mục 

├───DataLayer : Chứa các model giao tiếp với và khởi tạo database

├───ModelAndRequest : chứa các class làm model cho request và respone 

├───ServiceLayer : chứa các lớp và interface phục vụ WebAPI thực hiện các chức năng

└───WebAPI : tầng API



