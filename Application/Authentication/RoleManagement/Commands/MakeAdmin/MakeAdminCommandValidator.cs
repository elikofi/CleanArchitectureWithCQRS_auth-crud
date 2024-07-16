using FluentValidation;

namespace Application.Authentication.RoleManagement.Commands.MakeAdmin
{
    public class MakeAdminCommandValidator : AbstractValidator<MakeAdminCommand>
    {
        public MakeAdminCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}
