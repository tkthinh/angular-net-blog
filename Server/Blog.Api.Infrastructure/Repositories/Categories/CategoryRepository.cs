using Blog.Api.Application.Interfaces.Categories;
using Blog.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Infrastructure.Repositories.Categories
{
   public class CategoryRepository : ICategoryRepository
   {
      private readonly ApplicationDbContext _dbContext;

      public CategoryRepository(ApplicationDbContext dbContext)
      {
         this._dbContext = dbContext;
      }

      public async Task<Category> CreateAsync(Category category)
      {
         await _dbContext.Categories.AddAsync(category);
         await _dbContext.SaveChangesAsync();

         return category;
      }

      public async Task<IEnumerable<Category>> GetAllAsync()
      {
         return await _dbContext.Categories.ToListAsync();
      }

      public async Task<Category?> UpdateAsync(Category category)
      {
         var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);

         if (existingCategory != null)
         {
            _dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
            await _dbContext.SaveChangesAsync();
            return category;
         }

         return null;
      }

      public async Task<Category?> DeleteAsync(Guid id)
      {
         var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

         if (existingCategory != null)
         {
            _dbContext.Categories.Remove(existingCategory);
            await _dbContext.SaveChangesAsync();
            return existingCategory;
         }

         return null;
      }

      public async Task<Category?> FindByIdAsync(Guid id)
      {
         return await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
      }
   }
}
