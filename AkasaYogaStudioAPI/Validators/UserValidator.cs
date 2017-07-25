using Akasa.Dto.POCOs;
using FluentValidation;

namespace AkasaYogaStudioAPI.Validators
{
    public class UserValidator : AbstractValidator<UserInsertDto>
    {
        public UserValidator()
        {
            RuleFor(reg => reg.Name).NotEmpty();
            RuleFor(reg => reg.Email).NotEmpty().EmailAddress();
        }
    }
}
