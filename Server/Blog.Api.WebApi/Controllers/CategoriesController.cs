using Blog.Api.Application.Dtos.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.WebApi.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class CategoriesController : ControllerBase
   {
      [HttpPost]
      public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
      {
         throw new NotImplementedException();
      }
   }
}
