using ErrorOr;
using MediatR;

namespace Application.Blogs.Commands.DeleteBlog
{
    public record DeleteBlogCommand(Guid Id) : IRequest<ErrorOr<bool>>;
}
