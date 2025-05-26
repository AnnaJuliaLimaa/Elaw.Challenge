namespace Elaw.Challenge.Domain
{
    public interface IBaseService<T>
    {
        IQueryable<T> Get();
        T GetById(Guid id);
        T Add(T model);
        T Update(T model);
        void Delete(Guid id);
    }
}
