using Domain.Entity;
using ErrorOr;
using MediatR;

namespace Application.Blogs.Queries.GetAllBlogs;

public record GetBlogsQuery : IRequest<List<BlogsModel>>;
