using Application.Authentication.Common;
using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using Domain.Common.Errors;
using Domain.Entity;
using MapsterMapper;
using MediatR;

namespace Application.Authentication.UserManagement.Commands.Register
{
    public class RegisterUserCommandHandler(
                                            IUserRepository userRepository, 
                                            IMapper mapper) : IRequestHandler<RegisterUserCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(RegisterUserCommand command , CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(command);

            var newUser = await userRepository.RegisterAsync(user, UserRoles.USER);

            return Result<string>.SuccessResult(newUser);
        }
    }

}
