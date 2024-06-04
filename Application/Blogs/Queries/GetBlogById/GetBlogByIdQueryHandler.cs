using Application.Blogs.Queries.GetAllBlogs;
using Domain.Repository;
using MapsterMapper;
using MediatR;

namespace Application.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQueryHandler(IBlogRepository blogRepository, IMapper mapper) : IRequestHandler<GetBlogByIdQuery, BlogsModel>
    {
        public async Task<BlogsModel> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var findBlog = await blogRepository.GetByIdAsync(request.BlogId);

            var blogList = mapper.Map<BlogsModel>(findBlog);

            return blogList;
        }
    }
}
