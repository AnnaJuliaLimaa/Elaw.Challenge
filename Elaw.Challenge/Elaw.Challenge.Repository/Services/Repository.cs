using Microsoft.EntityFrameworkCore;

namespace Elaw.Challenge.Extensions
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        #region Properties
        private readonly DbSet<T> _entity;
        private readonly DbContext _context;
        #endregion

        #region Constructors
        public Repository(DbContext context)
        {
            _entity = context.Set<T>();

            _context = context;
        }
        #endregion

        #region Methods
        public IQueryable<T> Get(bool tracking = false)
        {
            return tracking ? _entity : _entity.AsNoTracking();
        }
        public T GetById(Guid id)
        {
            return _entity.Find(id);
        }
        public T Add(T entity)
        {
            _entity.Add(entity);

            this.SaveChanges();

            //if (detach)
            //    _context.Detach(entity);

            return entity;
        }
        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            this.SaveChanges();

            return entity;
        }
        public void Delete(Guid id)
        {
            var entity = GetById(id);

            _context.Remove(entity);

            this.SaveChanges();
        }
        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async virtual Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion
    }
}