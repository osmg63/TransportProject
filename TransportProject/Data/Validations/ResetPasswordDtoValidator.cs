using FluentValidation;
using TransportProject.Data.Dtos.UserDtos;

namespace TransportProject.Data.Validations
{
    public class ResetPasswordDtoValidator : AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordDtoValidator() {
            RuleFor(x => x.Password)
                   .NotEmpty().WithMessage("Password is required.")
                   .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
                   .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                   .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                   .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                   .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
        }





    }
}
