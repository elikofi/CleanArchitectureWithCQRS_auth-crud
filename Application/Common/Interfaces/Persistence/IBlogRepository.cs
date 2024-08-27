using Application.Common.Results;
using Domain.Entity;

namespace Application.Common.Interfaces.Persistence
{
    public interface IBlogRepository
    {
        Task<Result<IEnumerable<Blog>>> GetAllBlogsAsync();
        Task<Result<Blog>> GetByIdAsync(Guid id);
        Task<Result<Blog>> CreateAsync(Blog blog);
        Task<Result<bool>> UpdateAsync(Blog blog);
        Task<Result<bool>> DeleteAsync(Guid id);

        Blog? GetByName(string name);
    }
}
