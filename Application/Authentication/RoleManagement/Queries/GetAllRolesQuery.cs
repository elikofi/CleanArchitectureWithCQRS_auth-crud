using Application.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Authentication.RoleManagement.Queries
{
    public record GetAllRolesQuery() : IRequest<Result<IEnumerable<IdentityRole>>>;
}
