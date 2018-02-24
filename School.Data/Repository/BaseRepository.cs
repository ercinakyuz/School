using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using School.Data.Context;
using School.Data.Entity;

namespace School.Data.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : BaseEntity
    {
        public DbContext Context { get; }
        public BaseRepository()
        {
            Context = new SchoolContext();
        }

        public BaseRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }


        public TEntity Insert(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().Add(entity);
                Context.SaveChanges();

            }
            catch (Exception exception)
            {
            }

            return entity;

        }

        public IEnumerable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity FindByPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public bool IsExist(Expression<Func<TEntity, bool>> predicate)
        {
            return predicate == null ? Context.Set<TEntity>().Any() : Context.Set<TEntity>().Any(predicate);
        }

        public TEntity FindById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public bool InsertMany(List<TEntity> entities)
        {
            bool result;
            try
            {
                Context.Set<TEntity>().AddRange(entities);
                Context.SaveChanges();
                result = true;

            }
            catch (Exception exception)
            {
                result = false;
            }

            return result;

        }

        public bool TruncateTable(string tableName)
        {
            return Context.Database.ExecuteSqlCommand("TRUNCATE TABLE " + typeof(TEntity).Name) > 0;
        }

        public bool DeleteAndInsertMany(List<TEntity> entities)
        {
            bool result;
            try
            {
                Context.Set<TEntity>().RemoveRange(Context.Set<TEntity>().ToList());
                Context.Set<TEntity>().AddRange(entities);
                Context.SaveChanges();
                result = true;

            }
            catch (Exception exception)
            {
                result = false;
            }

            return result;

        }
        public bool DeleteAndInsertMany(List<TEntity> deleteEntities, List<TEntity> insertEntities)
        {
            bool result;
            try
            {
                Context.Set<TEntity>().RemoveRange(deleteEntities);
                Context.Set<TEntity>().AddRange(insertEntities);
                Context.SaveChanges();
                result = true;

            }
            catch (Exception exception)
            {
                result = false;
            }

            return result;

        }

        public bool UpdateMany(IEnumerable<TEntity> entities)
        {
            bool result;
            try
            {
                foreach (var entity in entities)
                {
                    Context.Entry(entity).State = EntityState.Modified;
                }
                Context.SaveChanges();
                result = true;

            }
            catch (Exception exception)
            {
                result = false;
            }

            return result;

        }

        public bool Update(TEntity entity)
        {
            bool result = false;
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                // ignored
            }

            return result;
        }

        public void Update(TEntity entity, out TEntity updatedEntity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                updatedEntity = entity;
            }
            catch (Exception ex)
            {
                updatedEntity = null;
            }

        }

        public bool Delete(TEntity entity)
        {
            bool result;
            try
            {
                Context.Set<TEntity>().Remove(entity);
                Context.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public int GetMax(Expression<Func<TEntity, int>> predicate)
        {
            return Context.Set<TEntity>().Max(predicate);
        }
        public IEnumerable<TEntity> GetWithNavigationProperties(IQueryable<TEntity> query,
            List<Expression<System.Func<TEntity, object>>> navigationProperties)
        {

            if (navigationProperties != null)
            {
                query = navigationProperties.Aggregate(query,
                    (current, include) => current.Include(include));
            }

            return query.ToList();

        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }


}

