using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAndRequest.Account
{
    /// <summary>
    /// update account
    /// </summary>
    public class AccountRequest : AccountModel
    {
        public override bool isMale { get; set; } = false;
        public string password { get; set; }
        public string confirmPassword { get; set; }
    }
    public class AccountRequestRequestValidator : AbstractValidator<AccountRequest>
    { 
        public AccountRequestRequestValidator()
        {

            RuleFor(x => x.id).NotEmpty().WithMessage("User id is required");

            RuleFor(x => x.username).NotEmpty().WithMessage("User name is required");
            
            RuleFor(x => x.fullName).NotEmpty().WithMessage("Full name is required")
                  .MaximumLength(200).WithMessage("Full name can not over 200 characters");

            RuleFor(x => x.dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birthday cannot greater than 100 years");

            RuleFor(x => x.email).NotEmpty().WithMessage("Email is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email format not match");

            RuleFor(x => x.phonenumber).NotEmpty().WithMessage("Phone number is required");

            RuleFor(x => x.address).NotEmpty().WithMessage("Address is required").MaximumLength(200).WithMessage("Address cant not over 200 characters");

            RuleFor(x => x.password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password is at least 6 characters");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.password != request.confirmPassword)
                {
                    context.AddFailure("Confirm password is not match");
                }
            });
        }
    }

}
