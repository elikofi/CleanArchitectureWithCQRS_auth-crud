using Application.Authentication.UserManagement.Commands.Register;
using Application.Common.Interfaces.Persistence;
using Contracts.Authentication;
using Domain.Entity;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchCQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator, IMapper mapper, IUserRepository userRepository) : ApiController
    {

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
        {
            var user = mapper.Map<RegisterUserCommand>(request);

            var authResult = await mediator.Send(user);

            return authResult.Match(
                authResult => Ok(mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }

        //SEEDING ROLES.
        [HttpPost("SeedRoles")]
        public async Task<IActionResult> SeedRoles()
        {
            var seedRoles = await userRepository.SeedRoles();
            return Ok(seedRoles);
        }
    }
}
