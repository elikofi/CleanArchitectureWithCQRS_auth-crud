using Application.Authentication.RoleManagement.Models;
using Application.Common.Interfaces.Persistence;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace Application.Authentication.RoleManagement.Commands.MakeAdmin
{
    public class MakeAdminCommandHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<MakeSuperUserCommand, ErrorOr<string>>
    {
        public async Task<ErrorOr<string>> Handle(MakeSuperUserCommand command, CancellationToken cancellationToken)
        {
            var user = mapper.Map<UpdatePermissions>(command);

            return await userRepository.MakeAdminAsync(user);
        }
    }
}
