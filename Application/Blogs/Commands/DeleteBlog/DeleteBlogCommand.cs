using Application.Common.Results;
using MediatR;

namespace Application.Blogs.Commands.DeleteBlog
{
    public record DeleteBlogCommand(Guid Id) : IRequest<Result<bool>>;
}
