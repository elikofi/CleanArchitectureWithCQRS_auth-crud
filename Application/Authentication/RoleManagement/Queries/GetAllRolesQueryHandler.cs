using Application.Authentication.RoleManagement.Models;
using Application.Common.Interfaces.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Authentication.RoleManagement.Queries
{
    public class GetAllRolesQueryHandler(IUserRepository userRepository) : IRequestHandler<GetAllRolesQuery, IEnumerable<IdentityRole>>
    {
        public async Task<IEnumerable<IdentityRole>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            
            return await userRepository.GetRolesAsync();
        }
    }
    
}
