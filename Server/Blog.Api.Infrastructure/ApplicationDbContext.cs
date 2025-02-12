using Blog.Api.Domain;
using Blog.Api.Infrastructure.Data.Config;
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

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);
         modelBuilder.ApplyConfiguration(new PostConfiguration());
         modelBuilder.ApplyConfiguration(new CategoryConfiguration());
      }
   }
}
