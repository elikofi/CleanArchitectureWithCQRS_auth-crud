using Application.Authentication.Common;
using Application.Common.Results;
using MediatR;

namespace Application.Authentication.UserManagement.Queries.GetAllUsers
{
    public record GetAllUsersQuery() : IRequest<Result<IEnumerable<UserDTO>>>;
}
