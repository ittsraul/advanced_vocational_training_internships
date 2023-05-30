namespace WebApplication1.Domain.persistence
{
    public interface IUnitOfWork
    {
        IWork init();
    }
}
