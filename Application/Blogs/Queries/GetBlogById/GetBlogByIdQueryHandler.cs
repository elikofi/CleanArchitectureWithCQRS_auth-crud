using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using Domain.Entity;
using MediatR;

namespace Application.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQueryHandler(IBlogRepository blogRepository) : IRequestHandler<GetBlogByIdQuery, Result<Blog>>
    {
        public async Task<Result<Blog>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            return await blogRepository.GetByIdAsync(request.Id);
        }
    }
}
