using WebApplication1.Domain.Entites;

namespace WebApplication1.infraestructure.persistence
{
    public class ItemRepository:GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(StoreContext storeContext) :base(storeContext) { 
        }
    }
}
