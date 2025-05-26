namespace Elaw.Challenge.Extensions
{
    public interface IRepository<T>
    {
        IQueryable<T> Get(bool tracking = false);
        T GetById(Guid Id);
        T Add(T source);
        T Update(T source);
        void Delete(Guid Id);
    }
}
