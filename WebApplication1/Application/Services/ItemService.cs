using AutoMapper;
using WebApplication1.Application.Dtos;
using WebApplication1.Domain.Entites;
using WebApplication1.Domain.persistence;

namespace WebApplication1.Application.Services
{
    public  class ItemService : GenericService<Item, ItemDto>, IItemService
    {
        private IItemRepository _itemRepository;
        public ItemService(IItemRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _itemRepository = repository;
        }

        public List<ItemDto> GetAllByCategoryId(long categoryId)
        {
            var items = _itemRepository.GetByCategoryId(categoryId);
            return items;
        }

    public PagedList<ItemDto> GetItemsByCriteriaPaged(string? filter, PaginationParameters paginationParameters)
    {
        var items = _itemRepository.GetItemsByCriteriaPaged(filter, paginationParameters);
        return _mapper.Map<ItemDto>(items);
    }
   }
  
}

