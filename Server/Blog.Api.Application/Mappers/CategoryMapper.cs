using Blog.Api.Application.Dtos.Categories;
using Blog.Api.Domain;

namespace Blog.Api.Application.Mappers
{
   public static class CategoryMapper
   {
      public static CategoryDto ToDto(this Category category)
      {
         if (category == null)
            throw new ArgumentNullException(nameof(category));

         return new CategoryDto
         {
            Id = category.Id,
            Name = category.Name,
            Slug = category.Slug
         };
      }
   }
}
