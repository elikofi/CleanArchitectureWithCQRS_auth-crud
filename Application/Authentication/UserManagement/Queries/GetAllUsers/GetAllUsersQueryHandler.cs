using Application.Authentication.Common;
using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using MediatR;

namespace Application.Authentication.UserManagement.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler(IUserRepository userRepository) : 
        IRequestHandler<GetAllUsersQuery, Result<IEnumerable<UserDTO>>>
    {
        public async Task<Result<IEnumerable<UserDTO>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {
            return await userRepository.GetAllUsersAsync();
        }
    }
}
