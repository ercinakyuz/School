using Microsoft.EntityFrameworkCore;
using School.Data.Entity;

namespace School.Data.Repository
{
    public class RepositoryFactory
    {
        public static BaseRepository<TEntity> Create<TEntity>() where TEntity : BaseEntity
        {
            return new BaseRepository<TEntity>();
        }
        public static BaseRepository<TEntity> Create<TEntity>(DbContext context) where TEntity : BaseEntity
        {
            return new BaseRepository<TEntity>(context);
        }
    }
}
