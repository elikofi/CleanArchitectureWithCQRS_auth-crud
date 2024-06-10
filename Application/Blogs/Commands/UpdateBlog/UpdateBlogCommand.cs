using Domain.Entity;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blogs.Commands.UpdateBlog
{
    public record UpdateBlogCommand(Guid Id, string Name, string Description, string Author) : IRequest<ErrorOr<bool>>;
}
