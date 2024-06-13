using Application.Blogs.Queries.GetAllBlogs;
using Domain.Repository;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace Application.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQueryHandler(IBlogRepository blogRepository, IMapper mapper) : IRequestHandler<GetBlogByIdQuery, ErrorOr<BlogsModel>>
    {
        public async Task<ErrorOr<BlogsModel>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var findBlog = await blogRepository.GetByIdAsync(request.Id);

            var blogList = mapper.Map<BlogsModel>(findBlog);

            return blogList;
        }
    }
}
