using Application.Common.Results;
using Domain.Entity;
using MediatR;

namespace Application.Blogs.Queries.GetBlogById;

public record GetBlogByIdQuery(Guid Id) : IRequest<Result<Blog>>;
