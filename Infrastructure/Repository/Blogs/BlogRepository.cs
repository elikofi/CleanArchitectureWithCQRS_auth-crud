using Application.Common.Constants;
using Application.Common.Interfaces.Persistence;
using Application.Common.Results;
using Domain.Common.Errors;
using Domain.Entity;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository.Blogs
{
    public class BlogRepository(DatabaseContext context, ILogger<Blog> logger) : IBlogRepository
    {
        public async Task<Result<Blog>> CreateAsync(Blog blog)
        {
            try
            {
                var exists = await context.Blogs.AnyAsync(b => b.Name == blog.Name);

                if (exists)
                {
                    return Result<Blog>.ErrorResult(Errors.DuplicateBlogName);
                }

                await context.Blogs.AddAsync(blog);
                var result = await context.SaveChangesAsync();
                if(result > 0)
                {
                    return Result<Blog>.SuccessResult(blog);
                }
                else
                {
                    return Result<Blog>.ErrorResult(ConstantResponses.UnableToCreateBlog);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ConstantResponses.UnableToCreateBlog);
                throw;
            }
        }

        public async Task<Result<bool>> DeleteAsync(Guid id)
        {
            try
            {
                var blog = await context.Blogs.FindAsync(id);

                if (blog is not null)
                {
                    context.Blogs.Remove(blog);
                    context.SaveChanges();

                    return Result<bool>.SuccessResult(true);
                }
                return Result<bool>.ErrorResult(ConstantResponses.UnableToDeleteBlog);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ConstantResponses.UnableToDeleteBlog);
                throw;
            }
        }

        public async Task<Result<IEnumerable<Blog>>> GetAllBlogsAsync()
        {
            try
            {
                var blogList = await context.Blogs.ToListAsync();
                if (blogList != null)
                {
                    return Result<IEnumerable<Blog>>.SuccessResult(blogList);
                }
                return Result<IEnumerable<Blog>>.ErrorResult(ConstantResponses.EmptyBlogList);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ConstantResponses.UnableToGetBlog);
                throw;
            }
        }

        public async Task<Result<Blog>> GetByIdAsync(Guid id)
        {
            var blog = await context.Blogs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            if (blog == null)
            {
                return Result<Blog>.ErrorResult(ConstantResponses.BlogNotFound);
            }
            return Result<Blog> .SuccessResult(blog);
        }

        public Blog? GetByName(string name)
        {
            return context.Blogs.SingleOrDefault(x => x.Name == name);
        }

        public async Task<Result<bool>> UpdateAsync(Blog blog)
        {
            try
            {
                var result = await context.Blogs.FindAsync(blog.Id);

                if (result is not null)
                {
                    context.Blogs.Update(blog);
                    await context.SaveChangesAsync();

                    return Result<bool>.SuccessResult(true);
                }

                return Result<bool>.ErrorResult(ConstantResponses.UnableToUpdateBlog);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ConstantResponses.UnableToUpdateBlog);   
                throw;
            }
        }
    }
}
