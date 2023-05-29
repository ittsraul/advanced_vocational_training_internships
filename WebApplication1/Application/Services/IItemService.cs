using WebApplication1.Application.Dtos;

namespace WebApplication1.Application.Services
{
    public interface IItemService : IGenericService<ItemDto>
    {
        List<ItemDto> GetAllByCategoryId(long categoryId);
    }
}
