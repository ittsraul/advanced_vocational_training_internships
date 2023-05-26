using AutoMapper;
using WebApplication1.Application.Dtos;
using WebApplication1.Domain.Entites;

namespace WebApplication1.Application.Mapper
{
    public class CategoryMapperProfile:Profile
    {
        public CategoryMapperProfile() {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
