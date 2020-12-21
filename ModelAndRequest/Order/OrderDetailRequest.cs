//Vo Huu Tri - 18521531 UIT
using FluentValidation;
using ModelAndRequest.Cart;

namespace ModelAndRequest.Order
{
    public class OrderDetailRequest
    {
        public ListCartRequest ListCartRequest { get; set; }
        public OrderRequest OrderRequest { get; set; }
    }

    public class OrderDetailRequestValidator : AbstractValidator<OrderDetailRequest>
    {
        public OrderDetailRequestValidator()
        {
            RuleFor(x => x.ListCartRequest).SetValidator(new ListCartRequestValidator());
            RuleFor(x => x.OrderRequest).SetValidator(new OrderRequestValidator());
        }
    }
}