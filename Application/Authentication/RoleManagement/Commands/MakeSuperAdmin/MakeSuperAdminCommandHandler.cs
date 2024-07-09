using Application.Authentication.RoleManagement.Models;
using Application.Common.Interfaces.Persistence;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace Application.Authentication.RoleManagement.Commands.MakeSuperAdmin
{
    public class MakeSuperAdminCommandHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<MakeSuperAdminCommand, ErrorOr<string>>
    {
        public async Task<ErrorOr<string>> Handle(MakeSuperAdminCommand command, CancellationToken cancellationToken)
        {
            var user =  mapper.Map<UpdatePermissions>(command);

            return await userRepository.MakeSuperAdminAsync(user);
        }
    }
}
