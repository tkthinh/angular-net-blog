using Blog.Api.Application.Dtos.Posts;
using Blog.Api.Domain;

namespace Blog.Api.Application.Mappers
{
   public static class PostMapper
   {
      public static PostDto ToDto(this Post post)
      {
         if (post == null)
            throw new ArgumentNullException(nameof(post));

         return new PostDto
         {
            Id = post.Id,
            Title = post.Title,
            ShortDescription = post.ShortDescription,
            ThumbnailUrl = post.ThumbnailUrl,
            Content = post.Content,
            Slug = post.Slug,
            PublishedDate = post.PublishedDate,
            Author = post.Author,
            IsPublished = post.IsPublished,
            Categories = post.Categories.Select(c => c.ToDto()).ToList()
         };
      }
   }
}
