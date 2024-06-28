using Application.Common.Interfaces.Persistence;
using Domain.Entity;
using ErrorOr;
using MediatR;

namespace Application.Authentication.UserManagement.Queries.GetUserById
{
    public class GetUserByIdQueryHandler(
        IUserRepository userRepository
        ) : IRequestHandler<GetUserByIdQuery, ErrorOr<User>>
    {
        public async Task<ErrorOr<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await userRepository.GetUserByIdAsync( request.Id );
        }
    }
}
