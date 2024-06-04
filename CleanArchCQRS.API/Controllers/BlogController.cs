using Application.Blogs.Commands.CreateBlog;
using Application.Blogs.Commands.UpdateBlog;
using Application.Blogs.Queries.GetAllBlogs;
using Application.Blogs.Queries.GetBlogById;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchCQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetBlogById")]
        public async Task<IActionResult> GetBlogById(Guid BlogId)
        {
            return Ok(await mediator.Send(new GetBlogByIdQuery(BlogId)));
        }

        [HttpGet("GetAllBlogs")]
        public async Task<IActionResult> GetAllBlogs()
        {
            return Ok(await mediator.Send(new GetBlogsQuery()));
        }

        [HttpPost("CreateNewBlog")]
        public async Task<IActionResult> Create([FromBody] CreateBlogCommand command)
        {
            if(ModelState.IsValid)
            {
                var createdBlog = await mediator.Send(new CreateBlogCommand(command.Name, command.Description, command.Author));
                return Ok(createdBlog);
            }

            return BadRequest();
            
        }

        [HttpPut("UpdateBlogById")]
        public async Task<IActionResult> UpdateBlog([FromBody] UpdateBlogCommand command)
        {
            if(ModelState.IsValid)
            {
                var updateBlog = await mediator.Send(command);

                if (updateBlog)
                {
                    return Ok("Updated!");
                }
                return NoContent();
            }
            return BadRequest();
        }
    }
}
