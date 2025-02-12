using Blog.Api.Application.Interfaces.Posts;
using Blog.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Infrastructure.Repositories.Posts
{
   public class PostRepository : IPostRepository
   {
      private readonly ApplicationDbContext dbContext;

      public PostRepository(ApplicationDbContext dbContext)
      {
         this.dbContext = dbContext;
      }

      public async Task<Post> CreateAsync(Post post)
      {
         await dbContext.Posts.AddAsync(post);
         await dbContext.SaveChangesAsync();

         return post;
      }

      public async Task<Post?> FindByIdAsync(Guid id)
      {
         return await dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
      }

      public async Task<IEnumerable<Post>> GetAllAsync()
      {
         //return await dbContext.Posts.ToListAsync();
         return await dbContext.Posts.Include(x => x.Categories).ToListAsync();

      }

      public async Task<Post?> UpdateAsync(Post post)
      {
         var existingPost = await dbContext.Posts.FirstOrDefaultAsync(x => x.Id == post.Id);
         if (existingPost != null)
         {
            dbContext.Entry(existingPost).CurrentValues.SetValues(post);
            await dbContext.SaveChangesAsync();
            return post;
         }

         return null;
      }

      public async Task<Post?> DeleteAsync(Guid id)
      {
         var existingPost = await dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
         if (existingPost != null)
         {
            dbContext.Posts.Remove(existingPost);
            await dbContext.SaveChangesAsync();
            return existingPost;
         }
         return null;
      }
   }
}
