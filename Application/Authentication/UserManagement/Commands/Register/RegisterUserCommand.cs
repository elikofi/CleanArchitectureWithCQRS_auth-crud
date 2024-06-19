using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authentication.UserManagement.Commands.Register
{
    public record RegisterUserCommand(
		string FirstName, 
		string LastName, 
		string Email,
		string UserName,
		string PasswordHash
		) : IRequest<string>;
}

