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
        IEnumerable<TEntity> InsertMany(List<TEntity> entities);
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> UpdateMany(IEnumerable<TEntity> entities);
        TEntity Delete(TEntity entity);
        int GetMax(Expression<Func<TEntity, int>> predicate);


    }
}
