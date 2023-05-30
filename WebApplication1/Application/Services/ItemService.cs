using AutoMapper;
using WebApplication1.Application.Dtos;
using WebApplication1.Domain.Entites;
using WebApplication1.Domain.persistence;
using WebApplication1.Domain.services;

namespace WebApplication1.Application.Services
{
    public  class ItemService : GenericService<Item, ItemDto>, IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IImageVerifier _imageVerifier;
        public ItemService(IItemRepository repository, IMapper mapper, IImageVerifier imageVerifier) : base(repository, mapper)
        {
            _itemRepository = repository;
            _imageVerifier = imageVerifier;
        }

        public List<ItemDto> GetAllByCategoryId(long categoryId)
        {
            var items = _itemRepository.GetByCategoryId(categoryId);
            return items;
        }

    public PagedList<ItemDto> GetItemsByCriteriaPaged(string? filter, PaginationParameters paginationParameters)
    {
        var items = _itemRepository.GetItemsByCriteriaPaged(filter, paginationParameters);
        return items;
  

        public override ItemDto Insert(ItemDto dto)
        {
            if (!_imageVerifier.IsImage(dto.Image)
            {
                throw new InvalidImageException();
            }
            return base.Insert(dto);
        }

    }

