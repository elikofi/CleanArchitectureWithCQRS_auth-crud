using Application.Authentication.Common;
using Application.Authentication.RoleManagement.Commands.MakeSuperAdmin;
using Application.Authentication.RoleManagement.Commands.MakeSuperUser;
using Application.Authentication.RoleManagement.Queries;
using Application.Authentication.UserManagement.Commands.Register;
using Application.Authentication.UserManagement.Queries.GetAllUsers;
using Application.Authentication.UserManagement.Queries.GetUserById;
using Application.Authentication.UserManagement.Queries.Login;
using Application.Common.Constants;
using Application.Common.Interfaces.Persistence;
using Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchCQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ISender mediator, IMapper mapper, IMemoryCache cache, ILogger<UserDto> logger) : ApiController
    {
        private const string UsersCacheKey = "UsersList";




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
        //[HttpPost("SeedRoles")]
        //public async Task<IActionResult> SeedRoles()
        //{
        //    var seedRoles = await userRepository.SeedRoles();
        //    return Ok(seedRoles);
        //}

        //GET A USER
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserByUserId(string Id)
        {
            var query = new GetUserByIdQuery(Id);
            var user = await mediator.Send(query);
            if (user is not null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        //GET ALL USERS
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllAppUsers()
        {
            if (cache.TryGetValue(UsersCacheKey, out IEnumerable<UserDto>? users))
            {
                logger.LogInformation("users found in cache.");
            }
            else
            {
                logger.LogInformation("Users not found in cache.");
                users = await mediator.Send(new GetAllUsersQuery());

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(1))
                    .SetPriority(CacheItemPriority.Normal);

                cache.Set(UsersCacheKey, users, cacheEntryOptions);
            }

            
            if(users is not null)
            {
                return Ok(users);
            }

            return NotFound();
        }

        //ROLE MANAGEMENT.
        //MAKE ADMIN COMMAND
        [HttpPost("MakeAdmin")]
        public async Task<IActionResult> MakeUserAdmin(MakeSuperUserCommand command)
        {
            var newAdmin = await mediator.Send(command);

            if (newAdmin.Equals(ConstantResponses.UsernameNotFound))
            {
                return newAdmin.Match(
                newAdmin => NotFound(mapper.Map<string>(newAdmin)), errors => Problem(errors));
            }
            return newAdmin.Match(
                newAdmin => Ok(mapper.Map<string>(newAdmin)), errors => Problem(errors));
        }

        //MAKE SUPER ADMIN
        [HttpPost("MakeSuperAdmin")]
        public async Task<IActionResult> MakeUserSuperAdmin(MakeSuperAdminCommand command)
        {
            var newSuperAdmin = await mediator.Send(command);

            if (newSuperAdmin.Equals(ConstantResponses.UsernameNotFound))
            {

                return newSuperAdmin.Match(
                    newSuperAdmin => NotFound(mapper.Map<string>(newSuperAdmin)), errors => Problem(errors));
            }
            return newSuperAdmin.Match(
                newSuperAdmin => Ok(mapper.Map<string>(newSuperAdmin)), errors => Problem(errors));
        }

        //MAKE SUPER USER
        [HttpPost("MakeSuperUser")]
        public async Task<IActionResult> MakeUserSuperUser(MakeSuperUserCommand command)
        {
            var newSuperUser = await mediator.Send(command);

            if (newSuperUser.Equals(ConstantResponses.UsernameNotFound))
            {

                return newSuperUser.Match(
                    newSuperUser => NotFound(mapper.Map<string>(newSuperUser)), errors => Problem(errors));
            }
            return newSuperUser.Match(
                newSuperUser => Ok(mapper.Map<string>(newSuperUser)), errors => Problem(errors));
        }

        //GET USER ROLES
        [HttpGet("GetUserRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await mediator.Send(new GetAllRolesQuery());
            return roles is not null 
                ? Ok(roles) : BadRequest();
        }
    }
}
//check on getuserbyid