using AutoMapper;
using System.Security.Cryptography.X509Certificates;
using WebApplication1.Application.Dtos;
using WebApplication1.Domain.Entites;
using WebApplication1.Domain.persistence;

namespace WebApplication1.Application.Services
{
    public class CategoryService : GenericService<Category, CategoryDto>, ICategoryService
    {
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper): base(categoryRepository)
        {
        }
    }
}
