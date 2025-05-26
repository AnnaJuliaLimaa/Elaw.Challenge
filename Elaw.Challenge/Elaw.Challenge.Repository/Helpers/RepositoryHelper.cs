using Microsoft.EntityFrameworkCore;

namespace Elaw.Challenge.Extensions.Repository
{
    public static class RepositoryHelper
    {
        public static void Detach<T>(this DbContext context, T entity)
        {
            context.Entry(entity).State = EntityState.Detached;
        }
    }
}