using Blog.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Api.Infrastructure.Data.Config
{
   public class PostConfiguration : IEntityTypeConfiguration<Post>
   {
      public void Configure(EntityTypeBuilder<Post> builder)
      {
         var posts = new List<Post>
            {
                new Post
                {
                    Id = Guid.Parse("5e631b09-0d4d-4c3a-ae57-6f0b33b764df"),
                    Title = "Getting Started with ASP.NET Core",
                    ShortDescription = "A comprehensive guide to building web applications with ASP.NET Core",
                    ThumbnailUrl = "https://placeholder.com/aspnet-core.jpg",
                    Content = @"# Getting Started with ASP.NET Core

## Introduction

ASP.NET Core is a cross-platform, high-performance framework for building modern, cloud-enabled applications.

### Prerequisites

- .NET SDK
- Visual Studio or VS Code
- Basic C# knowledge

## Getting Started

First, let's create a new project:

```csharp
dotnet new webapi -n MyFirstAPI
```

### Key Features

1. **Cross-Platform Support**
   - Run on Windows, Linux, and macOS
   - Deploy anywhere

2. **Built-in Dependency Injection**
   - Clean architecture
   - Testable code

## Next Steps

Stay tuned for more advanced topics!",
                    Slug = "getting-started-with-aspnet-core",
                    PublishedDate = new DateTime(2024, 2, 1),
                    Author = "John Doe",
                    IsPublished = true
                },
                new Post
                {
                    Id = Guid.Parse("6f631b09-0d4d-4c3a-ae57-6f0b33b764ef"),
                    Title = "Cloud Deployment Strategies",
                    ShortDescription = "Learn different approaches to deploying applications in the cloud",
                    ThumbnailUrl = "https://placeholder.com/cloud-deployment.jpg",
                    Content = @"# Cloud Deployment Strategies

## Understanding Cloud Deployment

Cloud deployment requires careful planning and consideration of various factors.

### Common Deployment Models

#### 1. Blue-Green Deployment

This strategy reduces downtime and risk by running two identical environments:

- Blue environment (current)
- Green environment (new version)

#### 2. Canary Deployment

Gradually roll out changes to a small subset of users before full deployment.

## Best Practices

- Always backup your data
- Use infrastructure as code
- Implement proper monitoring

### Conclusion

Choose the right strategy based on your specific needs and requirements.",
                    Slug = "cloud-deployment-strategies",
                    PublishedDate = new DateTime(2024, 2, 15),
                    Author = "Jane Smith",
                    IsPublished = true
                }
            };

         builder.HasData(posts);

         // Configure many-to-many relationship data
         builder.HasMany(p => p.Categories)
             .WithMany(c => c.Posts)
             .UsingEntity(j => j.HasData(
                 new { PostsId = posts[0].Id, CategoriesId = Guid.Parse("1f631b09-0d4d-4c3a-ae57-6f0b33b764af") },
                 new { PostsId = posts[0].Id, CategoriesId = Guid.Parse("2c631b09-0d4d-4c3a-ae57-6f0b33b764bf") },
                 new { PostsId = posts[1].Id, CategoriesId = Guid.Parse("2c631b09-0d4d-4c3a-ae57-6f0b33b764bf") },
                 new { PostsId = posts[1].Id, CategoriesId = Guid.Parse("3d631b09-0d4d-4c3a-ae57-6f0b33b764cf") }
             ));
      }
   }

   public class CategoryConfiguration : IEntityTypeConfiguration<Category>
   {
      public void Configure(EntityTypeBuilder<Category> builder)
      {
         var categories = new List<Category>
            {
                new Category
                {
                    Id = Guid.Parse("1f631b09-0d4d-4c3a-ae57-6f0b33b764af"),
                    Name = "Web Development",
                    Slug = "web-development"
                },
                new Category
                {
                    Id = Guid.Parse("2c631b09-0d4d-4c3a-ae57-6f0b33b764bf"),
                    Name = "Cloud Computing",
                    Slug = "cloud-computing"
                },
                new Category
                {
                    Id = Guid.Parse("3d631b09-0d4d-4c3a-ae57-6f0b33b764cf"),
                    Name = "DevOps",
                    Slug = "devops"
                }
            };

         builder.HasData(categories);
      }
   }
}