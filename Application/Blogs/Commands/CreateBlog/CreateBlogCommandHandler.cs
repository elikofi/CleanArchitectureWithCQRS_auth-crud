using Domain.Common.Errors;
using Domain.Entity;
using Domain.Repository;
using ErrorOr;
using MapsterMapper;
using MediatR;
namespace Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper) : IRequestHandler<CreateBlogCommand, ErrorOr<Blog>>
    {
       
        public async Task<ErrorOr<Blog>> Handle(CreateBlogCommand command, CancellationToken cancellationToken)
        {
            //await Task.CompletedTask;
            //if (blogRepository.GetByName(command.Name) is not null)
            //{
            //    return Errors.BlogError.DuplicateBlogName;
            //}

            var blog = mapper.Map<Blog>(command);

            var newBlog = await blogRepository.CreateAsync(blog);

            return newBlog;
        }
    }
}
