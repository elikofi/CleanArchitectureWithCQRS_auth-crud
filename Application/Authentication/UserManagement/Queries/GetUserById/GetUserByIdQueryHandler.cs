using Application.Authentication.Common;
using Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace Application.Authentication.UserManagement.Queries.GetUserById
{
    public class GetUserByIdQueryHandler(
        IUserRepository userRepository
        ) : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetUserByIdAsync( request.Id );
        }
    }
}
