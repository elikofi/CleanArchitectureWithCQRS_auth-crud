using Application.Blogs.Commands.CreateBlog;
using Application.Blogs.Commands.UpdateBlog;
using Application.Blogs.Queries.GetAllBlogs;
using Application.Blogs.Queries.GetBlogById;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Contracts.Blogs;
using Application.Blogs.Commands.DeleteBlog;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchCQRS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController(IMediator mediator, IMapper mapper) : ControllerBase
    {

        [HttpGet("GetBlogById")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetBlogById(Guid Id)
        {
            var query = new GetBlogByIdQuery(Id);

            var blog = await mediator.Send(query);

            if(blog.Success is false)
            {
                return NotFound(blog.ErrorMessage);
            }

            return Ok(blog);
            
        }

        [HttpGet("GetAllBlogs")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogList = await mediator.Send(new GetBlogsQuery());
            if (blogList.Success is false)
            {
                return NotFound(blogList.ErrorMessage);
            }
            return Ok(blogList);
        }

        [HttpPost("CreateNewBlog")]
        public async Task<IActionResult> Create([FromBody] CreateBlogRequest request)
        {
            if (ModelState.IsValid)
            {
                var command = mapper.Map<CreateBlogCommand>(request);

                var blog = await mediator.Send(command);

                if(blog.Success is true)
                {
                    return Ok(blog);
                }
                return BadRequest(blog.ErrorMessage);
                
            }

            return BadRequest();

        }

        [HttpPut("UpdateBlogById")]
        public async Task<IActionResult> UpdateBlog([FromBody] UpdateBlogRequest request)
        {
            if (ModelState.IsValid)
            {
                var command = mapper.Map<UpdateBlogCommand>(request);

                var updateBlog = await mediator.Send(command);
                
                if(updateBlog.Success is true)
                {
                    return Ok(updateBlog.Success);
                }
                return BadRequest(updateBlog.ErrorMessage);

            }
            return BadRequest();
        }
        [HttpDelete("DeleteById")]
        public async Task<IActionResult> DeleteById([FromBody]DeleteBlogRequest request)
        {
            var command = mapper.Map<DeleteBlogCommand>(request);

            var deletedBlog = await mediator.Send(command);

            if (deletedBlog.Success is true)
            {
                return Ok();
            }
            
            return BadRequest();
        }
    }
}
