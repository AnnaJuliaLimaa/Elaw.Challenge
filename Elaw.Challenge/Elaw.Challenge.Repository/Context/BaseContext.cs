using Microsoft.EntityFrameworkCore;

namespace Elaw.Challenge.Extensions.Repository
{
    public abstract class BaseContext<T> : DbContext where T : DbContext
    {
        public BaseContext(DbContextOptions<T> options) : base(options)
        {
            Database.SetCommandTimeout(1000);
        }
    }
}