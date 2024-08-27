using Application.Authentication.RoleManagement.Models;
using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using MapsterMapper;
using MediatR;

namespace Application.Authentication.RoleManagement.Commands.MakeSuperAdmin
{
    public class MakeSuperAdminCommandHandler(IUserRepository userRepository, IMapper mapper) : 
        IRequestHandler<MakeSuperAdminCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(MakeSuperAdminCommand command, CancellationToken cancellationToken)
        {
            var user =  mapper.Map<UpdatePermissions>(command);

            return await userRepository.MakeSuperAdminAsync(user);
        }
    }
}
