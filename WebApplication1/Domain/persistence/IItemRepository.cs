using WebApplication1.Domain.Entites;
using WebApplication1.Application.Dtos;
using WebApplication1.Application;
using WebApplication1.Domain.persistence;

namespace WebApplication11.infraestructure.persistence

{

    public interface ItemRepository : IGenericRepository<Item>
    {
        List<ItemDto> GetByCriteriaID(long categoryId);
        PagedList<ItemDto> GetItemsByCriteriaPaged(string filter, PaginationParameters paginationParameters)
    }
}
