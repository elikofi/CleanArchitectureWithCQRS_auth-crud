using Application.Authentication.RoleManagement.Models;
using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using MapsterMapper;
using MediatR;

namespace Application.Authentication.RoleManagement.Commands.MakeAdmin
{
    public class MakeAdminCommandHandler(IUserRepository userRepository, IMapper mapper) : 
        IRequestHandler<MakeAdminCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(MakeAdminCommand command, CancellationToken cancellationToken)
        {
            var user = mapper.Map<UpdatePermissions>(command);

            return await userRepository.MakeAdminAsync(user);
        }
    }
}
