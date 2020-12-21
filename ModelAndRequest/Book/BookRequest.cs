//Vo Huu Tri - 18521531 UIT
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ModelAndRequest.Book
{
    public class BookRequest
    {
        public string name { get; set; }
        public string author { get; set; }
        public decimal price { get; set; }
        public decimal? sale { get; set; }
        public int categoryId { get; set; }
        public int available { get; set; }
        public IFormFile image { get; set; }
        public string imageBase64 { get; set; }
        public string descripton { get; set; }
        public string keyword { get; set; }
    }

    public class BookRequestValidation : AbstractValidator<BookRequest>
    {
        public BookRequestValidation()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Ten sach khong duoc de trong");
            RuleFor(x => x.price).NotEmpty().WithMessage("Gia sach khong duoc de trong");
            RuleFor(x => x.categoryId).NotEmpty().WithMessage("Danh muc sach khong duoc de trong");
            RuleFor(x => x.available).NotEmpty().WithMessage("So luong sach khong duoc de trong");
        }
    }
}