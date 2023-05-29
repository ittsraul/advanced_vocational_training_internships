using AutoMapper;
using WebApplication1.Domain.persistence;

namespace WebApplication1.Application.Services
{
    public class GenericService<E, D> : IGenericService<D>
        where E : class
        where D : class

    {
        protected readonly IGenericService<E> _repository;
        protected readonly IMapper _mapper;
        public GenericService(IGenericRepository<E> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual List<D> GetAll()
        {
            var entities = _repository.GetAll();
            var dto = _mapper.Map<List<D>>(entities);
            return dto;
        }

        public virtual D Get(int id)
        {
            var category = _repository.GetById(id);
            return _mapper.Map<D>(category);
        }

        public virtual D Insert(D dto)
        {
            E entity = _mapper.Map<E>(dto);
            entity = _repository.Insert(entity);
            return _mapper.Map<D>(entity);
        }
        public virtual D Update(D dto)
        {
            E entity = _mapper.Map<E>(dto);
            entity = _repository.Update(entity);
            return _mapper.Map<D>(entity);
        }
        public virtual void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
