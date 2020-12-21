//Vo Huu Tri - 18521531 UIT
using FluentValidation;
using System;

namespace ModelAndRequest.Cart
{
    public class CartRequest
    {
        public int bookId { get; set; }
        public int quantity { get; set; }
    }

    public class CartRequestValidator : AbstractValidator<CartRequest>
    {
        public CartRequestValidator()
        {
            RuleFor(x => x.bookId).NotEmpty().WithMessage("BookId khong duoc de trong");
            RuleFor(x => x.quantity).NotEmpty().WithMessage("Quantity khong duoc de trong");
            RuleFor(x => x.quantity).InclusiveBetween(0, Int32.MaxValue).WithMessage("Quantity phai nhieu hon 0");
        }
    }
}