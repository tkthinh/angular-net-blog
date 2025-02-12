namespace Blog.Api.Domain
{
   public class Post
   {
      public Guid Id { get; set; }
      public required string Title { get; set; }
      public string? ShortDescription { get; set; }
      public string? ThumbnailUrl { get; set; }
      public required string Content { get; set; }
      public required string Slug { get; set; }
      public DateTime PublishedDate { get; set; }
      public required string Author { get; set; }
      public bool IsPublished { get; set; }
      public ICollection<Category> Categories { get; set; }
   }
}
