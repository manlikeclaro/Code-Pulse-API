using AutoMapper;
using CodePulse.API.Models;
using CodePulse.API.Models.Dto.BlogPost;
using CodePulse.API.Models.Dto.Category;

namespace CodePulse.API;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<BlogPost, BlogPostDto>().ReverseMap();
    }
}