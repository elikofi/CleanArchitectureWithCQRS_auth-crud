using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Entity;
using ErrorOr;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.UserManagement.Queries.Login
{
    public class LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator tokenGenerator) : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {

            var signIn = await userRepository.LoginAsync(query.UserName, query.Password);

            var token = tokenGenerator.GenerateToken(signIn);

            return new AuthenticationResult(signIn, token);
        }
    }
}
