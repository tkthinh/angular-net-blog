using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Slug" },
                values: new object[,]
                {
                    { new Guid("1f631b09-0d4d-4c3a-ae57-6f0b33b764af"), "Web Development", "web-development" },
                    { new Guid("2c631b09-0d4d-4c3a-ae57-6f0b33b764bf"), "Cloud Computing", "cloud-computing" },
                    { new Guid("3d631b09-0d4d-4c3a-ae57-6f0b33b764cf"), "DevOps", "devops" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Content", "IsPublished", "PublishedDate", "ShortDescription", "Slug", "ThumbnailUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("5e631b09-0d4d-4c3a-ae57-6f0b33b764df"), "John Doe", "# Getting Started with ASP.NET Core\r\n\r\n## Introduction\r\n\r\nASP.NET Core is a cross-platform, high-performance framework for building modern, cloud-enabled applications.\r\n\r\n### Prerequisites\r\n\r\n- .NET SDK\r\n- Visual Studio or VS Code\r\n- Basic C# knowledge\r\n\r\n## Getting Started\r\n\r\nFirst, let's create a new project:\r\n\r\n```csharp\r\ndotnet new webapi -n MyFirstAPI\r\n```\r\n\r\n### Key Features\r\n\r\n1. **Cross-Platform Support**\r\n   - Run on Windows, Linux, and macOS\r\n   - Deploy anywhere\r\n\r\n2. **Built-in Dependency Injection**\r\n   - Clean architecture\r\n   - Testable code\r\n\r\n## Next Steps\r\n\r\nStay tuned for more advanced topics!", true, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A comprehensive guide to building web applications with ASP.NET Core", "getting-started-with-aspnet-core", "https://placeholder.com/aspnet-core.jpg", "Getting Started with ASP.NET Core" },
                    { new Guid("6f631b09-0d4d-4c3a-ae57-6f0b33b764ef"), "Jane Smith", "# Cloud Deployment Strategies\r\n\r\n## Understanding Cloud Deployment\r\n\r\nCloud deployment requires careful planning and consideration of various factors.\r\n\r\n### Common Deployment Models\r\n\r\n#### 1. Blue-Green Deployment\r\n\r\nThis strategy reduces downtime and risk by running two identical environments:\r\n\r\n- Blue environment (current)\r\n- Green environment (new version)\r\n\r\n#### 2. Canary Deployment\r\n\r\nGradually roll out changes to a small subset of users before full deployment.\r\n\r\n## Best Practices\r\n\r\n- Always backup your data\r\n- Use infrastructure as code\r\n- Implement proper monitoring\r\n\r\n### Conclusion\r\n\r\nChoose the right strategy based on your specific needs and requirements.", true, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Learn different approaches to deploying applications in the cloud", "cloud-deployment-strategies", "https://placeholder.com/cloud-deployment.jpg", "Cloud Deployment Strategies" }
                });

            migrationBuilder.InsertData(
                table: "CategoryPost",
                columns: new[] { "CategoriesId", "PostsId" },
                values: new object[,]
                {
                    { new Guid("1f631b09-0d4d-4c3a-ae57-6f0b33b764af"), new Guid("5e631b09-0d4d-4c3a-ae57-6f0b33b764df") },
                    { new Guid("2c631b09-0d4d-4c3a-ae57-6f0b33b764bf"), new Guid("5e631b09-0d4d-4c3a-ae57-6f0b33b764df") },
                    { new Guid("2c631b09-0d4d-4c3a-ae57-6f0b33b764bf"), new Guid("6f631b09-0d4d-4c3a-ae57-6f0b33b764ef") },
                    { new Guid("3d631b09-0d4d-4c3a-ae57-6f0b33b764cf"), new Guid("6f631b09-0d4d-4c3a-ae57-6f0b33b764ef") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryPost",
                keyColumns: new[] { "CategoriesId", "PostsId" },
                keyValues: new object[] { new Guid("1f631b09-0d4d-4c3a-ae57-6f0b33b764af"), new Guid("5e631b09-0d4d-4c3a-ae57-6f0b33b764df") });

            migrationBuilder.DeleteData(
                table: "CategoryPost",
                keyColumns: new[] { "CategoriesId", "PostsId" },
                keyValues: new object[] { new Guid("2c631b09-0d4d-4c3a-ae57-6f0b33b764bf"), new Guid("5e631b09-0d4d-4c3a-ae57-6f0b33b764df") });

            migrationBuilder.DeleteData(
                table: "CategoryPost",
                keyColumns: new[] { "CategoriesId", "PostsId" },
                keyValues: new object[] { new Guid("2c631b09-0d4d-4c3a-ae57-6f0b33b764bf"), new Guid("6f631b09-0d4d-4c3a-ae57-6f0b33b764ef") });

            migrationBuilder.DeleteData(
                table: "CategoryPost",
                keyColumns: new[] { "CategoriesId", "PostsId" },
                keyValues: new object[] { new Guid("3d631b09-0d4d-4c3a-ae57-6f0b33b764cf"), new Guid("6f631b09-0d4d-4c3a-ae57-6f0b33b764ef") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1f631b09-0d4d-4c3a-ae57-6f0b33b764af"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2c631b09-0d4d-4c3a-ae57-6f0b33b764bf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3d631b09-0d4d-4c3a-ae57-6f0b33b764cf"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("5e631b09-0d4d-4c3a-ae57-6f0b33b764df"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("6f631b09-0d4d-4c3a-ae57-6f0b33b764ef"));
        }
    }
}
