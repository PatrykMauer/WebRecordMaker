using FluentValidation;
using RecordMaker.Infrastructure.Commands.Accounts;

namespace RecordMaker.Infrastructure.Validators
{
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress();
        }
    }
}