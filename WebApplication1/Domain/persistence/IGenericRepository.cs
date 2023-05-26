using WebApplication1.Domain.Entites;

namespace WebApplication1.Domain.persistence
{
    public interface IGenericRepository<T> where T : class
    {
        void Delete(long id);
        List<T> GetAll();
        T GetById(int id);
        T Insert(T category);

        T Update(T category);
    }
}
