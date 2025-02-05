using Blog.Api.Domain;

namespace Blog.Api.Application.Interfaces.Categories
{
   public interface ICategoryRepository
   {
      Task<Category> CreateAsync(Category category);
      Task<IEnumerable<Category>> GetAllAsync();
      Task<Category?> FindByIdAsync(Guid id);
      Task<Category?> UpdateAsync(Category category);
      Task<Category?> DeleteAsync(Guid id);
   }
}
