using Application.Authentication.RoleManagement.Models;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.RoleManagement.Queries
{
    public record GetAllRolesQuery() : IRequest<IEnumerable<IdentityRole>>;
}
