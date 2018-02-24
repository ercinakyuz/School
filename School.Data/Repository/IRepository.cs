using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using School.Data.Entity;

namespace School.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetWithNavigationProperties(IQueryable<TEntity> query, List<Expression<Func<TEntity, object>>> navigationProperties);
        TEntity FindByPredicate(Expression<Func<TEntity, bool>> predicate);
        TEntity FindById(int id);
        TEntity Insert(TEntity entity);
        bool InsertMany(List<TEntity> entities);
        bool Update(TEntity entity);
        bool UpdateMany(IEnumerable<TEntity> entities);
        bool Delete(TEntity entity);
        int GetMax(Expression<Func<TEntity, int>> predicate);


    }
}
