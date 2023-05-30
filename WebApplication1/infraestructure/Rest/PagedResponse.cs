using WebApplication1.Application;
using WebApplication1.Application.Dtos;

namespace WebApplication1.infraestructure.Rest
{
    public class PagedResponse
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public PagedList<T> Date { get; set; }
    }
}
