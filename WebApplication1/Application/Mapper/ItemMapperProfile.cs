using AutoMapper;
using WebApplication1.Application.Dtos;
using WebApplication1.Domain.Entites;

namespace WebApplication1.Application.Mapper
{
    public class ItemMapperProfile:Profile
    {
        public ItemMapperProfile()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<ItemDto, Item>();
        }
    }
}
