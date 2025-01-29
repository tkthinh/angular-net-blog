namespace Blog.Api.Domain
{
   public class Category
   {
      public Guid Id { get; set; }
      public required string Name { get; set; }
      public required string Slug { get; set; }
   }
}
