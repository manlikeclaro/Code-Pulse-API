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
        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();
        
        CreateMap<BlogPost, BlogPostDto>().ReverseMap();
    }
}