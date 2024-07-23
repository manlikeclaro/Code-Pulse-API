﻿// <auto-generated />
using System;
using CodePulse.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodePulse.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240723100352_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodePulse.API.Models.BlogPost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FeaturedImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlHandle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BlogPosts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d7078819-235c-4fb2-b8fd-c5420f01b2dd"),
                            Author = "John Doe",
                            Content = "In-depth analysis of upcoming AI technologies...",
                            DateCreated = new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(592),
                            FeaturedImgUrl = "images/ai_future.jpg",
                            IsVisible = true,
                            ShortDescription = "Exploring the future trends in AI",
                            Title = "The Future of AI",
                            UrlHandle = "the-future-of-ai"
                        },
                        new
                        {
                            Id = new Guid("a846e6c5-cb4d-4928-aa72-e7af34544949"),
                            Author = "Jane Smith",
                            Content = "Learn how to keep a balanced diet with these tips...",
                            DateCreated = new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(625),
                            FeaturedImgUrl = "images/healthy_eating.jpg",
                            IsVisible = true,
                            ShortDescription = "Tips for maintaining a balanced diet",
                            Title = "Healthy Eating Habits",
                            UrlHandle = "healthy-eating-habits"
                        },
                        new
                        {
                            Id = new Guid("b4e0627c-00f1-4a3e-8d89-72c9f0be400c"),
                            Author = "Alice Johnson",
                            Content = "Discover the most amazing travel destinations for the upcoming year...",
                            DateCreated = new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(634),
                            FeaturedImgUrl = "images/travel_destinations.jpg",
                            IsVisible = true,
                            ShortDescription = "Explore the best travel spots for 2024",
                            Title = "Top 10 Travel Destinations for 2024",
                            UrlHandle = "top-travel-destinations-2024"
                        },
                        new
                        {
                            Id = new Guid("35b58658-a456-4cb1-aa38-8ff1973e0cc6"),
                            Author = "John Doe",
                            Content = "AI is changing the way we approach healthcare. Here’s how...",
                            DateCreated = new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(642),
                            FeaturedImgUrl = "images/ai_healthcare.jpg",
                            IsVisible = true,
                            ShortDescription = "How AI is revolutionizing the healthcare industry",
                            Title = "AI in Healthcare",
                            UrlHandle = "ai-in-healthcare"
                        },
                        new
                        {
                            Id = new Guid("48408a77-442f-4c4d-ba54-5ae888190c90"),
                            Author = "Jane Smith",
                            Content = "Here are some great tips for staying fit while on the go...",
                            DateCreated = new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(651),
                            FeaturedImgUrl = "images/fit_travel.jpg",
                            IsVisible = true,
                            ShortDescription = "Tips for staying in shape during your travels",
                            Title = "Staying Fit While Traveling",
                            UrlHandle = "staying-fit-while-traveling"
                        },
                        new
                        {
                            Id = new Guid("8a2dd5a6-b572-4a40-874a-4da70df32022"),
                            Author = "Alice Johnson",
                            Content = "These tech gadgets are going to be huge in 2024...",
                            DateCreated = new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(668),
                            FeaturedImgUrl = "images/tech_gadgets.jpg",
                            IsVisible = true,
                            ShortDescription = "Must-have tech gadgets for the upcoming year",
                            Title = "Tech Gadgets for 2024",
                            UrlHandle = "tech-gadgets-2024"
                        },
                        new
                        {
                            Id = new Guid("0597f06c-e849-466e-8c74-d78b77e72562"),
                            Author = "John Doe",
                            Content = "Mental health is as important as physical health. Here's why...",
                            DateCreated = new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(677),
                            FeaturedImgUrl = "images/mental_health.jpg",
                            IsVisible = true,
                            ShortDescription = "Promoting mental health awareness in society",
                            Title = "Mental Health Awareness",
                            UrlHandle = "mental-health-awareness"
                        },
                        new
                        {
                            Id = new Guid("f118fd7e-8883-4664-8115-714a2fece73c"),
                            Author = "Jane Smith",
                            Content = "Solo travel can be a rewarding experience. Here’s how to make the most of it...",
                            DateCreated = new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(684),
                            FeaturedImgUrl = "images/solo_travel.jpg",
                            IsVisible = true,
                            ShortDescription = "How to make the most of your solo trips",
                            Title = "Solo Travel Tips",
                            UrlHandle = "solo-travel-tips"
                        },
                        new
                        {
                            Id = new Guid("53958e53-39a1-4cd4-99db-def174c33281"),
                            Author = "Alice Johnson",
                            Content = "Blockchain technology is changing the digital landscape. Here’s what you need to know...",
                            DateCreated = new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(691),
                            FeaturedImgUrl = "images/blockchain.jpg",
                            IsVisible = true,
                            ShortDescription = "Understanding the basics of blockchain technology",
                            Title = "Blockchain Technology Explained",
                            UrlHandle = "blockchain-technology-explained"
                        },
                        new
                        {
                            Id = new Guid("c554263b-af4b-4d10-b34c-605f35b36ed2"),
                            Author = "John Doe",
                            Content = "These recipes are quick, easy, and healthy, perfect for a busy lifestyle...",
                            DateCreated = new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(698),
                            FeaturedImgUrl = "images/healthy_recipes.jpg",
                            IsVisible = true,
                            ShortDescription = "Quick and healthy recipes for a busy lifestyle",
                            Title = "Healthy Recipes for Busy People",
                            UrlHandle = "healthy-recipes-for-busy-people"
                        });
                });

            modelBuilder.Entity("CodePulse.API.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlHandle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e42e771d-1d95-40c6-8288-588d2f56fc6c"),
                            Name = "Technology",
                            UrlHandle = "technology"
                        },
                        new
                        {
                            Id = new Guid("54f4c01b-c663-4890-9acc-5de9ae452729"),
                            Name = "Health",
                            UrlHandle = "health"
                        },
                        new
                        {
                            Id = new Guid("a5af0e0d-29a0-4f01-9a8f-9aa0203858f6"),
                            Name = "Travel",
                            UrlHandle = "travel"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
