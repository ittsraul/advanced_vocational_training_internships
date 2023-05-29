using AutoMapper;
using WebApplication1.Application.Dtos;
using WebApplication1.Domain.Entites;
using WebApplication1.Domain.persistence;

namespace WebApplication1.Application.Services
{
    public class ItemService : GenericService<Item, ItemDto>, IItemService
    {
        public ItemService(IItemRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public List<ItemDto> GetAllByCategoryId(long categoryId)
        {
            var items = ((IItemRepository)_repository).GetByCategoryId(categoryId);
            return _mapper.Map<List<ItemDto>>(items);
        }
    }
  
}

