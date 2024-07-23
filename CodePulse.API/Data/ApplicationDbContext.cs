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
                Id = Guid.NewGuid(), Name = "Technology", UrlHandle = "technology"
            },
            new Category
            {
                Id = Guid.NewGuid(), Name = "Health", UrlHandle = "health"
            },
            new Category
            {
                Id = Guid.NewGuid(), Name = "Travel", UrlHandle = "travel"
            }
        );

        modelBuilder.Entity<BlogPost>().HasData(
            new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "The Future of AI",
                ShortDescription = "Exploring the future trends in AI",
                Content = "In-depth analysis of upcoming AI technologies...",
                UrlHandle = "the-future-of-ai",
                FeaturedImgUrl = "images/ai_future.jpg",
                DateCreated = DateTime.Now,
                Author = "John Doe",
                IsVisible = true
            },
            new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "Healthy Eating Habits",
                ShortDescription = "Tips for maintaining a balanced diet",
                Content = "Learn how to keep a balanced diet with these tips...",
                UrlHandle = "healthy-eating-habits",
                FeaturedImgUrl = "images/healthy_eating.jpg",
                DateCreated = DateTime.Now,
                Author = "Jane Smith",
                IsVisible = true
            },
            new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "Top 10 Travel Destinations for 2024",
                ShortDescription = "Explore the best travel spots for 2024",
                Content = "Discover the most amazing travel destinations for the upcoming year...",
                UrlHandle = "top-travel-destinations-2024",
                FeaturedImgUrl = "images/travel_destinations.jpg",
                DateCreated = DateTime.Now,
                Author = "Alice Johnson",
                IsVisible = true
            },
            new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "AI in Healthcare",
                ShortDescription = "How AI is revolutionizing the healthcare industry",
                Content = "AI is changing the way we approach healthcare. Here’s how...",
                UrlHandle = "ai-in-healthcare",
                FeaturedImgUrl = "images/ai_healthcare.jpg",
                DateCreated = DateTime.Now,
                Author = "John Doe",
                IsVisible = true
            },
            new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "Staying Fit While Traveling",
                ShortDescription = "Tips for staying in shape during your travels",
                Content = "Here are some great tips for staying fit while on the go...",
                UrlHandle = "staying-fit-while-traveling",
                FeaturedImgUrl = "images/fit_travel.jpg",
                DateCreated = DateTime.Now,
                Author = "Jane Smith",
                IsVisible = true
            },
            new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "Tech Gadgets for 2024",
                ShortDescription = "Must-have tech gadgets for the upcoming year",
                Content = "These tech gadgets are going to be huge in 2024...",
                UrlHandle = "tech-gadgets-2024",
                FeaturedImgUrl = "images/tech_gadgets.jpg",
                DateCreated = DateTime.Now,
                Author = "Alice Johnson",
                IsVisible = true
            },
            new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "Mental Health Awareness",
                ShortDescription = "Promoting mental health awareness in society",
                Content = "Mental health is as important as physical health. Here's why...",
                UrlHandle = "mental-health-awareness",
                FeaturedImgUrl = "images/mental_health.jpg",
                DateCreated = DateTime.Now,
                Author = "John Doe",
                IsVisible = true
            },
            new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "Solo Travel Tips",
                ShortDescription = "How to make the most of your solo trips",
                Content = "Solo travel can be a rewarding experience. Here’s how to make the most of it...",
                UrlHandle = "solo-travel-tips",
                FeaturedImgUrl = "images/solo_travel.jpg",
                DateCreated = DateTime.Now,
                Author = "Jane Smith",
                IsVisible = true
            },
            new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "Blockchain Technology Explained",
                ShortDescription = "Understanding the basics of blockchain technology",
                Content = "Blockchain technology is changing the digital landscape. Here’s what you need to know...",
                UrlHandle = "blockchain-technology-explained",
                FeaturedImgUrl = "images/blockchain.jpg",
                DateCreated = DateTime.Now,
                Author = "Alice Johnson",
                IsVisible = true
            },
            new BlogPost
            {
                Id = Guid.NewGuid(),
                Title = "Healthy Recipes for Busy People",
                ShortDescription = "Quick and healthy recipes for a busy lifestyle",
                Content = "These recipes are quick, easy, and healthy, perfect for a busy lifestyle...",
                UrlHandle = "healthy-recipes-for-busy-people",
                FeaturedImgUrl = "images/healthy_recipes.jpg",
                DateCreated = DateTime.Now,
                Author = "John Doe",
                IsVisible = true
            }
        );
    }
}