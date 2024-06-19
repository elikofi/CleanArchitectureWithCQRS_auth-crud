using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Entity;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Authentication.UserManagement.Commands.Register
{
    public class RegisterUserCommandHandler(
                                            IUserRepository userRepository, 
                                            IMapper mapper, 
                                            IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<RegisterUserCommand, ErrorOr<AuthenticationResult>>
    {
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterUserCommand command , CancellationToken cancellationToken)
        {
            if (userRepository.GetUserByEmail(command.Email) is { })
            {
                return Errors.UserError.DuplicateEmail;
            }
            var user = mapper.Map<User>(command);

            var newUser = await userRepository.RegisterAsync(user, UserRoles.ADMIN);

            var token = jwtTokenGenerator.GenerateToken(newUser);


            return new AuthenticationResult(newUser, token);
        }
    }

}
