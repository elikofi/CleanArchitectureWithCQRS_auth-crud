using Application.Common.Results;
using MediatR;

namespace Application.Blogs.Commands.UpdateBlog
{
    public record UpdateBlogCommand(Guid Id, string Name, string Description, string Author) : IRequest<Result<bool>>;
}
