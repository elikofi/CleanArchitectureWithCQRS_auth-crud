using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Blogs
{
    public class BlogRepository(DatabaseContext context) : IBlogRepository
    {
        public async Task<Blog> CreateAsync(Blog blog)
        {
            try
            {
                await context.Blogs.AddAsync(blog);
                await context.SaveChangesAsync();
                return blog;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var blog = await context.Blogs.FindAsync(id);

                if (blog is { })
                {
                    context.Blogs.Remove(blog);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            var blogList = await context.Blogs.ToListAsync();
            if(blogList != null)
            {
                return blogList;
            }
            return blogList ?? new();

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
                if (blog is { })
                {
                    context.Blogs.Update(blog);
                    await context.SaveChangesAsync();
                    return true;
                }
                throw new ArgumentNullException(nameof(blog), "Blog object cannot be null.");

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
