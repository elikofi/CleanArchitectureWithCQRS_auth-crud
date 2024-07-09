using FluentValidation;

namespace Application.Authentication.RoleManagement.Commands.MakeSuperAdmin
{
    public class MakeSuperAdminCommandValidator : AbstractValidator<MakeSuperAdminCommand>
    {
        public MakeSuperAdminCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}
