using Application.Common.Results;
using Domain.Entity;
using MediatR;

namespace Application.Blogs.Commands.CreateBlog
{
    public record CreateBlogCommand(string Name, string Description, string Author) : IRequest<Result<Blog>>;   
}
