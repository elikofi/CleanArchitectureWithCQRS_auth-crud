using Domain.Entity;
using Domain.Repository;
using MapsterMapper;
using MediatR;

namespace Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper) : IRequestHandler<CreateBlogCommand, Blog>
    {
        public async Task<Blog> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = mapper.Map<Blog>(request);

            var newBlog = await blogRepository.CreateAsync(blog);

            return newBlog;
        }
    }
}
