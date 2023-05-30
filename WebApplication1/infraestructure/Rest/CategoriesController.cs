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
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger) : base(categoryService)
        {
            _logger = logger;
        }
 
        public override ActionResult<CategoryDto> Insert(CategoryDto categoryDto)
        {
            try
            {
                return base.Insert(categoryDto);
            }
            catch (ElementNotFoundException)
            {
                _logger.LogInformation("Invalid image inserting category with dto name", categoryDto.Name);
                return BadRequest();
            }
            
        public override ActionResult<CategoryDto> Update(CategoryDto categoryDto)
        {
            try
            {
                return base.Insert(categoryDto);
            }catch (ElementNotFoundException)
            {
                _logger.LogInformation("Invalid image inserting category with dto name", categoryDto.Name);
                return BadRequest();
            }
        
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
