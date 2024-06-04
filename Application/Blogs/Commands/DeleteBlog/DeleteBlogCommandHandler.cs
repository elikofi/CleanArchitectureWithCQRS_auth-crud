using Domain.Repository;
using MediatR;

namespace Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler(IBlogRepository blogRepository) : IRequestHandler<DeleteBlogCommand, bool>
    {
        public async Task<bool> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            return await blogRepository.DeleteAsync(request.Id);
        }
    }
}
 