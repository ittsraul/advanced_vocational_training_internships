using WebApplication1.Domain.Entites;
using WebApplication1.infraestructure.persistence;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Application.Dtos;

namespace WebApplication11.infraestructure.persistence

{
   
    public class ItemRepository : GenericRepository<Item>, IItemRepository { 

    public  ItemRepository(StoreContext storeContext) : base(storeContext)
    {
    }

    public List<ItemDto> GetByCategoryID(long categoryId)
    {
        var item = _dbSet.Where(i => i.CategoryId == categoryId).Select(i=> new ItemDto
        {
            Id = i.Id,
            Name = i.Name,
            Description = i.Description,
            Price = i.Price,
            Image = i.Image,
            CategoryId = categoryId,
            CategoryName = i.Category.Name
        }).ToList();
        if (item == null)
        {
            return new List<ItemDto>();
        }
        return item.ToList();
    }
}
}