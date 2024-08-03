using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using Domain.Common.Errors;
using MediatR;

namespace Application.Authentication.UserManagement.Queries.Login
{
    public class LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator tokenGenerator) : IRequestHandler<LoginQuery, Result<AuthenticationResult>>
    {
        public async Task<Result<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            
            var signIn = await userRepository.LoginAsync(query.UserName, query.Password);

            var token = tokenGenerator.GenerateToken(signIn);

            var authResult = new AuthenticationResult(signIn, token);

            return Result<AuthenticationResult>.SuccessResult(authResult);
        }
    }
}
