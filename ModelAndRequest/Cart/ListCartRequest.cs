//Vo Huu Tri - 18521531 UIT
using FluentValidation;
using System.Collections.Generic;

namespace ModelAndRequest.Cart
{
    public class ListCartRequest
    {
        public List<CartRequest> CartRequests { get; set; }
    }

    public class ListCartRequestValidator : AbstractValidator<ListCartRequest>
    {
        public ListCartRequestValidator()
        {
            RuleForEach(x => x.CartRequests).SetValidator(new CartRequestValidator());
        }
    }
}