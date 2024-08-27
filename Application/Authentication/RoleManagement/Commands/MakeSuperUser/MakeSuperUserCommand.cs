using Application.Common.Results;
using ErrorOr;
using MediatR;

namespace Application.Authentication.RoleManagement.Commands.MakeSuperUser
{
    public record MakeSuperUserCommand(string Username) : IRequest<Result<string>>;
}
