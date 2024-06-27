using ErrorOr;
using MediatR;

namespace Application.Authentication.UserManagement.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ErrorOr<object>>
    {
        public async Task<ErrorOr<object>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
