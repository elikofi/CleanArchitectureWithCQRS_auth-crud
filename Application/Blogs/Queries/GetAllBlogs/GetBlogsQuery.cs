
using Application.Common.Results;
using Domain.Entity;
using MediatR;

namespace Application.Blogs.Queries.GetAllBlogs;

public record GetBlogsQuery : IRequest<Result<IEnumerable<Blog>>>;
