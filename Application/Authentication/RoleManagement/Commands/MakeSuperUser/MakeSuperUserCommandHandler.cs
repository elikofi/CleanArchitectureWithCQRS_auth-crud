using Application.Authentication.RoleManagement.Models;
using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using MapsterMapper;
using MediatR;

namespace Application.Authentication.RoleManagement.Commands.MakeSuperUser
{
    public class MakeSuperUserCommandHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<MakeSuperUserCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(MakeSuperUserCommand command, CancellationToken cancellationToken)
        {
            var user = mapper.Map<UpdatePermissions>(command);

            return await userRepository.MakeSuperUserAsync(user);
        }
    }
}
