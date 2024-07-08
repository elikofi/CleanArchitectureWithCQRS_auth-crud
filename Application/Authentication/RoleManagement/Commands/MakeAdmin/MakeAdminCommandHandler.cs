using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.RoleManagement.Commands.MakeAdmin
{
    public class MakeAdminCommandHandler : IRequestHandler<MakeAdminCommand, ErrorOr<string>>
    {
        public async Task<ErrorOr<string>> Handle(MakeAdminCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
