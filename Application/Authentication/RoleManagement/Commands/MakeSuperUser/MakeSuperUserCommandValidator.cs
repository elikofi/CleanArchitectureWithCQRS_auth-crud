using FluentValidation;

namespace Application.Authentication.RoleManagement.Commands.MakeSuperUser
{
    public class MakeSuperUserCommandValidator : AbstractValidator<MakeSuperUserCommand>
    {
        public MakeSuperUserCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}
