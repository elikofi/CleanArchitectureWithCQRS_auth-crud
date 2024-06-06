using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogsAsync();
        Task<Blog> GetByIdAsync(Guid id);
        Task<Blog> CreateAsync(Blog blog);
        Task<bool> UpdateAsync(Blog blog);
        Task<bool> DeleteAsync(Guid id);

        Blog? GetByName(string name);
    }
}
