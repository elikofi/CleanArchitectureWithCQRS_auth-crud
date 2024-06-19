using Application.Common.Interfaces.Persistence;
using Domain.Entity;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.UserManagement.Commands.Register
{
    public class RegisterUserCommandHandler(IUserRepository userRepository , IMapper mapper) : IRequestHandler<RegisterUserCommand, string>
    {
        public async Task<string> Handle(RegisterUserCommand command , CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(command);

            var newUser = await userRepository.RegisterAsync(user, "Admin");

            return newUser;
        }
    }
}
