﻿using Application.Common.Results;
using MediatR;

namespace Application.Authentication.RoleManagement.Commands.MakeSuperAdmin
{
    public record MakeSuperAdminCommand(string Username) : IRequest<Result<string>>;
}
