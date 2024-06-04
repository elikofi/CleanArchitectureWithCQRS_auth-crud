using MediatR;

namespace Application.Blogs.Commands.DeleteBlog
{
    public record DeleteBlogCommand(Guid Id) : IRequest<bool>;
}
