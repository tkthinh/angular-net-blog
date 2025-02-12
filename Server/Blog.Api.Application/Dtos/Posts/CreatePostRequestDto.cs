namespace Blog.Api.Application.Dtos.Posts
{
   public class CreatePostRequestDto
   {
      public required string Title { get; set; }
      public string? ShortDescription { get; set; }
      public string? ThumbnailUrl { get; set; }
      public required string Content { get; set; }
      public required string Slug { get; set; }
      public DateTime PublishedDate { get; set; }
      public required string Author { get; set; }
      public bool IsPublished { get; set; }
      public Guid[] Categories { get; set; }
   }
}

