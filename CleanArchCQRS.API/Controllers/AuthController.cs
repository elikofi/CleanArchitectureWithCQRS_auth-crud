using Application.Common.Interfaces.Persistence;
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
        public async Task<IActionResult> RegisterUser([FromBody] User model)
        {
            var user = mapper.Map<User>(model);

            return Ok(user);
        }
    }
}
