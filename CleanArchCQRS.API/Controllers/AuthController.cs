using Application.Authentication.UserManagement.Commands.Register;
using Application.Common.Interfaces.Persistence;
using Contracts.Authentication;
using Domain.Entity;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchCQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserRepository userRepository, IMapper mapper) : ApiController
    {

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
        {
            var user = mapper.Map<RegisterUserCommand>(request);

            return Ok(user);
        }
    }
}
