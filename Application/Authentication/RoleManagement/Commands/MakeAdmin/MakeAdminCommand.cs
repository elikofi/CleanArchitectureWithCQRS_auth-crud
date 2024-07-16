using ErrorOr;
using MediatR;

namespace Application.Authentication.RoleManagement.Commands.MakeAdmin
{
    public record MakeSuperUserCommand(string Username) : IRequest<ErrorOr<string>>;
}
