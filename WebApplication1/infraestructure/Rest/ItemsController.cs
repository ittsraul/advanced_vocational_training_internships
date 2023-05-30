using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.Dtos;
using WebApplication1.Application.Services;
using WebApplication1.infraestructure.Rest;


namespace WebApplication1.infraestructure.Rest
{

    [Route("store/[controller]")]
    [ApiController]
    public class ItemsController : GenericCrudController<ItemDto>
    {
        private IItemService _itemService;
        public ItemsController(IItemService service) : base(service)
        {
            _itemService = service;
        }


        [NonAction]
        public override ActionResult<IEnumerable<ItemDto>> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Produces("application/json")]
        public ActionResult<PageResponse<ItemDto>> Get(FromQuery) string? Filter, [FromQuery] PaginationParameters paginationParameters) {
            try{
                PagedList<PagedResponse> page = _itemService.GetItemsByCriteriaPAged(filter, paginationParameters);
                var response = new PagedResponse<ItemDto>
                {
                    CurrentPage = page.CurrentPage,
                    TotalPages = page.TotalPages,
                    PageSize = page.PageSize,
                    TotalCount = page.TotalCount,
                    Data = page
                   };
                return ItemsController(response);
    }catch(MalformedFilterException){
            return BadRequest();    
        }
        }


        [HttpGet("store/categories/{categoryId}/items")]
        [Produces("application/json")]
        public ActionResult<IEnumerable <ItemDto>> GetAllFromCategory(long categoryId) {
            var items = _itemService.GetAllByCategoryId(categoryId);
            return Ok(items);
        }
    }
}
