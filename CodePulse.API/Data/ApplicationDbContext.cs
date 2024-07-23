using CodePulse.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<BlogPost> BlogPosts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = Guid.NewGuid(), Name = "name", UrlHandle = "urlHandle"
            }
        );

        modelBuilder.Entity<BlogPost>().HasData(
            new BlogPost()
            {
                Id = Guid.NewGuid(), Title = "title", ShortDescription = "shortDescription",
                Content = "content", UrlHandle = "urlHandle", FeaturedImgUrl = "featuredUrl",
                DateCreated = DateTime.Now, Author = "author", IsVisible = true
            }
        );
    }
}