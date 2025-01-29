namespace Blog.Api.Application.Dtos.Categories
{
   public class CreateCategoryRequestDto
   {
         public required string Name { get; set; }
         public required string Slug { get; set; }
   }
}
