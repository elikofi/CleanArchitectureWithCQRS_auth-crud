using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using Domain.Entity;
using MediatR;

namespace Application.Blogs.Queries.GetAllBlogs
{
    public class GetBlogsQueryHandler(IBlogRepository blogRepository) : IRequestHandler<GetBlogsQuery, Result<IEnumerable<Blog>>>
    {

        public async Task<Result<IEnumerable<Blog>>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            return await blogRepository.GetAllBlogsAsync();
        }

    }
}
