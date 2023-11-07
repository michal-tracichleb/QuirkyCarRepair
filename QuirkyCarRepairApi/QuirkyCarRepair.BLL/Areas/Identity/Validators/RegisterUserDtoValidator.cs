using FluentValidation;
using QuirkyCarRepair.BLL.Areas.Identity.DTO;
using QuirkyCarRepair.DAL;

namespace QuirkyCarRepair.BLL.Areas.Identity.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(QuirkyCarRepairContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var emainInUse = dbContext.Users.Any(u => u.Email == value);
                if (emainInUse)
                {
                    context.AddFailure("Email", "That email is taken");
                }
            });

            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(x => x.UserName).Custom((value, context) =>
            {
                var userNameInUse = dbContext.Users.Any(u => u.UserName == value);
                if (userNameInUse)
                {
                    context.AddFailure("UserName", "That user name is taken");
                }
            });

            RuleFor(x => x.Password).MinimumLength(6);

            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);
        }
    }
}