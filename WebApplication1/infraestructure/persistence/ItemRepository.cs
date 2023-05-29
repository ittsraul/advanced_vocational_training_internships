using Microsoft.EntityFrameworkCore;
using WebApplication1.Application.Dtos;
using WebApplication1.Domain.Entites;
using WebApplication1.Domain.persistence;
using WebApplication11.infraestructure.persistence;

namespace WebApplication1.infraestructure.persistence
{

    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private StoreContext _storeContext;
        public ItemRepository(StoreContext storeContext) : base(storeContext)
        {
            _storeContext = storeContext;
        }

        public override Item GetById(long id)
        {

            var item = _storeContext.Item.Include(i => i.Category).SingleOrDefault();
            if (item == null)
            {
                throw new ElementNotFoundException();
            }
            return item;
        }

        public List<ItemDto> GetByCategoryID(long categoryId)
        {
            var item = _dbSet.Where(i => i.CategoryId == categoryId).Select(i => new ItemDto
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
