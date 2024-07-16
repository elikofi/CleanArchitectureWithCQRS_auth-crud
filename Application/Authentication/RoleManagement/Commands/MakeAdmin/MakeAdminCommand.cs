using ErrorOr;
using MediatR;

namespace Application.Authentication.RoleManagement.Commands.MakeAdmin
{
    public record MakeAdminCommand(string Username) : IRequest<ErrorOr<string>>;
}
