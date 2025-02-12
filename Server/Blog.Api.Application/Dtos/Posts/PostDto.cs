using Blog.Api.Application.Dtos.Categories;

namespace Blog.Api.Application.Dtos.Posts
{
   public class PostDto
   {
      public Guid Id { get; set; }
      public string Title { get; set; }
      public string ShortDescription { get; set; }
      public string ThumbnailUrl { get; set; }
      public string Content { get; set; }
      public string Slug { get; set; }
      public DateTime PublishedDate { get; set; }
      public string Author { get; set; }
      public bool IsPublished { get; set; }
      public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
   }
}
