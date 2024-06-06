using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository.Blogs
{
    public class BlogRepository(DatabaseContext context) : IBlogRepository
    {
        public async Task<Blog> CreateAsync(Blog blog)
        {
            await context.Blogs.AddAsync(blog);
            await context.SaveChangesAsync();

            return blog;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var blog = await context.Blogs.FindAsync(id);
            if (blog == null) { return false; }
             context.Blogs.Remove(blog);
            context.SaveChanges();
            return true;
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await context.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(Guid id)
        {
            var blog = await context.Blogs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return blog!;
        }

        public Blog? GetByName(string name)
        {
            return context.Blogs.SingleOrDefault(x => x.Name == name);
        }

        public async Task<bool> UpdateAsync(Blog blog)
        {
            try
            {
                if (blog is null)
                    throw new ArgumentNullException(nameof(blog), "Blog object cannot be null.");

                context.Blogs.Update(blog);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }

            

        }
    }
}
