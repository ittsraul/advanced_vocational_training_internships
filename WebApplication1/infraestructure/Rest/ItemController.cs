using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.Dtos;
using WebApplication1.Application.Services;
using WebApplication1.Domain.persistence;

namespace WebApplication1.infraestructure.Rest
{

    [Route("store/[controller]")]
    [ApiController]
    public class ItemController : GenericCrudController<ItemDto>
    {
        public ItemController(IItemRepository service) : base(service)
        {
        }
    }
}
