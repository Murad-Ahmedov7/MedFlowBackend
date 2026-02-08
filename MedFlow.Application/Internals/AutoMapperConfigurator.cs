using Application.Business.Categories.Requests;
using Application.Business.Categories.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Internals;

public sealed class AutoMapperConfigurator : Profile
{
    public AutoMapperConfigurator()
    {
        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<Category, CreateCategoryResponse>();

        CreateMap<UpdateCategoryRequest, Category>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore());
        CreateMap<Category, UpdateCategoryResponse>();
        CreateMap<Category, GetCategoryByIdResponse>();
        CreateMap<Category, GetAllCategoriesResponse>();
    }
}
