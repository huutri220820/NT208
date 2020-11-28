using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
