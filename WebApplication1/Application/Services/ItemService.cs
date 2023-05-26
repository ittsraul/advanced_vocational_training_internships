using AutoMapper;
using WebApplication1.Application.Dtos;
using WebApplication1.Domain.Entites;
using WebApplication1.infraestructure.persistence;

namespace WebApplication1.Application.Services
{
    public class ItemService : GenericService<Item, ItemDto>, IItemService
    {
        public ItemService(IItemRepository repository, IMapper mapper) : base(repository);
        {}
    }
}
