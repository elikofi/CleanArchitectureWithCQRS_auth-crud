using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Authentication.RoleManagement.Queries
{
    public class GetAllRolesQueryHandler(IUserRepository userRepository) : 
        IRequestHandler<GetAllRolesQuery, Result<IEnumerable<IdentityRole>>>
    {
        public async Task<Result<IEnumerable<IdentityRole>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            
            return await userRepository.GetRolesAsync();
        }
    }
    
}
