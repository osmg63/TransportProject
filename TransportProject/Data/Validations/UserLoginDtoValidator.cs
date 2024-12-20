using FluentValidation;
using TransportProject.Data.Dtos.UserDtos;

namespace TransportProject.Data.Validations
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator() { 
        
            RuleFor(x=>x.UserName).NotEmpty();
            RuleFor(x=>x.Password).NotEmpty();
            
        
        
        }
    }
}
