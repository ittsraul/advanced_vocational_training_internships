using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.Dtos;
using WebApplication1.Application.Services;
using WebApplication1.Domain.persistence;

namespace WebApplication1.infraestructure.Rest
{

    [Route("store/[controller]")]
    [ApiController]
    public class CategoriesController : GenericCrudController<CategoryDto>
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService):base(categoryService)
        {

        }

    [HttpGet]

        public ActionResult<CategoryDto> GetCategories()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        [Produces("application/json")]
        public ActionResult<CategoryDto> Get(long id)
        {
            try
            {
                CategoryDto categoryDto = _categoryService.Get(id);
                return Ok(categoryDto);
            }
            catch (ElementNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<CategoryDto> Insert(CategoryDto categoryDto)
        {
            if (categoryDto == null)
                return BadRequest();
            categoryDto = _categoryService.Insert(categoryDto);
            return CreatedAtAction(nameof(Get), new { id = categoryDto.Id }, categoryDto);
        }
        [HttpPut]
        [Produces("application/json")]
        [Consumes("application/json")]
        public ActionResult<CategoryDto> Update(CategoryDto categoryDto)
        {
            if (categoryDto == null)
                return BadRequest();
            categoryDto = _categoryService.Update(categoryDto);
            return CreatedAtAction(nameof(Get), new { id = categoryDto.Id }, categoryDto);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            try
            {
                _categoryService.Delete(id);
                return NoContent();
            }
            catch (ElementNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
