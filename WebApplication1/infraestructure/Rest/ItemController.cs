using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.Dtos;
using WebApplication1.Application.Services;


namespace WebApplication1.infraestructure.Rest
{

    [Route("store/[controller]")]
    [ApiController]
    public class ItemController : GenericCrudController<ItemDto>
    {
        public ItemController(IItemService service) : base(service)
        {
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
                return Ok(response);
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
