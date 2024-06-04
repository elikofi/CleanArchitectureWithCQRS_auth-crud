using Domain.Repository;
using MapsterMapper;
using MediatR;

namespace Application.Blogs.Queries.GetAllBlogs
{
    public class GetBlogsQueryHandler(IBlogRepository blogRepository, IMapper mapper) : IRequestHandler<GetBlogsQuery, List<BlogsModel>>
    {
        public async Task<List<BlogsModel>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var blogs = await blogRepository.GetAllBlogsAsync();

            var bL = mapper.Map<List<BlogsModel>>(blogs);

            return bL;
        }
    }
}
