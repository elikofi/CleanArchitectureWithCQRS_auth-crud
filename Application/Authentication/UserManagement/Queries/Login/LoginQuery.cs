using Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Application.Authentication.UserManagement.Queries.Login
{
    public record LoginQuery(string UserName, string Password) : IRequest<ErrorOr<Object>>;
}
