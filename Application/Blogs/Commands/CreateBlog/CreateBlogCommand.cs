using Domain.Entity;
using ErrorOr;
using MediatR;

namespace Application.Blogs.Commands.CreateBlog
{
    public record CreateBlogCommand(string Name, string Description, string Author) : IRequest<ErrorOr<Blog>>;   
}
