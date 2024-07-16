using ErrorOr;
using MediatR;

namespace Application.Authentication.RoleManagement.Commands.MakeSuperUser
{
    public record MakeSuperUserCommand(string Username) : IRequest<ErrorOr<string>>;
}
