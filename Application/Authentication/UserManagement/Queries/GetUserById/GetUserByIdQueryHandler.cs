using Application.Authentication.Common;
using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using MediatR;

namespace Application.Authentication.UserManagement.Queries.GetUserById
{
    public class GetUserByIdQueryHandler(
        IUserRepository userRepository
        ) : IRequestHandler<GetUserByIdQuery, Result<UserDTO>>
    {
        public async Task<Result<UserDTO>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserByIdAsync( request.Id );

            return Result<UserDTO>.SuccessResult( user );
        }
    }
}
