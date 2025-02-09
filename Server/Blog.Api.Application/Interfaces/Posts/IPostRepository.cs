using Blog.Api.Domain;

namespace Blog.Api.Application.Interfaces.Posts
{
   public interface IPostRepository
   {
      Task<Post> CreateAsync(Post post);
      Task<IEnumerable<Post>> GetAllAsync();
      Task<Post?> FindByIdAsync(Guid id);
      Task<Post?> UpdateAsync(Post post);
      Task<Post?> DeleteAsync(Guid id);
   }
}
