using Domain.Entity;
using Domain.Repository;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper) : IRequestHandler<UpdateBlogCommand, ErrorOr<bool>>
    {
        public async Task<ErrorOr<bool>> Handle(UpdateBlogCommand command, CancellationToken cancellationToken)
        {
            var blog = mapper.Map<Blog>(command);

            var updatedBlog = await blogRepository.UpdateAsync(blog);

            return updatedBlog;
        }
    }
}
