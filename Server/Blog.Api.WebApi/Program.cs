using Blog.Api.Application.Interfaces.Categories;
using Blog.Api.Infrastructure;
using Blog.Api.Infrastructure.Repositories.Categories;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
   options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);

builder.Services.AddControllers();
builder.Services.AddCors();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Host.UseSerilog((context, configuration) =>
{
   configuration.ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors(options =>
{
   options.AllowAnyOrigin();
   options.AllowAnyHeader();
   options.AllowAnyMethod();
});

app.MapControllers();

app.Run();
