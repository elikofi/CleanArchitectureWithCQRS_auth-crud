using Application.Blogs.Queries.GetAllBlogs;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Blogs.Commands.CreateBlog
{
    public record CreateBlogCommand(string Name, string Description, string Author) : IRequest<Blog>;   
}
