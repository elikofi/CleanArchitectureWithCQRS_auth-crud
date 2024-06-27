using ErrorOr;
using MediatR;

namespace Application.Authentication.UserManagement.Queries.GetUserById
{
    public record GetUserByIdQuery(string Id) : IRequest<ErrorOr<object>>;
}
