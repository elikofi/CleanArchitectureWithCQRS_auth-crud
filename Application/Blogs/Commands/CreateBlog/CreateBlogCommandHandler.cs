using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using Domain.Entity;
using MapsterMapper;
using MediatR;
namespace Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper) : IRequestHandler<CreateBlogCommand, Result<Blog>>
    {
       
        public async Task<Result<Blog>> Handle(CreateBlogCommand command, CancellationToken cancellationToken)
        {
           
            var blog = mapper.Map<Blog>(command);

            return await blogRepository.CreateAsync(blog);
        }
    }
}
