using Blog.Api.Application.Dtos.Categories;
using Blog.Api.Application.Interfaces.Categories;
using Blog.Api.Application.Mappers;
using Blog.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.WebApi.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class CategoriesController : ControllerBase
   {
      private readonly ICategoryRepository categoryRepository;

      public CategoriesController(ICategoryRepository categoryRepository)
      {
         this.categoryRepository = categoryRepository;
      }

      // POST /api/categories
      [HttpPost]
      public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto request)
      {
         // Map DTO to Domain Model
         var category = new Category
         {
            Name = request.Name,
            Slug = request.Slug
         };

         await categoryRepository.CreateAsync(category);

         // Domain model to DTO
         var response = category.ToDto();

         return Ok(response);
      }

      // GET /api/categories
      [HttpGet]
      public async Task<IActionResult> GetCategories()
      {
         var categories = await categoryRepository.GetAllAsync();

         var response = new List<CategoryDto>();
         foreach (var category in categories)
         {
            response.Add(category.ToDto());
         }

         return Ok(response);
      }

      //  GET /api/categories/{id}
      [HttpGet("{id}")]
      public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
      {
         var category = await categoryRepository.FindByIdAsync(id);
         if (category == null)
         {
            return NotFound();
         }
         var response = category.ToDto();
         return Ok(response);
      }

      // PUT /api/categories/{id}
      [HttpPut("{id}")]
      public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] UpdateCategoryRequestDto request)
      {
         var category = await categoryRepository.FindByIdAsync(id);
         if (category == null)
         {
            return NotFound();
         }

         category.Name = request.Name;
         category.Slug = request.Slug;
         await categoryRepository.UpdateAsync(category);

         var response = category.ToDto();
         return Ok(response);
      }

      // DELETE /api/categories/{id}
      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
      {
         var category = await categoryRepository.FindByIdAsync(id);
         if (category == null)
         {
            return NotFound();
         }
         await categoryRepository.DeleteAsync(id);
         return Ok();
      }
   }
}
