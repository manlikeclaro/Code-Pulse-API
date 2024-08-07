﻿namespace CodePulse.API.Models.Dto.BlogPost;

public class BlogPostDto
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Content { get; set; }
    public string UrlHandle { get; set; }
    public string FeaturedImgUrl { get; set; }
    public DateTime DateCreated { get; set; }
    public string Author { get; set; }
    public bool IsVisible { get; set; }
}