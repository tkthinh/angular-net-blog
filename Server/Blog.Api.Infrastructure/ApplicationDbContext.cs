using Blog.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Infrastructure
{
   public class ApplicationDbContext : DbContext
   {
      public ApplicationDbContext(DbContextOptions options) : base(options)
      {
      }

      public DbSet<Post> Posts { get; set; }
      public DbSet<Category> Categories { get; set; }
   }
}
