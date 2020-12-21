//Vo Huu Tri - 18521531 UIT
using FluentValidation;

namespace ModelAndRequest.Account
{
    public class LoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool remember { get; set; }
    }

    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.username).NotEmpty();
            RuleFor(x => x.password).NotEmpty();
        }
    }
}