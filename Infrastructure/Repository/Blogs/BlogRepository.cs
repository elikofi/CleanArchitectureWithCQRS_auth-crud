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

        public async Task<bool> UpdateAsync(Blog blog)
        {
            var findBlog =  context.Blogs.Find(blog.Id);
            if (findBlog!.Id == blog.Id)
            {
                context.Blogs.Update(blog);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
             
        }
    }
}
