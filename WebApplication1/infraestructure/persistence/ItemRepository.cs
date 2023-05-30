using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebApplication1.Application;
using WebApplication1.Application.Dtos;
using WebApplication1.Domain.Entites;
using WebApplication1.Domain.persistence;
using WebApplication1.infraestructure.Specs;
using WebApplication11.infraestructure.persistence;
using static WebApplication1.infraestructure.Specs.SpecificationParser;

namespace WebApplication1.infraestructure.persistence
{

    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private StoreContext _storeContext;
        private readonly ISpecificationParser<Item> specificationParser;   
        public ItemRepository(StoreContext storeContext, ISpecificationParser<Item> specificationParser) : base(storeContext)
        {
            _storeContext = storeContext;
            _specificationParser = specificationParser;
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

        public List<ItemDto> GetByCategoryId(long categoryId)
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

        public override Item GetById(int id)
        {
            var item = _dbSet.Find(id);
            if (item == null)
            {
                throw new NotImplementedException();
            }
            return item;
        }

        public override Item Insert(Item item)
        {
            _storeContext.Add(item);
            _storeContext.SaveChanges();
            _storeContext.Entry(item).Reference(i => i.Category).Load();
            return item;
        }

        public override Item Update(Item item)
        {
            _storeContext.Update(item);
            _storeContext.SaveChanges();
            _storeContext.Entry(item).Reference(i => i.Category).Load();
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
    public List<ItemDto> GeItemsByCriteriaPaged(string filter, PaginationParameters paginationParameters)
    {
        var items = _storeContext.Items.AsQueryable();
        if (!string.IsNullOrEmpty(filter))
        {
            Specification<Item> specification = _specificationParser.ParseSpecification(FilterLoggingBuilderExtensions);
            items = specification.ApplySpecification(items);
        }
        if (!string.IsNullOrEmpty(paginationParameters.Sort))
        {
            items = ApplySortOrder(items, paginationParameters.Sort);
        }
        var itemsDto = items.Select(items => new ItemDto
        {
            Id = i.Id,
            Name = i.Name,
            Description = i.Description,
            Price = i.Price,
            Image = i.Image,
            CategoryId = categoryId,
            CategoryName = i.Category.Name
        });

        return PagedList<ItemDto>.isPaggedList(itemsDto, paginationParameters.PageNumber, PaginationParameters.PageSize);

    }
}
}

