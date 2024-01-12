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
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var emailInUse = dbContext.Users.Any(u => u.Email == value);
                if (emailInUse)
                {
                    context.AddFailure("email", "That email is taken");
                }
            });

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("User name is required.")
                .MinimumLength(6).WithMessage("User name must be at least 6 characters long.");

            RuleFor(x => x.UserName).Custom((value, context) =>
            {
                var userNameInUse = dbContext.Users.Any(u => u.UserName == value);
                if (userNameInUse)
                {
                    context.AddFailure("userName", "That user name is taken");
                }
            });

            RuleFor(x => x.Password)
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(e => e.Password).WithMessage("Passwords do not match.");
        }
    }
}