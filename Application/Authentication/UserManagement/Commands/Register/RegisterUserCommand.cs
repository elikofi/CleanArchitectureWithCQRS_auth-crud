using Application.Authentication.Common;
using ErrorOr;
using MediatR;




namespace Application.Authentication.UserManagement.Commands.Register
{
    public record RegisterUserCommand(
		string FirstName, 
		string LastName, 
		string Email,
		string UserName,
		string PasswordHash
		) : IRequest<ErrorOr<string>>;
}

