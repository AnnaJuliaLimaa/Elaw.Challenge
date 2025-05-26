namespace Elaw.Challenge.Extensions.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> Get(bool tracking = false);
        T GetById(Guid Id);
        T Add(T source, bool detach = false);
        T Update(T source);
        void Delete(Guid Id);
    }
}
