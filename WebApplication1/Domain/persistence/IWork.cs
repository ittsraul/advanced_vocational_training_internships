namespace WebApplication1.Domain.persistence
{
    public interface IWork : IDisposable
    {
        void Complete();
        void Rollback();
    }
}
