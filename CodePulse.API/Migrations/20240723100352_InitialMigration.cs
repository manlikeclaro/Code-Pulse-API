using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodePulse.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlHandle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeaturedImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlHandle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Author", "Content", "DateCreated", "FeaturedImgUrl", "IsVisible", "ShortDescription", "Title", "UrlHandle" },
                values: new object[,]
                {
                    { new Guid("0597f06c-e849-466e-8c74-d78b77e72562"), "John Doe", "Mental health is as important as physical health. Here's why...", new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(677), "images/mental_health.jpg", true, "Promoting mental health awareness in society", "Mental Health Awareness", "mental-health-awareness" },
                    { new Guid("35b58658-a456-4cb1-aa38-8ff1973e0cc6"), "John Doe", "AI is changing the way we approach healthcare. Here’s how...", new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(642), "images/ai_healthcare.jpg", true, "How AI is revolutionizing the healthcare industry", "AI in Healthcare", "ai-in-healthcare" },
                    { new Guid("48408a77-442f-4c4d-ba54-5ae888190c90"), "Jane Smith", "Here are some great tips for staying fit while on the go...", new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(651), "images/fit_travel.jpg", true, "Tips for staying in shape during your travels", "Staying Fit While Traveling", "staying-fit-while-traveling" },
                    { new Guid("53958e53-39a1-4cd4-99db-def174c33281"), "Alice Johnson", "Blockchain technology is changing the digital landscape. Here’s what you need to know...", new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(691), "images/blockchain.jpg", true, "Understanding the basics of blockchain technology", "Blockchain Technology Explained", "blockchain-technology-explained" },
                    { new Guid("8a2dd5a6-b572-4a40-874a-4da70df32022"), "Alice Johnson", "These tech gadgets are going to be huge in 2024...", new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(668), "images/tech_gadgets.jpg", true, "Must-have tech gadgets for the upcoming year", "Tech Gadgets for 2024", "tech-gadgets-2024" },
                    { new Guid("a846e6c5-cb4d-4928-aa72-e7af34544949"), "Jane Smith", "Learn how to keep a balanced diet with these tips...", new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(625), "images/healthy_eating.jpg", true, "Tips for maintaining a balanced diet", "Healthy Eating Habits", "healthy-eating-habits" },
                    { new Guid("b4e0627c-00f1-4a3e-8d89-72c9f0be400c"), "Alice Johnson", "Discover the most amazing travel destinations for the upcoming year...", new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(634), "images/travel_destinations.jpg", true, "Explore the best travel spots for 2024", "Top 10 Travel Destinations for 2024", "top-travel-destinations-2024" },
                    { new Guid("c554263b-af4b-4d10-b34c-605f35b36ed2"), "John Doe", "These recipes are quick, easy, and healthy, perfect for a busy lifestyle...", new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(698), "images/healthy_recipes.jpg", true, "Quick and healthy recipes for a busy lifestyle", "Healthy Recipes for Busy People", "healthy-recipes-for-busy-people" },
                    { new Guid("d7078819-235c-4fb2-b8fd-c5420f01b2dd"), "John Doe", "In-depth analysis of upcoming AI technologies...", new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(592), "images/ai_future.jpg", true, "Exploring the future trends in AI", "The Future of AI", "the-future-of-ai" },
                    { new Guid("f118fd7e-8883-4664-8115-714a2fece73c"), "Jane Smith", "Solo travel can be a rewarding experience. Here’s how to make the most of it...", new DateTime(2024, 7, 23, 13, 3, 51, 749, DateTimeKind.Local).AddTicks(684), "images/solo_travel.jpg", true, "How to make the most of your solo trips", "Solo Travel Tips", "solo-travel-tips" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "UrlHandle" },
                values: new object[,]
                {
                    { new Guid("54f4c01b-c663-4890-9acc-5de9ae452729"), "Health", "health" },
                    { new Guid("a5af0e0d-29a0-4f01-9a8f-9aa0203858f6"), "Travel", "travel" },
                    { new Guid("e42e771d-1d95-40c6-8288-588d2f56fc6c"), "Technology", "technology" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
