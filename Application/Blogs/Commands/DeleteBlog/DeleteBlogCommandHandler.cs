using Domain.Repository;
using ErrorOr;
using MediatR;

namespace Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler(IBlogRepository blogRepository) : IRequestHandler<DeleteBlogCommand, ErrorOr<bool>>
    {
        public async Task<ErrorOr<bool>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            return await blogRepository.DeleteAsync(request.Id);
        }
    }
}
 