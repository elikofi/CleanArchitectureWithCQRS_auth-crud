using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using Domain.Common.Errors;
using Mapster;
using MapsterMapper;
using MediatR;

namespace Application.Authentication.UserManagement.Queries.Login
{
    public class LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator tokenGenerator, IMapper mapper) : IRequestHandler<LoginQuery, Result<AuthenticationResult>>
    {
        public async Task<Result<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            
            var signIn = await userRepository.LoginAsync(query.UserName, query.Password);

            if(signIn.Success is false)
            {
                return Result<AuthenticationResult>.ErrorResult(signIn.ErrorMessage!);
            }

            var newSignIn = signIn.Data.Adapt<UserDTO>();

            var token = tokenGenerator.GenerateToken(newSignIn);

            var authResult = new AuthenticationResult(newSignIn, token);

            return Result<AuthenticationResult>.SuccessResult(authResult);
        }
    }
}
