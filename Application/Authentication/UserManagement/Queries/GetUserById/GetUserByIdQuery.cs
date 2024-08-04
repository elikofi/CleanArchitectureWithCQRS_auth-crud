using Application.Authentication.Common;
using Application.Common.Results;
using MediatR;

namespace Application.Authentication.UserManagement.Queries.GetUserById
{
    public record GetUserByIdQuery(string Id) : IRequest<Result<UserDTO>>;
}
