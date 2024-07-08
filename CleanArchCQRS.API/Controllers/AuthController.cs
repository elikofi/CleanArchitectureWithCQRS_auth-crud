using Application.Authentication.Common;
using Application.Authentication.RoleManagement.Commands.MakeAdmin;
using Application.Authentication.UserManagement.Commands.Register;
using Application.Authentication.UserManagement.Queries.GetAllUsers;
using Application.Authentication.UserManagement.Queries.GetUserById;
using Application.Authentication.UserManagement.Queries.Login;
using Application.Common.Constants;
using Application.Common.Interfaces.Persistence;
using Contracts.Authentication;
using Domain.Entity;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchCQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ISender mediator, IMapper mapper, IUserRepository userRepository) : ApiController
    {
        //REGISTER
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
        {
            var user = mapper.Map<RegisterUserCommand>(request);

            ErrorOr<string> authResult = await mediator.Send(user);

            return authResult.Match(
                authResult => Ok(mapper.Map<string>(authResult)),
                errors => Problem(errors));

        }

        //LOGIN
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody ] LoginRequest request)
        {
            var query = mapper.Map<LoginQuery>(request);

            var signInResult = await mediator.Send(query);

            return signInResult.Match(
                signInResult => Ok(mapper.Map<AuthenticationResult>(signInResult)),
                errors => Problem(errors));
        }

        //SEEDING ROLES.
        [HttpPost("SeedRoles")]
        public async Task<IActionResult> SeedRoles()
        {
            var seedRoles = await userRepository.SeedRoles();
            return Ok(seedRoles);
        }

        //GET A USER
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserByUserId(GetUserByIdQuery Id)
        {
            var user = await mediator.Send(Id);
            if(user is { })
            {
                return user.Match(
                    user => Ok(mapper.Map<UserDTO>(user)), errors => Problem(errors));
            }
            return NotFound();
        }

        //GET ALL USERS
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllAppUsers(GetAllUsersQuery query)
        {
            var users = await mediator.Send(query);
            if(users is { })
            {
                return Ok(users);
            }

            return NotFound();
        }

        //ROLE MANAGEMENT.
        //MAKE ADMIN COMMAND
        [HttpPost("MakeAdmin")]
        public async Task<IActionResult> MakeUserAdmin(MakeAdminCommand command)
        {
            var newAdmin = await mediator.Send(command);

            if (newAdmin.Equals(ConstantResponses.UsernameNotFound))
            {
                return NotFound();
            }
            return Ok(newAdmin);
        }
    }
}
