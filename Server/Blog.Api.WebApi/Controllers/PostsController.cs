using Blog.Api.Application.Dtos.Posts;
using Blog.Api.Application.Interfaces.Categories;
using Blog.Api.Application.Interfaces.Posts;
using Blog.Api.Application.Mappers;
using Blog.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.WebApi.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class PostsController : ControllerBase
   {
      private readonly IPostRepository postRepository;
      private readonly ICategoryRepository categoryRepository;

      public PostsController(IPostRepository postRepository, ICategoryRepository categoryRepository)
      {
         this.postRepository = postRepository;
         this.categoryRepository = categoryRepository;
      }

      // POST /api/blogs
      [HttpPost]
      public async Task<IActionResult> CreatePost([FromBody] CreatePostRequestDto request)
      {
         // Map DTO to Domain Model
         var post = new Post
         {
            Title = request.Title,
            ShortDescription = request.ShortDescription,
            ThumbnailUrl = request.ThumbnailUrl,
            Content = request.Content,
            Slug = request.Slug,
            PublishedDate = request.PublishedDate,
            Author = request.Author,
            IsPublished = request.IsPublished,
            Categories = new List<Category>()
         };

         foreach(var categoryId in request.Categories)
         {
            var existingCategory = await categoryRepository.FindByIdAsync(categoryId);
            if (existingCategory is not null)
            {
               post.Categories.Add(existingCategory);
            }
         }

         await postRepository.CreateAsync(post);

         // Domain model to DTO
         var response = post.ToDto();
         return Ok(response);
      }

      // GET /api/blogs
      [HttpGet]
      public async Task<IActionResult> GetPosts()
      {
         var posts = await postRepository.GetAllAsync();
         var response = new List<PostDto>();
         foreach (var post in posts)
         {
            response.Add(post.ToDto());
         }
         return Ok(response);
      }

      // GET /api/blogs/{id}
      [HttpGet("{id}")]
      public async Task<IActionResult> GetPostById([FromRoute] Guid id)
      {
         var post = await postRepository.FindByIdAsync(id);
         if (post == null)
         {
            return NotFound();
         }
         var response = post.ToDto();
         return Ok(response);
      }

      // PUT /api/blogs/{id}
      [HttpPut("{id}")]
      public async Task<IActionResult> UpdatePost([FromRoute] Guid id, [FromBody] UpdatePostRequestDto request)
      {
         var post = await postRepository.FindByIdAsync(id);
         if (post == null)
         {
            return NotFound();
         }
         post.Title = request.Title;
         post.ShortDescription = request.ShortDescription;
         post.ThumbnailUrl = request.ThumbnailUrl;
         post.Content = request.Content;
         post.Slug = request.Slug;
         post.PublishedDate = request.PublishedDate;
         post.Author = request.Author;
         post.IsPublished = request.IsPublished;
         await postRepository.UpdateAsync(post);
         return Ok(post.ToDto());
      }

      // DELETE /api/blogs/{id}
      [HttpDelete("{id}")]
      public async Task<IActionResult> DeletePost([FromRoute] Guid id)
      {
         var post = await postRepository.DeleteAsync(id);
         if (post == null)
         {
            return NotFound();
         }
         return Ok(post.ToDto());
      }
   }
}
