using Domain.Entity;
using Domain.Repository;
using MapsterMapper;
using MediatR;

namespace Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper) : IRequestHandler<UpdateBlogCommand, bool>
    {
        public async Task<bool> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = mapper.Map<Blog>(request);
            var updateableBlog = await blogRepository.UpdateAsync(blog);

            return updateableBlog;
        }
    }
}
