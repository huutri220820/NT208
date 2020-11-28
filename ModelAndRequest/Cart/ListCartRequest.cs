using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
