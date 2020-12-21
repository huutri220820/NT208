//Vo Huu Tri - 18521531 UIT
using FluentValidation;
using System;

namespace ModelAndRequest.Rating
{
    public class RatingRequest
    {
        public Guid UserId { get; set; }
        public int BookId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }

    public class RatingRequestValidator : AbstractValidator<RatingRequest>
    {
        public RatingRequestValidator()
        {
            RuleFor(x => x.Rating).NotEmpty().WithMessage("Rating khong duoc de trong");
            RuleFor(x => x.BookId).NotEmpty().WithMessage("BookId khong duoc de trong");

            RuleFor(x => x.Rating).InclusiveBetween(1, 5).WithMessage("Rating nam trong khoan tu 1 sao den 5 sao");
        }
    }
}