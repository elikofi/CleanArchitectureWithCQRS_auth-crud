using Application.Authentication.RoleManagement.Models;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.RoleManagement.Commands.MakeAdmin
{
    public record MakeAdminCommand(UpdatePermissions Username) : IRequest<ErrorOr<string>>;
}
