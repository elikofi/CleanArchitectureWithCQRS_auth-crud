using ErrorOr;
using MediatR;

namespace Application.Authentication.RoleManagement.Commands.MakeSuperAdmin
{
    public record MakeSuperAdminCommand(string Username) : IRequest<ErrorOr<string>>;
}
