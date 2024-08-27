using Application.Authentication.Common;
using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.UserManagement.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler(IUserRepository userRepository) : 
        IRequestHandler<GetAllUsersQuery, Result<IEnumerable<UserDTO>>>
    {
        public async Task<Result<IEnumerable<UserDTO>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetAllUsersAsync();
        }
    }
}
