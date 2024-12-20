namespace TransportProject.Data.Validations
{
    using FluentValidation;
    using TransportProject.Data.Dtos.UserDtos;

    public class RequestUserDtoValidator : AbstractValidator<RequestUserDto>
    {
        public RequestUserDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .MaximumLength(50).WithMessage("UserName cannot exceed 50 characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .MaximumLength(50).WithMessage("Surname cannot exceed 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.UserType)
                .NotEmpty().WithMessage("UserType is required.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format."); // E.164 format

            RuleFor(x => x.UserActive)
                .NotNull().WithMessage("UserActive must be specified.");

            RuleFor(x => x.Created)
                .NotEmpty().WithMessage("Created date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Created date cannot be in the future.");
        }
    }

}
