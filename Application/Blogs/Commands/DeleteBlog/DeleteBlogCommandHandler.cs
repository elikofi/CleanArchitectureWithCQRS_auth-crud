using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using MediatR;

namespace Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler(IBlogRepository blogRepository) : IRequestHandler<DeleteBlogCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            return await blogRepository.DeleteAsync(request.Id);
        }
    }
}
 