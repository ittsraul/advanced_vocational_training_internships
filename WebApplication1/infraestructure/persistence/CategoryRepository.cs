using WebApplication1.Domain.Entites;
using WebApplication1.Domain.persistence;

namespace WebApplication1.infraestructure.persistence
{
    public class CategoryRepository:GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(StoreContext context) : base(context) { }
    }
}
