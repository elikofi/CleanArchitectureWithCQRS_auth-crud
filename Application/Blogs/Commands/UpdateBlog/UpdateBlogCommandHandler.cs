using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using Domain.Entity;
using MapsterMapper;
using MediatR;

namespace Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper) : IRequestHandler<UpdateBlogCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(UpdateBlogCommand command, CancellationToken cancellationToken)
        {
            var blog = mapper.Map<Blog>(command);

            return await blogRepository.UpdateAsync(blog);
        }
    }
}
