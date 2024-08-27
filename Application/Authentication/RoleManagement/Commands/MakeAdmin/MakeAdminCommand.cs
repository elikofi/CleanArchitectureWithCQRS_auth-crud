using Application.Common.Results;
using MediatR;

namespace Application.Authentication.RoleManagement.Commands.MakeAdmin
{
    public record MakeAdminCommand(string Username) : IRequest<Result<string>>;
}
