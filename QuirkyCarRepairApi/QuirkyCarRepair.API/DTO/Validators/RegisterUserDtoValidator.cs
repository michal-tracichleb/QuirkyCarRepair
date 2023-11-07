using FluentValidation;
using QuirkyCarRepair.BLL.Areas.Identity.DTO;
using QuirkyCarRepair.DAL;

namespace QuirkyCarRepair.API.DTO.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(QuirkyCarRepairContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password).MinimumLength(6);

            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);

            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var emainInUse = dbContext.Users.Any(u => u.Email == value);
                if (emainInUse)
                {
                    context.AddFailure("Email", "That email is taken");
                }
            });
        }
    }
}