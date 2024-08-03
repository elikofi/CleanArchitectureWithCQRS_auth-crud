using Application.Common.Results;
using MediatR;


namespace Application.Authentication.UserManagement.Commands.Register
{
    public record RegisterUserCommand(
		string FirstName, 
		string LastName, 
		string Email,
		string UserName,
		string PasswordHash
		) : IRequest<Result<string>>;
}

