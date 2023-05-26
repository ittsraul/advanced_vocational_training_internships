using WebApplication1.Domain.persistence;
using WebApplication1.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.infraestructure.persistence
{
    public class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(StoreContext storeContext)
        {
            _context = storeContext;
            _dbSet = _context.Set<T>();
        }

        public void Delete(long id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
                throw new ElementNotFoundException();
            _context.Remove(entity);
            _context.SaveChanges();
        }
        public List<T> GetAll() 
        {
            return _dbSet.ToList<T>();
        }

        public T GetById(long id) {
            var entity = _dbSet.Find(id);
            if(entity == null)
            {
                throw new ElementNotFoundException();
            }  
            return entity;
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T Insert(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
