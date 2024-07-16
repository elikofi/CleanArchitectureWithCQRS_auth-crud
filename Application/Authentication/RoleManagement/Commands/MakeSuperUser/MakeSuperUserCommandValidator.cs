

using Application.Common.Interfaces.Persistence;
using ErrorOr;
using FluentValidation;
using MapsterMapper;
using MediatR;

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
