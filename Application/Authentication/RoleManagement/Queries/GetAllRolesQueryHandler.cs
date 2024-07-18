using Application.Authentication.RoleManagement.Models;
using Application.Common.Interfaces.Persistence;
using MediatR;

namespace Application.Authentication.RoleManagement.Queries
{
    public class GetAllRolesQueryHandler(IUserRepository userRepository) : IRequestHandler<GetAllRolesQuery, IEnumerable<Roles>>
    {
        public async Task<IEnumerable<Roles>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            
            return await userRepository.GetRolesAsync();
        }
    }
}
