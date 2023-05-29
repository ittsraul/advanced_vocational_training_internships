using WebApplication1.Application.Dtos;

namespace WebApplication1.Application.Services
{
    public interface IGenericService<D>  where D : class
    {
        void Delete(long id);
        List<D> GetAll();
        D Get(long id);
        D Insert(D Dto);

        D Update(D Dto);
    }
}
