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
                new Book() { Id = 1, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 0, CategoryId = 1, Description = description, KeyWord = "SachHay, SachRe", WeekScore = 10 , Url="1-mat-troi-luc-giua-dem"},
                new Book() { Id = 2, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 0, CategoryId = 1, Description = description, KeyWord = "SachHay, SachRe", MonthScore = 10, Url = "2-mat-troi-luc-giua-dem" },
                new Book() { Id = 3, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 10, CategoryId = 1, Description = description, KeyWord = "SachHay, SachRe", YearScore = 10, Url = "3-mat-troi-luc-giua-dem" },
                new Book() { Id = 4, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 10, CategoryId = 1, Description = description, KeyWord = "SachHay, SachRe", Url = "4-mat-troi-luc-giua-dem" },
                new Book() { Id = 5, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 10, CategoryId = 1, Description = description, KeyWord = "SachHay, SachRe", Url = "5-mat-troi-luc-giua-dem" },
                new Book() { Id = 6, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 10, CategoryId = 1, Description = description, KeyWord = "SachHay, SachRe", Url = "6-mat-troi-luc-giua-dem" },
                new Book() { Id = 7, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 10, CategoryId = 1, Description = description, Url = "7-mat-troi-luc-giua-dem" },
                new Book() { Id = 8, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 10, CategoryId = 1, Description = description, Url = "8-mat-troi-luc-giua-dem" },
                new Book() { Id = 9, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 10, CategoryId = 1, Description = description, Url = "9-mat-troi-luc-giua-dem" },
                new Book() { Id = 10, Name = "Mặt Trời Lúc Nửa Đêm", Author = "Eren Yeager", Price = 10000, Available = 10, CategoryId = 1, Description = description, Url = "10-mat-troi-luc-giua-dem" },
                //Thiếu nhi
                new Book() { Id = 11, Name = "RÈN PHẨM CHẤT DẪN ĐẦU: TINH THẦN ĐOÀN KẾT - ĐÀN TÉP GIẢI CỨU BÁC CHÉP", Author = "Nguyễn Tấn Thanh Trúc", Price = 40000, Available = 50, CategoryId = 3, Description = description, Sale = (float)(float)0.15, BookImage = "https://newshop.vn/public/uploads/products/35618/sach-ren-pham-chat-dan-dau-tinh-than-doan-ket-dan-tep-giai-cuu-bac-chep.jpg", Url= "11-sach-ren-pham-chat-dan-dau-tinh-than-doan-ket-dan-tep-giai-cuu-bac-chep" },
                new Book() { Id = 12, Name = "RÈN PHẨM CHẤT DẪN ĐẦU: TÔN TRỌNG SỰ KHÁC BIỆT - MĂNG VÀ BẮP", Author = "Nguyễn Tấn Thanh Trúc", Price = 40000, Available = 50, CategoryId = 3, Description = description, Sale = (float)0.15, BookImage = "https://newshop.vn/public/uploads/products/35619/sach-ren-pham-chat-dan-dau-ton-trong-su-khac-biet-mang-va-bap.jpg", Url= "12-sach-ren-pham-chat-dan-dau-ton-trong-su-khac-biet-mang-va-bap" },
                new Book() { Id = 13, Name = "RÈN PHẨM CHẤT DẪN ĐẦU: TRUNG THỰC - TRỐNG CHOAI", Author = "Nguyễn Tấn Thanh Trúc", Price = 40000, Available = 50, CategoryId = 3, Description = description, Sale = (float)0.15, BookImage = "https://newshop.vn/public/uploads/products/35621/sach-ren-pham-chat-dan-dau-trung-thuc-trong-choai.jpg", Url= "13-sach-ren-pham-chat-dan-dau-trung-thuc-trong-choai" },
                new Book() { Id = 14, Name = "Trên đường về nhà bà", Author = "Yong-Taik Kim", Price = 65000, Available = 50, CategoryId = 3, Description = description, Sale = (float)0.1, BookImage = "https://newshop.vn/public/uploads/products/35623/sach-tren-duong-ve-nha-ba.jpg", Url= "14-sach-tren-duong-ve-nha-ba" },
                new Book() { Id = 15, Name = "Chú chuột ngựa đáng yêu", Author = "Curtis Norris - Dịch: Vũ Hương Quỳnh", Price = 26000, Available = 50, CategoryId = 3, Description = description, Sale = (float)0.05, BookImage = "https://newshop.vn/public/uploads/products/35586/sach-truyen-doc-cho-hoc-sinh-tieu-hoc-chu-chuot-ngua-dang-yeu.jpg", Url= "15-sach-truyen-doc-cho-hoc-sinh-tieu-hoc-chu-chuot-ngua-dang-yeu" },
                new Book() { Id = 16, Name = "Trận cầu trong dải ngân hà", Author = "Curtis Norris - Dịch: Vũ Hương Quỳnh", Price = 26000, Available = 50, CategoryId = 3, Description = description, Sale = (float)0.05, BookImage = "https://newshop.vn/public/uploads/products/35584/sach-truyen-doc-cho-hoc-sinh-tieu-hoc-tran-cau-trong-dai-ngan-ha.jpg", Url= "16-sach-truyen-doc-cho-hoc-sinh-tieu-hoc-tran-cau-trong-dai-ngan-ha" },
                new Book() { Id = 17, Name = "Chú lính chì dũng cảm", Author = "Andersen - Dịch: Anh Chi", Price = 48000, Available = 50, CategoryId = 3, Description = description, Sale = (float)0.15, BookImage = "https://newshop.vn/public/uploads/products/35580/sach-chu-linh-chi-dung-cam.jpg", Url = "17-sach-chu-linh-chi-dung-cam" },
                new Book() { Id = 18, Name = "Bách khoa toàn thư tiểu học Larousse - Động vật", Author = "Larousse", Price = 145000, Available = 50, CategoryId = 3, Description = description, Sale = (float)0.1, BookImage = "https://newshop.vn/public/uploads/products/35568/sach-bach-khoa-thu-tieu-hoc-larousse-dong-vat.jpg", Url = "18-sach-bach-khoa-thu-tieu-hoc-larousse-dong-vat" },
                new Book() { Id = 19, Name = "Bách khoa toàn thư tiểu học Larousse - Thiên Nhiên",Author = "Larousse", Price = 145000, Available = 50, CategoryId = 3, Description = description, Sale = (float)0.1, BookImage = "https://newshop.vn/public/uploads/products/35566/sach-bach-khoa-thu-tieu-hoc-larousse-thien-nhien.jpg", Url = "19-sach-bach-khoa-thu-tieu-hoc-larousse-thien-nhien" },
                new Book() { Id = 20, Name = "Bách khoa toàn thư tiểu học Larousse - Phương tiện di chuyển",Author = "Larousse", Price = 145000, Available = 50, CategoryId = 3, Description = description, Sale = (float)0.1, BookImage = "https://newshop.vn/public/uploads/products/35570/sach-bach-khoa-thu-tieu-hoc-larousse-phuong-tien-di-chuyen.jpg", Url = "20-sach-bach-khoa-thu-tieu-hoc-larousse-phuong-tien-di-chuyen" },
                //Kinh tế
                new Book() { Id = 21, Name = "Từ Tốt Đến Vĩ Đại", Author = "Jim Collins", Price = 115000, Available = 50, CategoryId = 2, Description = description, Sale = (float)0.4, BookImage = "https://newshop.vn/public/uploads/products/3362/tu-tot-den-vi-dai.jpg", Url = "21-tu-tot-den-vi-dai" },
                new Book() { Id = 22, Name = "Elon Musk: Tesla, Spacex Và Sứ Mệnh Tìm Kiếm Một Tương Lai Ngoài Sức Tưởng Tượng (Tái Bản 2020)", Author = "Ashlee Vance", Price = 239000, Available = 50, CategoryId = 2, Description = description, Sale = (float)0.5, BookImage = "https://newshop.vn/public/uploads/products/3951/elon-musk.gif", Url = "22-elon-musk" },
                new Book() { Id = 23, Name = "Báo Cáo Tài Chính Dưới Góc Nhìn Của Warren Buffett (Tái Bản 2020)", Author = "David Clark & Mary Buffet", Price = 495000, Available = 50, CategoryId = 2, Description = description, Sale = (float)0.35, BookImage = "https://newshop.vn/public/uploads/products/20610/bao-cao-tai-chinh-duoi-goc-nhin-cua-warren-buffett.jpg", Url = "23-bao-cao-tai-chinh-duoi-goc-nhin-cua-warren-buffett" },
                new Book() { Id = 24, Name = "The Customer Rules - 39 Nguyên Tắc Cốt Lõi Để Mang Tới Dịch Vụ Đỉnh Cao", Author = "Lee Cockerell", Price = 139000, Available = 50, CategoryId = 2, Description = description, Sale = (float)0.4, BookImage = "https://newshop.vn/public/uploads/products/30966/sach-the-customer-rules-39-nguyen-tac-cot-loi-de-mang-toi-dich-vu-dinh-cao.jpg" , Url = "24-sach-the-customer-rules-39-nguyen-tac-cot-loi-de-mang-toi-dich-vu-dinh-cao" },
                new Book() { Id = 25, Name = "Khởi Nghiệp 4.0", Author = "Dorie Clark", Price = 139000, Available = 50, CategoryId = 2, Description = description, Sale = (float)0.4, BookImage = "https://newshop.vn/public/uploads/products/9862/khoi-nghiep-40.jpg", Url = "25-khoi-nghiep-40" },
                new Book() { Id = 26, Name = "Dự Án Phượng Hoàng - The Phoenix Project", Author = "Gene Kim, Kevin Behr, George Spafford", Price = 229000, Available = 50, CategoryId = 2, Description = description, Sale = (float)0.3, BookImage = "https://newshop.vn/public/uploads/products/27019/du-an-phuong-hoang-the-phoenix-project-1.jpg", Url = "26-du-an-phuong-hoang-the-phoenix-project" },
                new Book() { Id = 27, Name = "How Business Works - Hiểu Hết Về Kinh Doanh", Author = "Nhiều Tác Giả", Price = 380000, Available = 50, CategoryId = 2, Description = description, Sale = (float)0.17, BookImage = "https://newshop.vn/public/uploads/products/24186/hieu-het-ve-kinh-doanh-1.jpg", Url = "27-hieu-het-ve-kinh-doanh" },
                new Book() { Id = 28, Name = "Hướng Dẫn Căn Bản Về Cách Kiếm Tiền Từ Youtube", Author = "Benji Travis, Sean Canell", Price = 149000, Available = 50, CategoryId = 2, Description = description, Sale = (float)0.4, BookImage = "https://newshop.vn/public/uploads/products/19643/huong-dan-can-ban-ve-cach-kiem-tien-tu-youtube.png", Url = "28-huong-dan-can-ban-ve-cach-kiem-tien-tu-youtube" },
                new Book() { Id = 29, Name = "Khởi Nghiệp Kinh Doanh - Lý Thuyết, Quá Trình, Thực Tiễn",Author = "Donald F Kuratko", Price = 380000, Available = 50, CategoryId = 2, Description = description, Sale = (float)0.2, BookImage = "https://salt.tikicdn.com/cache/w444/ts/product/15/33/bc/5b6bec906c171419e5a5594c88c8c031.png", Url = "29-khoi-nghiep-kinh-doanh" },
                new Book() { Id = 30, Name = "Đừng Bán Bảo Hiểm Hãy Trao Giải Pháp - Sách Gối Đầu Dành Cho Tư Vấn Bảo Hiểm Nhân Thọ (Tái Bản 2020)",Author = "Pilot Nguyễn", Price = 120000, Available = 50, CategoryId = 2, Description = description, Sale = (float)0.2, BookImage = "https://newshop.vn/public/uploads/products/35678/sach-dung-ban-bao-hiem-hay-trao-giai-phap-sach-goi-dau-danh-cho-tu-van-bao-hiem-nhan-tho.jpg", Url = "30-sach-dung-ban-bao-hiem-hay-trao-giai-phap-sach-goi-dau-danh-cho-tu-van-bao-hiem-nhan-tho" },
                //Lịch sử
                new Book() { Id = 31, Name = "Đại việt sử ký toàn thư", Author = "Người dịch: Ngô Đức Thọ, Hoàng Văn Lâu", Price = 690000, Available = 50, CategoryId = 6, Description = description, Sale = (float)0.05, BookImage = "https://newshop.vn/public/uploads/products/15283/dai-viet-su-ky-toan-thu.gif", Url = "31-dai-viet-su-ky-toan-thu" },
                new Book() { Id = 32, Name = "Lịch Sử Văn Minh Thế Giới - Phần X: Rousseau Và Cách Mạng - Tập 1: Nước Pháp Trước Cơn Đại Hồng Thủy", Author = "Will, Ariel Durant", Price = 205000, Available = 50, CategoryId = 6, Description = description, Sale = (float)0.2, BookImage = "https://cdn0.fahasa.com/media/catalog/product/cache/1/thumbnail/362x/9df78eab33525d08d6e5fb8d27136e95/i/m/image_214052.jpg", Url = "32-lich-su-van-minh-the-gioi" },
                new Book() { Id = 33, Name = "Lịch Sử Giao Thương (Tái Bản 2018)", Author = "William J Bernstein", Price = 190000, Available = 50, CategoryId = 6, Description = description, Sale = (float)0.2, BookImage = "https://newshop.vn/public/uploads/products/7815/lich-su-giao-thuong.jpg", Url = "33-lich-su-giao-thuong" },
                new Book() { Id = 34, Name = "Homo Deus - Lược Sử Tương Lai", Author = "Yuval Noah Harari", Price = 150000, Available = 50, CategoryId = 6, Description = description, Sale = (float)0.1, BookImage = "https://newshop.vn/public/uploads/products/11852/luoc-su-tuong-lai-bia.gif", Url = "34-luoc-su-tuong-lai-bia" },
                new Book() { Id = 35, Name = "Nguồn Gốc Văn Minh", Author = "Will Durant", Price = 60000, Available = 50, CategoryId = 6, Description = description, Sale = (float)0.1, BookImage = "https://newshop.vn/public/uploads/products/14931/bia-truoc-nguon-goc-van-minh.jpg", Url = "35-bia-truoc-nguon-goc-van-minh" },
                new Book() { Id = 36, Name = "Lịch Sử Tư Tưởng Nhật Bản", Author = "Thích Thiên Ân", Price = 100000, Available = 50, CategoryId = 6, Description = description, Sale = (float)0.15, BookImage = "https://newshop.vn/public/uploads/products/15800/lich-su-tu-tuong-nhat-ban.jpg", Url = "36-lich-su-tu-tuong-nhat-ban" },
                new Book() { Id = 37, Name = "Lão Tử Đạo Đức Kinh", Author = "NXB TRẺ", Price = 130000, Available = 50, CategoryId = 6, Description = description, Sale = (float)0.15, BookImage = "https://newshop.vn/public/uploads/products/35629/sach-lao-tu-dao-duc-kinh-nxb-tre.jpg", Url = "37-sach-lao-tu-dao-duc-kinh-nxb-tre" },
                new Book() { Id = 38, Name = "LỄ TỤC VÒNG ĐỜI MỘT SỐ NHÓM NGƯỜI KHU VỰC NAM VIỆT NAM", Author = "Đăng Trương - Hoài Thu", Price = 83000, Available = 50, CategoryId = 6, Description = description, Sale = (float)0.1, BookImage = "https://newshop.vn/public/uploads/products/23896/le-tuc-vong-doi-mot-so-nhom-nguoi-khu-vuc-nam-viet-nam-bia.jpg", Url = "38-le-tuc-vong-doi-mot-so-nhom-nguoi-khu-vuc-nam-viet-nam-bia" },
                new Book() { Id = 39, Name = "LÊ MẠT SỰ KÝ: SỰ SUY TÀN CỦA TRIỀU LÊ CUỐI THẾ KỶ XVIII ( BÌA MỀM)",Author = "Nguyễn Duy Chính", Price = 235000, Available = 50, CategoryId = 6, Description = description, Sale = (float)0.2, BookImage = "https://newshop.vn/public/uploads/products/25225/le-mat-su-ky-su-suy-tan-cua-trieu-le-cuoi-the-ky-xviii-bia-mem.jpg", Url = "39-le-mat-su-ky-su-suy-tan-cua-trieu-le-cuoi-the-ky-xviii-bia-mem" },
                new Book() { Id = 40, Name = "Cổ Học Tinh Hoa",Author = "Ôn Như Nguyễn Văn Ngọc, Tử An Trần Lê Nhân", Price = 125000, Available = 50, CategoryId = 6, Description = description, Sale = (float)0.25, BookImage = "https://newshop.vn/public/uploads/products/16233/co-hoc-tinh-hoa-bia-cung.jpg", Url = "40-co-hoc-tinh-hoa-bia-cung" },
                //Khoa học
                new Book() { Id = 41, Name = "Thông điệp của Nước", Author = "Masaru Emoto", Price = 45000, Available = 50, CategoryId = 5, Description = description, Sale = (float)0.19, BookImage = "https://newshop.vn/public/uploads/products/6043/thong-diep-cua-nuoc-masaru-emoto.jpg", Url = "41-thong-diep-cua-nuoc-masaru-emoto" },
                new Book() { Id = 42, Name = "Bí mật của một trí nhớ siêu phàm", Author = "Eran Katz", Price = 119000, Available = 50, CategoryId = 5, Description = description, Sale = (float)0.4, BookImage = "https://newshop.vn/public/uploads/products/2692/bi-mat-cua-mot-tri-nho-sieu-pham-01.jpg", Url = "42-bi-mat-cua-mot-tri-nho-sieu-pham" },
                new Book() { Id = 43, Name = "NHỮNG NHÀ KHOA HỌC TIÊN PHONG - THIÊN ANH HÙNG CA VỀ CÁC KHÁM PHÁ", Author = "Andrew Robinson", Price = 290000, Available = 50, CategoryId = 5, Description = description, Sale = (float)0.15, BookImage = "https://newshop.vn/public/uploads/products/25875/nhung-nha-khoa-hoc-tien-phong-thien-anh-hung-ca-ve-cac-kham-pha.jpg", Url = "43-nhung-nha-khoa-hoc-tien-phong-thien-anh-hung-ca-ve-cac-kham-pha" },
                new Book() { Id = 44, Name = "Các thế giới song song", Author = "Michio Kaku", Price = 128000, Available = 50, CategoryId = 5, Description = description, Sale = (float)0.4, BookImage = "https://cdn0.fahasa.com/media/catalog/product/cache/1/thumbnail/362x/9df78eab33525d08d6e5fb8d27136e95/i/m/image_172027.jpg", Url = "44-cac-the-gioi-song-song" },
                new Book() { Id = 45, Name = "Khoa Học Khám Phá - Dữ liệu lớn", Author = "Viktor Mayer – SchÖnberger & Kenneth Cukier", Price = 140000, Available = 50, CategoryId = 5, Description = description, Sale = (float)0.25, BookImage = "https://newshop.vn/public/uploads/products/24892/khoa-hoc-kham-pha-du-lieu-lon.jpg", Url = "45-khoa-hoc-kham-pha-du-lieu-lon" },
                new Book() { Id = 46, Name = "Vũ trụ trong một nguyên tử", Author = "Dalai Lama", Price = 72000, Available = 50, CategoryId = 5, Description = description, Sale = (float)0.25, BookImage = "https://newshop.vn/public/uploads/products/10403/bia.gif", Url = "46-vu-no-trong-mot-nguyen-tu" },
                new Book() { Id = 47, Name = "Phân tích dữ liệu với R", Author = "Nguyễn Văn Tuấn", Price = 250000, Available = 50, CategoryId = 5, Description = description, Sale = (float)0.25, BookImage = "https://newshop.vn/public/uploads/products/21148/phan-tich-du-lieu-voi-r-hoi-va-dap.jpg", Url = "47-phan-tich-du-lieu-voi-r-hoi-va-dap" },
                new Book() { Id = 48, Name = "Chiếc nút áo của Napoleon", Author = "Penny Le Couteur & Jay Burreson", Price = 150000, Available = 50, CategoryId = 5, Description = description, Sale = (float)0.2, BookImage = "https://newshop.vn/public/uploads/products/11395/napoleon-bia-truoc.jpg", Url = "48-napoleon-bia-truoc" },
                new Book() { Id = 49, Name = "Bách khoa toàn thư - Bách Khoa toàn thư Khoa Học",Author = "DK", Price = 650000, Available = 50, CategoryId = 5, Description = description, Sale = (float)0.31, BookImage = "https://salt.tikicdn.com/cache/w444/media/catalog/producttmp/2b/09/18/125a8d4153fc68ae8ec2a5f44a76f637.png", Url = "49-back-khoa-toan-thu" },
                new Book() { Id = 50, Name = "Tri Thức Về Vạn Vật - Một Thế Giới Trực Quan Chưa Từng Thấy",Author = "DK", Price = 699000, Available = 50, CategoryId = 5, Description = description, Sale = (float)0.4, BookImage = "https://newshop.vn/public/uploads/products/19522/tri-thuc-ve-van-vat-mot-the-gioi-truc-quan-chua-tung-thay.jpg", Url = "50-tri-thuc-ve-van-vat-mot-the-gioi-truc-quan-chua-tung-thay" },
                //Ngoại ngữ
                new Book() { Id = 51, Name = "Vừa lười vừa bận vẫn giỏi Tiếng Anh", Author = "Nguyễn Văn Hiệp", Price = 168000, Available = 50, CategoryId = 4, Description = description, Sale = (float)0.37, BookImage = "https://product.hstatic.net/1000345726/product/sach-vua-luo-vua-ban-van-gioi-tieng-anh-compressor_master.jpg", Url = "51-sach-vua-luo-vua-ban-van-gioi-tieng-anh-compressor_master" },
                new Book() { Id = 52, Name = "Luyện nói Tiếng Anh như người bản ngữ", Author = "A. J. Hoge", Price = 169000, Available = 50, CategoryId = 4, Description = description, Sale = (float)0.3, BookImage = "https://product.hstatic.net/1000345726/product/sach-luyen-noi-tieng-anh-nhu-nguoi-ban-ngu-compressor_master.jpg", Url = "52-sach-luyen-noi-tieng-anh-nhu-nguoi-ban-ngu-compressor_master" },
                new Book() { Id = 53, Name = "Tiếng Hàn cô bản dành cho người mới bắt đầu", Author = "The ChangMi", Price = 72000, Available = 50, CategoryId = 4, Description = description, Sale = (float)0.13, BookImage = "https://katchup.vn/asset/upload/2018/09/Sach-Tu-hoc-tieng-Han-danh-cho-nguoi-moi-bat-dau-Kem-CD-0.jpg", Url = "53-Sach-Tu-hoc-tieng-Han-danh-cho-nguoi-moi-bat-dau-Kem-CD-0" },
                new Book() { Id = 54, Name = "COMBO SÁCH: HẸN HÒ NƯỚC MỸ + NHỮNG BÀI HỌC NGOÀI TRANG SÁCH + HÁT CÙNG NHỮNG VÌ SAO (BỘ 3 CUỐN)", Author = "Nguyễn Nhật Nam", Price = 256000, Available = 50, CategoryId = 4, Description = description, Sale = (float)0.2, BookImage = "https://newshop.vn/public/uploads/products/33523/combo-sach-cua-nguyen-nhat-nam-hen-ho-nuoc-my-nhung-bai-hoc-ngoai-trang-sach-hat-cung-nhung-vi-sao-bo-3-cuon.jpg", Url = "54-combo-sach-cua-nguyen-nhat-nam-hen-ho-nuoc-my-nhung-bai-hoc-ngoai-trang-sach-hat-cung-nhung-vi-sao-bo-3-cuon" },
                new Book() { Id = 55, Name = "Tự học viết Tiếng Nhật 200 chữ Kanji căn bản tập 1", Author = "Eriko Sato", Price = 60000, Available = 50, CategoryId = 4, Description = description, Sale = (float)0.3, BookImage = "https://cdn0.fahasa.com/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/t/u/tu_hoc_viet_tieng_nhat_200_chu_kanji_can_ban_tap_1_1_2018_08_07_11_12_29.JPG", Url = "55-tu_hoc_viet_tieng_nhat_200_chu_kanji" },
                new Book() { Id = 56, Name = "Tập viết Tiếng Nhật căn bản Hiragana", Author = "Mai Ngọc (Chủ biên)", Price = 39000, Available = 50, CategoryId = 4, Description = description, Sale = (float)0.28, BookImage = "https://cdn0.fahasa.com/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/t/_/t_p_viet_ti_ng_nh_t_c_n_b_n_39k_t_i_b_n_.png", Url = "56-tu_hoc_viet_tieng_nhat_200_chu_hiranaga" },
                new Book() { Id = 57, Name = "Luyện Siêu Trí Nhớ Từ Vựng Tiếng Anh Dành Cho Học Sinh THPT Quốc Gia (Tặng Kèm Ebook) (Tái Bản 2018)", Author = " Nguyễn Anh Đức", Price = 198000, Available = 50, CategoryId = 4, Description = description, Sale = (float)0.35, BookImage = "https://cdn0.fahasa.com/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/1/5/1537517941992.jpeg", Url = "57-luyen-tri-nho-tieng-anh" },
                new Book() { Id = 58, Name = "The Langmaster - Luyện Phát Âm Và Đánh Dấu Trọng Âm Tiếng Anh (Tái Bản 2018)", Author = "Trần Mạnh Tường", Price = 95000, Available = 50, CategoryId = 4, Description = description, Sale = (float)0.2, BookImage = "https://cdn0.fahasa.com/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/l/u/luy_n-ph_t-_m-v_-_nh-d_u-tr_ng-_m-ti_ng-anh-95k.jpg", Url = "58-luyen-phat-am-tieng-anh" },
                new Book() { Id = 59, Name = "Grammar For You (Basic) - Bí Quyết Chinh Phục Ngữ Pháp Tiếng Anh Cơ Bản",Author = " Dương Hương", Price = 159000, Available = 50, CategoryId = 4, Description = description, Sale = (float)0.3, BookImage = "https://cdn0.fahasa.com/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/i/m/image_128342.jpg", Url = "59-chinh-phuc-ngu-pham-tieng-anh" },
                new Book() { Id = 60, Name = "Tủ Sách Cùng Con Giỏi Ngoại Ngữ - LET ME KISS IT BETTER! Thổi Phù Cho Hết Đau Nhé!",Author = "June Đỗ", Price = 129000, Available = 50, CategoryId = 4, Description = description, Sale = (float)0.3, BookImage = "https://cdn0.fahasa.com/media/catalog/product/cache/1/image/9df78eab33525d08d6e5fb8d27136e95/i/m/image_180027.jpg", Url = "60-tu-sach-ngoai-ngu" }
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