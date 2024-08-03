using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Entity;
using ErrorOr;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Authentication.UserManagement.Queries.Login
{
    public class LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator tokenGenerator) : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            if (userRepository.GetUserByUsername(query.UserName) is { })
            {
                return Errors.UserError.WrongUsername;
            }
            var signIn = await userRepository.LoginAsync(query.UserName, query.Password);

            var token = tokenGenerator.GenerateToken(signIn);

            return new AuthenticationResult(signIn, token);
        }
    }
}
