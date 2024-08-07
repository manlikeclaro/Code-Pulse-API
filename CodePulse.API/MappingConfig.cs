using AutoMapper;
using CodePulse.API.Models;
using CodePulse.API.Models.Dto.BlogPost;
using CodePulse.API.Models.Dto.Category;

namespace CodePulse.API;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        // Map between Category and CategoryDto, with bidirectional mapping
        CreateMap<Category, CategoryDto>().ReverseMap();

        // Map between Category and CategoryCreateDto, with bidirectional mapping
        CreateMap<Category, CategoryCreateDto>().ReverseMap();

        // Map between Category and CategoryUpdateDto, with bidirectional mapping
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();

        // Map between BlogPost and BlogPostDto, with bidirectional mapping
        CreateMap<BlogPost, BlogPostDto>().ReverseMap();
    }
}