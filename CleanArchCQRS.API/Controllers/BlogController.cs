using Application.Blogs.Commands.CreateBlog;
using Application.Blogs.Commands.UpdateBlog;
using Application.Blogs.Queries.GetAllBlogs;
using Application.Blogs.Queries.GetBlogById;
using Domain.Entity;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Contracts.Blogs;
using Application.Blogs.Commands.DeleteBlog;
using Microsoft.AspNetCore.Authorization;
using Application.Authentication.Common;
using Microsoft.IdentityModel.Tokens;

namespace CleanArchCQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogController(IMediator mediator, IMapper mapper) : ApiController
    {

        [HttpGet("GetBlogById")]
        public async Task<IActionResult> GetBlogById(GetBlogByIdRequest request)
        {
            var command = mapper.Map<GetBlogByIdQuery>(request);
            var req = await mediator.Send(command);
            return req.Match(req => Ok(mapper.Map<BlogsModel>(req)), errors => Problem(errors));
            
        }

        [HttpGet("GetAllBlogs")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogList = await mediator.Send(new GetBlogsQuery());
            if (blogList.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(blogList);
        }

        [HttpPost("CreateNewBlog")]
        public async Task<IActionResult> Create([FromBody] CreateBlogRequest request)
        {
            if (ModelState.IsValid)
            {
                var command = mapper.Map<CreateBlogCommand>(request);

                ErrorOr<Blog> blog = await mediator.Send(command);

                return blog.Match(blog => Ok(mapper.Map<Blog>(blog)), errors => Problem(errors));
            }

            return BadRequest();

        }

        [HttpPut("UpdateBlogById")]
        public async Task<IActionResult> UpdateBlog([FromBody] UpdateBlogRequest request)
        {
            if (ModelState.IsValid)
            {
                var command = mapper.Map<UpdateBlogCommand>(request);

                ErrorOr<bool> updateBlog = await mediator.Send(command);
                 
                return updateBlog.Match(updateBlog => Ok(mapper.Map<bool>(updateBlog)), errors => Problem(errors));

            }
            return BadRequest();
        }
        [HttpDelete("DeleteById")]
        public async Task<IActionResult> DeleteById([FromBody]DeleteBlogRequest request)
        {
            var command = mapper.Map<DeleteBlogCommand>(request);

            ErrorOr<bool> deletedBlog = await mediator.Send(command);


            return deletedBlog.Match(deletedBlog => Ok(mapper.Map<bool>(deletedBlog)), errors => Problem(errors));
        }
    }
}
