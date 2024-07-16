using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.RoleManagement.Commands.MakeAdmin
{
    public class MakeAdminCommandValidator : AbstractValidator<MakeSuperUserCommand>
    {
        public MakeAdminCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}
