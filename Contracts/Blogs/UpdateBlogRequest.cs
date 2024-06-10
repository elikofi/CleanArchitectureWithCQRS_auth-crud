
namespace Contracts.Blogs
{
    public record UpdateBlogRequest(Guid Id, string Name, string Description, string Author);
}
