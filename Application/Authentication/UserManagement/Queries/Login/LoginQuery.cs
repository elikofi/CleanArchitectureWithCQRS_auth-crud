using Application.Authentication.Common;
using Application.Common.Results;
using MediatR;

namespace Application.Authentication.UserManagement.Queries.Login
{
    public record LoginQuery(string UserName, string Password) : IRequest<Result<AuthenticationResult>>;
}
