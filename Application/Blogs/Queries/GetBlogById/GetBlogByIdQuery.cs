using Application.Blogs.Queries.GetAllBlogs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blogs.Queries.GetBlogById;

public record GetBlogByIdQuery(Guid BlogId) : IRequest<BlogsModel>;
